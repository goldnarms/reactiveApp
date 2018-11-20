using System.Reactive;
using System.Threading.Tasks;
using MvvmCross.Navigation;
using ReactiveUI;

namespace ReactiveApp.Core.ViewModels.Onboarding
{
    public class OnboardingViewModel : BaseViewModel
    {
        private readonly IMvxNavigationService _navigationService;
        private int _pageCount = 3;
        public OnboardingViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
            GoToLoginCommand = ReactiveCommand.CreateFromTask(GoToLogin);
            GoToRegisterCommand = ReactiveCommand.CreateFromTask(GoToRegister);
        }

        public ReactiveCommand<Unit, Unit> GoToRegisterCommand { get; set; }

        public ReactiveCommand<Unit, Unit> GoToLoginCommand { get; set; }

        public override Task Initialize()
        {
            return base.Initialize();
        }

        private async Task GoToLogin()
        {
            //await _navigationService.Navigate<LoginViewModel>();
        }

        private async Task GoToRegister()
        {
            //await _navigationService.Navigate<RegisterUserViewModel>();
        }

        private int _pageIndex;
        public int PageIndex
        {
            get => _pageIndex;
            set => this.RaiseAndSetIfChanged(ref _pageIndex,  value);
        }
    }
}
