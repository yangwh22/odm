﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using Microsoft.Practices.Unity;
using odm.ui.core;
using utils;
using System.Xml;
using onvif.services;
using odm.ui.controls;
using odm.player;
using System.Reactive.Disposables;
using odm.ui.activities;

namespace odm.ui.views.CustomAnalytics {
    /// <summary>
    /// Interaction logic for SynesisTripWireRuleView.xaml
    /// </summary>
    public partial class SynesisTripWireRuleView : UserControl, IDisposable, IPlaybackController {
        public SynesisTripWireRuleView() {
            InitializeComponent();
			disposables = new CompositeDisposable();
        }
        public string title = "Trip wire rule configuration";
        IUnityContainer container;
        odm.ui.activities.ConfigureAnalyticView.ModuleDescriptor modulDescr;
        odm.ui.activities.ConfigureAnalyticView.AnalyticsVideoDescriptor videoDescr;
        IVideoInfo videoInfo;
        SynesisTripWireRuleModel model;
        Size videoSourceSize;
        Size videoEncoderSize;
        public PropertyRuleEngineStrings Strings { get { return PropertyRuleEngineStrings.instance; } }

        public void Apply() {
            GetData();
        }

        public class SynesisTripWireRuleModel : INotifyPropertyChanged {
            public SynesisTripWireRuleModel() {
            }
            public synesis.TripWirePoints TripPoints { get; set; }
            public odm.ui.controls.GraphEditor.TripWireEditor.TripWireDirection TripDirection { get; set; }
            
            private void NotifyPropertyChanged(String info) {
				var prop_changed = this.PropertyChanged;
				if (prop_changed != null) {
					prop_changed(this, new PropertyChangedEventArgs(info));
				}
            }
            public event PropertyChangedEventHandler PropertyChanged;
        }

        void GetSimpleItems() {
            modulDescr.config.Parameters.SimpleItem.ForEach(x => {
                switch (x.Name) {
                    case "Direction":
                        switch (model.TripDirection) { 
                            case controls.GraphEditor.TripWireEditor.TripWireDirection.FromBoth:
                                x.Value = "FromBoth";
                                break;
                            case controls.GraphEditor.TripWireEditor.TripWireDirection.FromLeft:
                                x.Value = "FromLeft";
                                break;
                            case controls.GraphEditor.TripWireEditor.TripWireDirection.FromRight:
                                x.Value = "FromRight";
                                break;
                        }
                        break;
                }
            });
        }
        void GetElementItems() {
            modulDescr.config.Parameters.ElementItem.ForEach(x => {
                switch (x.Name) {
                    case "Points":
                        x.Any = model.TripPoints.Serialize();
                        break;
                    //case "Direction":
                    //    ScalePointsOutput(model.TripPoints);
                    //    x.Any = model.TripDirection.Serialize();
                    //    break;
                }
            });
        }
        void FillSimpleItems(ItemListSimpleItem[] simpleItems, SynesisTripWireRuleModel model) {
            simpleItems.ForEach(x => {
                switch (x.Name) {
                    case "Direction":
                        switch (x.Value) { 
                            case "FromLeft":
                                model.TripDirection = controls.GraphEditor.TripWireEditor.TripWireDirection.FromLeft;
                                break;
                            case "FromRight":
                                model.TripDirection = controls.GraphEditor.TripWireEditor.TripWireDirection.FromRight;
                                break;
                            case "FromBoth":
                                model.TripDirection = controls.GraphEditor.TripWireEditor.TripWireDirection.FromBoth;
                                break;
                        }
                        //model.ruleId = XmlConvert.ToInt32(x.Value);
                        break;
                }
            });
        }

        void FillElementItems(ItemListElementItem[] elementItems, SynesisTripWireRuleModel model) {
            elementItems.ForEach(x => {
                switch (x.Name) {
                    case "Points":
                        model.TripPoints = x.Any.Deserialize<synesis.TripWirePoints>();
                        ScalePointsInput(model.TripPoints);
                        break;
                    //case "Direction":
                    //    int i = 0;
                    //    //model.TripDirection = x.Any.Deserialize<synesis.TripWireDirection>();
                    //    break;
                }
            });
        }
        void ScalePointsInput(synesis.TripWirePoints points) {
            DataConverter.ScalePointInput(points.P1, videoSourceSize, videoEncoderSize);
            DataConverter.ScalePointInput(points.P2, videoSourceSize, videoEncoderSize);
        }
        void ScalePointsOutput(synesis.TripWirePoints points) {
            DataConverter.ScalePointOutput(points.P1, videoSourceSize, videoEncoderSize);
            DataConverter.ScalePointOutput(points.P2, videoSourceSize, videoEncoderSize);
        }

