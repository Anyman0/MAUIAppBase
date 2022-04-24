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

        private void Switch_Toggled(object sender, ToggledEventArgs e)
        {

        }
    }
}
