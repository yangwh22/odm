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
	
	public partial class ImagingSettingsView{
		
		#region Model definition
		
		public interface IModelAccessor{
			ImagingSettings20 settings{get;set;}
			
		}
		public class Model: IModelAccessor, INotifyPropertyChanged{
			
			public Model(
				string profToken, ImagingOptions20 options
			){
				
				this.profToken = profToken;
				this.options = options;
			}
			private Model(){
			}
			

			public static Model Create(
				string profToken,
				ImagingOptions20 options,
				ImagingSettings20 settings
			){
				var _this = new Model();
				
				_this.profToken = profToken;
				_this.options = options;
				_this.origin.settings = settings;
				_this.RevertChanges();
				
				return _this;
			}
		
				private SimpleChangeTrackable<ImagingSettings20> m_settings;
				public string profToken{get;private set;}
				public ImagingOptions20 options{get;private set;}

			private class OriginAccessor: IModelAccessor {
				private Model m_model;
				public OriginAccessor(Model model) {
					m_model = model;
				}
				ImagingSettings20 IModelAccessor.settings {
					get {return m_model.m_settings.origin;}
					set {m_model.m_settings.origin = value;}
				}
				
			}
			public event PropertyChangedEventHandler PropertyChanged;
			private void NotifyPropertyChanged(string propertyName){
				var prop_changed = this.PropertyChanged;
				if (prop_changed != null) {
					prop_changed(this, new PropertyChangedEventArgs(propertyName));
				}
			}
			
			public ImagingSettings20 settings  {
				get {return m_settings.current;}
				set {
					if(m_settings.current != value) {
						m_settings.current = value;
						NotifyPropertyChanged("settings");
					}
				}
			}
			
			public void AcceptChanges() {
				m_settings.AcceptChanges();
				
			}

			public void RevertChanges() {
				this.current.settings= this.origin.settings;
				
			}

			public bool isModified {
				get {
					if(m_settings.isModified)return true;
					
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
				Func<T> none
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
					Func<T> none
				){
					return apply(
						model
					);
				}
	
			}
			
			public bool IsNone(){
				return AsNone() != null;
			}
			public virtual None AsNone(){ return null; }
			public class None : Result {
				public None(){
					
				}
				
				public override None AsNone(){ return this; }
				
				public override T Handle<T>(
				
					Func<Model,T> apply,
					Func<T> none
				){
					return none(
						
					);
				}
	
			}
			
		}
		#endregion

		public ICommand ApplyCommand{ get; private set; }
		public ICommand NoneCommand{ get; private set; }
		
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
		
		public ImagingSettingsView(Model model, IActivityContext<Result> activityContext) {
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
