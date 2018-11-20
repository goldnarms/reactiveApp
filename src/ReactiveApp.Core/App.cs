using MvvmCross.IoC;
using MvvmCross.ViewModels;
using ReactiveApp.Core.ViewModels.Home;

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

            RegisterAppStart<HomeViewModel>();
        }
    }
}
