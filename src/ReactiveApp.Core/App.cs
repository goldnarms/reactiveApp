using MvvmCross.IoC;
using MvvmCross.ViewModels;
using ReactiveApp.Core.ViewModels.Home;
using ReactiveApp.Core.ViewModels.Onboarding;

namespace ReactiveApp.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            RegisterAppStart<OnboardingViewModel>();
        }
    }
}
