using MAUIAppBase.ViewModels;

namespace MAUIAppBase.Views
{
    public partial class ContentPage1 : ContentPage
    {
        public ContentPage1()
        {
            InitializeComponent();            
            this.BindingContext = new CP1VM();               
        }
    }
}
