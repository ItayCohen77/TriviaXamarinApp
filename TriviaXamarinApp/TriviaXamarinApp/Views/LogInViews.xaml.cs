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
    public partial class LogIn : ContentPage
    {
        public LogIn()
        {
            InitializeComponent();
            TriviaXamarinApp.ViewModels.LogInViewModels logIn = new ViewModels.LogInViewModels();
            this.BindingContext = logIn;
            logIn.Push += (p) => Navigation.PushAsync(p);

            ((NavigationPage)App.Current.MainPage).BarBackgroundColor = Color.FromHex("#33FFAF");
        }
    }
}