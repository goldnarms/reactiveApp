using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;
using ReactiveApp.Core.ViewModels.Onboarding;
using Xamarin.Forms.Xaml;

namespace ReactiveApp.UI.Pages.Onboarding
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	[MvxContentPagePresentation(WrapInNavigationPage = false)]
    public partial class OnboardingPage : MvxContentPage<OnboardingViewModel>
	{
		public OnboardingPage ()
		{
			InitializeComponent ();
		}
	}
}
