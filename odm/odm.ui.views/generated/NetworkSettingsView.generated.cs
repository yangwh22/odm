﻿
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reactive.Disposables;
using System.Windows.Input;
using odm.infra;
namespace odm.ui.activities {
	using global::onvif.services;
	
	public partial class NetworkSettingsView{
		
		#region Model definition
		
		public interface IModelAccessor{
			bool useHostFromDhcp{get;set;}
			string host{get;set;}
			string ip{get;set;}
			string subnet{get;set;}
			string dns{get;set;}
			string gateway{get;set;}
			bool dhcp{get;set;}
			string ntpServers{get;set;}
			bool useNtpFromDhcp{get;set;}
			string dnsServer{get;set;}
			bool useDnsFromDhcp{get;set;}
			bool zeroConfEnabled{get;set;}
			NetworkProtocol[] netProtocols{get;set;}
			DiscoveryMode discoveryMode{get;set;}
			
		}
		public class Model: IModelAccessor, INotifyPropertyChanged{
			
			public Model(
				bool zeroConfSupported, string zeroConfIp, bool discoveryModeSupported
			){
				
				this.zeroConfSupported = zeroConfSupported;
				this.zeroConfIp = zeroConfIp;
				this.discoveryModeSupported = discoveryModeSupported;
			}
			private Model(){
			}
			

			public static Model Create(
				bool useHostFromDhcp,
				string host,
				string ip,
				string subnet,
				string dns,
				string gateway,
				bool dhcp,
				string ntpServers,
				bool useNtpFromDhcp,
				string dnsServer,
				bool useDnsFromDhcp,
				bool zeroConfSupported,
				bool zeroConfEnabled,
				string zeroConfIp,
				NetworkProtocol[] netProtocols,
				bool discoveryModeSupported,
				DiscoveryMode discoveryMode
			){
				var _this = new Model();
				
				_this.zeroConfSupported = zeroConfSupported;
				_this.zeroConfIp = zeroConfIp;
				_this.discoveryModeSupported = discoveryModeSupported;
				_this.origin.useHostFromDhcp = useHostFromDhcp;
				_this.origin.host = host;
				_this.origin.ip = ip;
				_this.origin.subnet = subnet;
				_this.origin.dns = dns;
				_this.origin.gateway = gateway;
				_this.origin.dhcp = dhcp;
				_this.origin.ntpServers = ntpServers;
				_this.origin.useNtpFromDhcp = useNtpFromDhcp;
				_this.origin.dnsServer = dnsServer;
				_this.origin.useDnsFromDhcp = useDnsFromDhcp;
				_this.origin.zeroConfEnabled = zeroConfEnabled;
				_this.origin.netProtocols = netProtocols;
				_this.origin.discoveryMode = discoveryMode;
				_this.RevertChanges();
				
				return _this;
			}
		
				private SimpleChangeTrackable<bool> m_useHostFromDhcp;
				private SimpleChangeTrackable<string> m_host;
				private SimpleChangeTrackable<string> m_ip;
				private SimpleChangeTrackable<string> m_subnet;
				private SimpleChangeTrackable<string> m_dns;
				private SimpleChangeTrackable<string> m_gateway;
				private SimpleChangeTrackable<bool> m_dhcp;
				private SimpleChangeTrackable<string> m_ntpServers;
				private SimpleChangeTrackable<bool> m_useNtpFromDhcp;
				private SimpleChangeTrackable<string> m_dnsServer;
				private SimpleChangeTrackable<bool> m_useDnsFromDhcp;
				private SimpleChangeTrackable<bool> m_zeroConfEnabled;
				private SimpleChangeTrackable<NetworkProtocol[]> m_netProtocols;
				private SimpleChangeTrackable<DiscoveryMode> m_discoveryMode;
				public bool zeroConfSupported{get;private set;}
				public string zeroConfIp{get;private set;}
				public bool discoveryModeSupported{get;private set;}

