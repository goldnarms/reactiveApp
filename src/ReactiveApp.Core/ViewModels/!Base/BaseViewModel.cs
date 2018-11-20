using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reactive.Disposables;
using System.Runtime.CompilerServices;
using MvvmCross.ViewModels;
using ReactiveApp.Core.Models;
using ReactiveUI;
using PropertyChangingEventArgs = ReactiveUI.PropertyChangingEventArgs;
using PropertyChangingEventHandler = ReactiveUI.PropertyChangingEventHandler;

namespace ReactiveApp.Core.ViewModels
{
    public abstract class BaseViewModel : MvxViewModel, IReactiveNotifyPropertyChanged<IReactiveObject>, IReactiveObject, IDisposable
    {
        public BaseViewModel()
        {
        }

        private readonly MvxReactiveObject _reactiveObj = new MvxReactiveObject();
        protected readonly CompositeDisposable CompositeDisposable = new CompositeDisposable();
        private bool _suppressNpc;
        private bool _isBusy;

        protected bool IsBusy
        {
            get => _isBusy;
            set => IReactiveObjectExtensions.RaiseAndSetIfChanged(this, ref _isBusy, value);
        }

        public virtual IDisposable SuppressChangeNotifications()
        {
            _suppressNpc = true;
            var suppressor = _reactiveObj.SuppressChangeNotifications();

            return new DisposableAction(() =>
            {
                _suppressNpc = false;
                suppressor.Dispose();
            });
        }


        public IObservable<IReactivePropertyChangedEventArgs<IReactiveObject>> Changing => _reactiveObj.Changing;
        public IObservable<IReactivePropertyChangedEventArgs<IReactiveObject>> Changed => _reactiveObj.Changed;


        public virtual void RaisePropertyChanging(PropertyChangingEventArgs args)
        {
            _reactiveObj.RaisePropertyChanging(args.PropertyName);
        }

        public new void RaisePropertyChanged(PropertyChangedEventArgs args)
        {
            _reactiveObj.RaisePropertyChanged(args.PropertyName);
        }

        public override void ViewAppeared()
        {
            base.ViewAppeared();
            var viewModelName = GetType().Name.Replace("ViewModel", "");
            var properties = new Dictionary<string, string> { { "Name", viewModelName } };
        }

        public override void ViewDisappeared()
        {
            base.ViewDisappeared();
            var viewModelName = GetType().Name.Replace("ViewModel", "");
            var properties = new Dictionary<string, string> { { "Name", viewModelName } };
        }

        public event PropertyChangingEventHandler PropertyChanging
        {
            add => _reactiveObj.PropertyChanging += value;
            remove => _reactiveObj.PropertyChanging -= value;
        }

        public new bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            var original = storage;
            IReactiveObjectExtensions.RaiseAndSetIfChanged(this, ref storage, value, propertyName);

            return !EqualityComparer<T>.Default.Equals(original, value);
        }

        protected override MvxInpcInterceptionResult InterceptRaisePropertyChanged(PropertyChangedEventArgs changedArgs)
        {
            if (_suppressNpc)
                return MvxInpcInterceptionResult.DoNotRaisePropertyChanged;

            return base.InterceptRaisePropertyChanged(changedArgs);
        }

        public void Dispose()
        {
            _reactiveObj?.Dispose();
            CompositeDisposable?.Clear();
        }
    }
}