        void InitRegionEditor() {
            Point P1 = new Point(model.TripPoints.P1.X, model.TripPoints.P1.Y);
            Point P2 = new Point(model.TripPoints.P2.X, model.TripPoints.P2.Y);
            wireditor.Init(P1, P2, videoInfo.Resolution, model.TripDirection);
        }
        void GetData() {
            try {
                model.TripPoints.P1 = new synesis.Point() { X = (int)wireditor.P1.X, Y = (int)wireditor.P1.Y };
                model.TripPoints.P2 = new synesis.Point() { X = (int)wireditor.P2.X, Y = (int)wireditor.P2.Y };
                model.TripDirection = wireditor.ruleDirection;
                ScalePointsOutput(model.TripPoints);
                GetElementItems();
                GetSimpleItems();
            } catch (Exception err) {
                dbg.Error(err);
            }
        }
        void BindData() {
            try {
                InitRegionEditor();
                valueDirection.Items.Add(odm.ui.controls.GraphEditor.TripWireEditor.TripWireDirection.FromBoth);
                valueDirection.Items.Add(odm.ui.controls.GraphEditor.TripWireEditor.TripWireDirection.FromLeft);
                valueDirection.Items.Add(odm.ui.controls.GraphEditor.TripWireEditor.TripWireDirection.FromRight);

                valueDirection.SelectionChanged+=new SelectionChangedEventHandler((obj, evarg)=>{
                    if (valueDirection.SelectedValue == null) {
                        return;
                    }
                    wireditor.SetDirection((odm.ui.controls.GraphEditor.TripWireEditor.TripWireDirection)valueDirection.SelectedValue);
                });
                valueDirection.SelectedValue = model.TripDirection;
                

            } catch (Exception err) {
                dbg.Error(err);
            }
        }

        public bool Init(IUnityContainer container, odm.ui.activities.ConfigureAnalyticView.ModuleDescriptor modulDescr, odm.ui.activities.ConfigureAnalyticView.AnalyticsVideoDescriptor videoDescr) {
            this.modulDescr = modulDescr;
            this.videoDescr = videoDescr;
            this.container = container;
            this.videoInfo = videoDescr.videoInfo;

            videoSourceSize = new Size(videoDescr.videoSourceResolution.Width, videoDescr.videoSourceResolution.Height);
            videoEncoderSize = new Size(videoDescr.videoInfo.Resolution.Width, videoDescr.videoInfo.Resolution.Height);

            model = new SynesisTripWireRuleModel();

            try {
                FillSimpleItems(modulDescr.config.Parameters.SimpleItem, model);
            } catch (Exception err) {
                dbg.Error(err);
                return false;
            }
            try{
                FillElementItems(modulDescr.config.Parameters.ElementItem, model);
            } catch (Exception err) {
                dbg.Error(err);
                return false;
            }

            try{
                BindData();
				VideoStartup(videoInfo);
            } catch (Exception err) {
                dbg.Error(err);
                return false;
            }
            return true;
        }
		IPlaybackSession playbackSession;
		VideoBuffer vidBuff;
		CompositeDisposable disposables;
		void VideoStartup(IVideoInfo iVideo) {
			vidBuff = new VideoBuffer((int)iVideo.Resolution.Width, (int)iVideo.Resolution.Height);

			var playerAct = container.Resolve<IVideoPlayerActivity>();

			var model = new VideoPlayerActivityModel(
				profileToken: videoDescr.profileToken,
				showStreamUrl: false,
				streamSetup: new StreamSetup() {
					Stream = StreamType.RTPUnicast,
					Transport = new Transport() {
						Protocol = AppDefaults.visualSettings.Transport_Type,
						Tunnel = null
					}
				}
			);

			disposables.Add(
				container.RunChildActivity(player, model, (c, m) => playerAct.Run(c, m))
			);
		}

		public void Dispose() {
			if (vidBuff != null) {
				vidBuff.Dispose();
			}
			disposables.Dispose();
			//TODO: release player host
		}

		public new bool Initialized(IPlaybackSession playbackSession) {
			this.playbackSession = playbackSession;
			return true;
		}

		public void Shutdown() {
		}
	}
}
