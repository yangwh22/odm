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
	
	public partial class LiveVideoView{
		
		#region Model definition
		
		public class Model{
			
			public Model(
				string profToken
			){
				
				this.profToken = profToken;
			}
			private Model(){
			}
			

			public static Model Create(
				string profToken
			){
				var _this = new Model();
				
				_this.profToken = profToken;
				return _this;
			}
		
			public string profToken{get;private set;}
		}
			
		#endregion
	
		#region Result definition
		public abstract class Result{
			private Result() { }
			
			public abstract T Handle<T>(
				
				Func<T> close
			);
	
			public bool IsClose(){
				return AsClose() != null;
			}
			public virtual Close AsClose(){ return null; }
			public class Close : Result {
				public Close(){
					
				}
				
				public override Close AsClose(){ return this; }
				
				public override T Handle<T>(
				
					Func<T> close
				){
					return close(
						
					);
				}
	
			}
			
		}
		#endregion

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
		
		public LiveVideoView(Model model, IActivityContext<Result> activityContext) {
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
