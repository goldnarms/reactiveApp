using MvvmCross.ViewModels;
using ReactiveApp.Core.ViewModels;

namespace Kakemons.Core.ViewModels
{
    public abstract class BaseViewModel<TParameter> : BaseViewModel, IMvxViewModel<TParameter>
    {
        public abstract void Prepare(TParameter parameter);

        protected BaseViewModel()
        {
        }
    }
}
