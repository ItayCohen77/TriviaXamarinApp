using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TriviaXamarinApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterViews : ContentPage
    {
        public RegisterViews()
        {
            InitializeComponent();
            TriviaXamarinApp.ViewModels.RegisterViewModels register = new ViewModels.RegisterViewModels();
            this.BindingContext = register;
            register.Push += (p) => Navigation.PushAsync(p);

            ((NavigationPage)App.Current.MainPage).BarBackgroundColor = Color.FromHex("#33FFAF");
        }       
    }
}