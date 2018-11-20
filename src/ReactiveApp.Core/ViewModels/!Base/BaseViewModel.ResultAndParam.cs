using MvvmCross.ViewModels;

namespace Kakemons.Core.ViewModels
{
    public abstract class BaseViewModel<TParameter, TResult> : BaseViewModelResult<TResult>, IMvxViewModel<TParameter, TResult>
    {
        public abstract void Prepare(TParameter parameter);

        protected BaseViewModel()
        {
        }
    }
}