			private class OriginAccessor: IModelAccessor {
				private Model m_model;
				public OriginAccessor(Model model) {
					m_model = model;
				}
				bool IModelAccessor.useHostFromDhcp {
					get {return m_model.m_useHostFromDhcp.origin;}
					set {m_model.m_useHostFromDhcp.origin = value;}
				}
				string IModelAccessor.host {
					get {return m_model.m_host.origin;}
					set {m_model.m_host.origin = value;}
				}
				string IModelAccessor.ip {
					get {return m_model.m_ip.origin;}
					set {m_model.m_ip.origin = value;}
				}
				string IModelAccessor.subnet {
					get {return m_model.m_subnet.origin;}
					set {m_model.m_subnet.origin = value;}
				}
				string IModelAccessor.dns {
					get {return m_model.m_dns.origin;}
					set {m_model.m_dns.origin = value;}
				}
				string IModelAccessor.gateway {
					get {return m_model.m_gateway.origin;}
					set {m_model.m_gateway.origin = value;}
				}
				bool IModelAccessor.dhcp {
					get {return m_model.m_dhcp.origin;}
					set {m_model.m_dhcp.origin = value;}
				}
				string IModelAccessor.ntpServers {
					get {return m_model.m_ntpServers.origin;}
					set {m_model.m_ntpServers.origin = value;}
				}
				bool IModelAccessor.useNtpFromDhcp {
					get {return m_model.m_useNtpFromDhcp.origin;}
					set {m_model.m_useNtpFromDhcp.origin = value;}
				}
				string IModelAccessor.dnsServer {
					get {return m_model.m_dnsServer.origin;}
					set {m_model.m_dnsServer.origin = value;}
				}
				bool IModelAccessor.useDnsFromDhcp {
					get {return m_model.m_useDnsFromDhcp.origin;}
					set {m_model.m_useDnsFromDhcp.origin = value;}
				}
				bool IModelAccessor.zeroConfEnabled {
					get {return m_model.m_zeroConfEnabled.origin;}
					set {m_model.m_zeroConfEnabled.origin = value;}
				}
				NetworkProtocol[] IModelAccessor.netProtocols {
					get {return m_model.m_netProtocols.origin;}
					set {m_model.m_netProtocols.origin = value;}
				}
				DiscoveryMode IModelAccessor.discoveryMode {
					get {return m_model.m_discoveryMode.origin;}
					set {m_model.m_discoveryMode.origin = value;}
				}
				
			}
			public event PropertyChangedEventHandler PropertyChanged;
			private void NotifyPropertyChanged(string propertyName){
				var prop_changed = this.PropertyChanged;
				if (prop_changed != null) {
					prop_changed(this, new PropertyChangedEventArgs(propertyName));
				}
			}
			
			public bool useHostFromDhcp  {
				get {return m_useHostFromDhcp.current;}
				set {
					if(m_useHostFromDhcp.current != value) {
						m_useHostFromDhcp.current = value;
						NotifyPropertyChanged("useHostFromDhcp");
					}
				}
			}
			
			public string host  {
				get {return m_host.current;}
				set {
					if(m_host.current != value) {
						m_host.current = value;
						NotifyPropertyChanged("host");
					}
				}
			}
			
			public string ip  {
				get {return m_ip.current;}
				set {
					if(m_ip.current != value) {
						m_ip.current = value;
						NotifyPropertyChanged("ip");
					}
				}
			}
			
			public string subnet  {
				get {return m_subnet.current;}
				set {
					if(m_subnet.current != value) {
						m_subnet.current = value;
						NotifyPropertyChanged("subnet");
					}
				}
			}
			
			public string dns  {
				get {return m_dns.current;}
				set {
					if(m_dns.current != value) {
						m_dns.current = value;
						NotifyPropertyChanged("dns");
					}
				}
			}
			
			public string gateway  {
				get {return m_gateway.current;}
				set {
					if(m_gateway.current != value) {
						m_gateway.current = value;
						NotifyPropertyChanged("gateway");
					}
				}
			}
			
			public bool dhcp  {
				get {return m_dhcp.current;}
				set {
					if(m_dhcp.current != value) {
						m_dhcp.current = value;
						NotifyPropertyChanged("dhcp");
					}
				}
			}
			
