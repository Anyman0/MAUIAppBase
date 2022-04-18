using MAUIAppBase.ViewModels;

namespace MAUIAppBase.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            BindingContext = new LoginVM();
        }
    }
}