			public string ntpServers  {
				get {return m_ntpServers.current;}
				set {
					if(m_ntpServers.current != value) {
						m_ntpServers.current = value;
						NotifyPropertyChanged("ntpServers");
					}
				}
			}
			
			public bool useNtpFromDhcp  {
				get {return m_useNtpFromDhcp.current;}
				set {
					if(m_useNtpFromDhcp.current != value) {
						m_useNtpFromDhcp.current = value;
						NotifyPropertyChanged("useNtpFromDhcp");
					}
				}
			}
			
			public string dnsServer  {
				get {return m_dnsServer.current;}
				set {
					if(m_dnsServer.current != value) {
						m_dnsServer.current = value;
						NotifyPropertyChanged("dnsServer");
					}
				}
			}
			
			public bool useDnsFromDhcp  {
				get {return m_useDnsFromDhcp.current;}
				set {
					if(m_useDnsFromDhcp.current != value) {
						m_useDnsFromDhcp.current = value;
						NotifyPropertyChanged("useDnsFromDhcp");
					}
				}
			}
			
			public bool zeroConfEnabled  {
				get {return m_zeroConfEnabled.current;}
				set {
					if(m_zeroConfEnabled.current != value) {
						m_zeroConfEnabled.current = value;
						NotifyPropertyChanged("zeroConfEnabled");
					}
				}
			}
			
			public NetworkProtocol[] netProtocols  {
				get {return m_netProtocols.current;}
				set {
					if(m_netProtocols.current != value) {
						m_netProtocols.current = value;
						NotifyPropertyChanged("netProtocols");
					}
				}
			}
			
			public DiscoveryMode discoveryMode  {
				get {return m_discoveryMode.current;}
				set {
					if(m_discoveryMode.current != value) {
						m_discoveryMode.current = value;
						NotifyPropertyChanged("discoveryMode");
					}
				}
			}
			
			public void AcceptChanges() {
				m_useHostFromDhcp.AcceptChanges();
				m_host.AcceptChanges();
				m_ip.AcceptChanges();
				m_subnet.AcceptChanges();
				m_dns.AcceptChanges();
				m_gateway.AcceptChanges();
				m_dhcp.AcceptChanges();
				m_ntpServers.AcceptChanges();
				m_useNtpFromDhcp.AcceptChanges();
				m_dnsServer.AcceptChanges();
				m_useDnsFromDhcp.AcceptChanges();
				m_zeroConfEnabled.AcceptChanges();
				m_netProtocols.AcceptChanges();
				m_discoveryMode.AcceptChanges();
				
			}

			public void RevertChanges() {
				this.current.useHostFromDhcp= this.origin.useHostFromDhcp;
				this.current.host= this.origin.host;
				this.current.ip= this.origin.ip;
				this.current.subnet= this.origin.subnet;
				this.current.dns= this.origin.dns;
				this.current.gateway= this.origin.gateway;
				this.current.dhcp= this.origin.dhcp;
				this.current.ntpServers= this.origin.ntpServers;
				this.current.useNtpFromDhcp= this.origin.useNtpFromDhcp;
				this.current.dnsServer= this.origin.dnsServer;
				this.current.useDnsFromDhcp= this.origin.useDnsFromDhcp;
				this.current.zeroConfEnabled= this.origin.zeroConfEnabled;
				this.current.netProtocols= this.origin.netProtocols;
				this.current.discoveryMode= this.origin.discoveryMode;
				
			}

			public bool isModified {
				get {
					if(m_useHostFromDhcp.isModified)return true;
					if(m_host.isModified)return true;
					if(m_ip.isModified)return true;
					if(m_subnet.isModified)return true;
					if(m_dns.isModified)return true;
					if(m_gateway.isModified)return true;
					if(m_dhcp.isModified)return true;
					if(m_ntpServers.isModified)return true;
					if(m_useNtpFromDhcp.isModified)return true;
					if(m_dnsServer.isModified)return true;
					if(m_useDnsFromDhcp.isModified)return true;
					if(m_zeroConfEnabled.isModified)return true;
					if(m_netProtocols.isModified)return true;
					if(m_discoveryMode.isModified)return true;
					
					return false;
				}
			}

			public IModelAccessor current {
				get {return this;}
				
			}

			public IModelAccessor origin {
				get {return new OriginAccessor(this);}
				
			}
		}
			
		#endregion
	
		#region Result definition
		public abstract class Result{
			private Result() { }
			
			public abstract T Handle<T>(
				
				Func<Model,T> apply,
				Func<T> close
			);
	
			public bool IsApply(){
				return AsApply() != null;
			}
			public virtual Apply AsApply(){ return null; }
			public class Apply : Result {
				public Apply(Model model){
					
					this.model = model;
					
				}
				public Model model{ get; set; }
				public override Apply AsApply(){ return this; }
				
				public override T Handle<T>(
				
					Func<Model,T> apply,
					Func<T> close
				){
					return apply(
						model
					);
				}
	
			}
			
			public bool IsClose(){
				return AsClose() != null;
			}
			public virtual Close AsClose(){ return null; }
			public class Close : Result {
				public Close(){
					
				}
				
				public override Close AsClose(){ return this; }
				
				public override T Handle<T>(
				
					Func<Model,T> apply,
					Func<T> close
				){
					return close(
						
					);
				}
	
			}
			
		}
		#endregion

		public ICommand ApplyCommand{ get; private set; }
		public ICommand CloseCommand{ get; private set; }
		
		IActivityContext<Result> activityContext = null;
		SingleAssignmentDisposable activityCancellationSubscription = new SingleAssignmentDisposable();
		bool activityCompleted = false;
		//activity has been completed
		event Action OnCompleted = null;
		//activity has been failed
		event Action<Exception> OnError = null;
		//activity has been completed successfully
		event Action<Result> OnSuccess = null;
		//activity has been canceled
		event Action OnCancelled = null;
		
		public NetworkSettingsView(Model model, IActivityContext<Result> activityContext) {
			this.activityContext = activityContext;
			if(activityContext!=null){
				activityCancellationSubscription.Disposable = 
					activityContext.RegisterCancellationCallback(() => {
						EnsureAccess(() => {
							CompleteWith(() => {
								if(OnCancelled!=null){
									OnCancelled();
								}
							});
						});
					});
			}
			Init(model);
		}

		
		public void EnsureAccess(Action action){
			if(!CheckAccess()){
				Dispatcher.Invoke(action);
			}else{
				action();
			}
		}

		public void CompleteWith(Action cont){
			if(!activityCompleted){
				activityCompleted = true;
				cont();
				if(OnCompleted!=null){
					OnCompleted();
				}
				activityCancellationSubscription.Dispose();
			}
		}
		public void Success(Result result) {
			CompleteWith(() => {
				if(activityContext!=null){
					activityContext.Success(result);
				}
				if(OnSuccess!=null){
					OnSuccess(result);
				}
			});
		}
		public void Error(Exception error) {
			CompleteWith(() => {
				if(activityContext!=null){
					activityContext.Error(error);
				}
				if(OnError!=null){
					OnError(error);
				}
			});
		}
		public void Cancel() {
			CompleteWith(() => {
				if(activityContext!=null){
					activityContext.Cancel();
				}
				if(OnCancelled!=null){
					OnCancelled();
				}
			});
		}
		public void Success(Func<Result> resultFactory) {
			CompleteWith(() => {
				var result = resultFactory();
				if(activityContext!=null){
					activityContext.Success(result);
				}
				if(OnSuccess!=null){
					OnSuccess(result);
				}
			});
		}
		public void Error(Func<Exception> errorFactory) {
			CompleteWith(() => {
				var error = errorFactory();
				if(activityContext!=null){
					activityContext.Error(error);
				}
				if(OnError!=null){
					OnError(error);
				}
			});
		}
		public void Cancel(Action action) {
			CompleteWith(() => {
				action();
				if(activityContext!=null){
					activityContext.Cancel();
				}
				if(OnCancelled!=null){
					OnCancelled();
				}
			});
		}
		
	}
}
