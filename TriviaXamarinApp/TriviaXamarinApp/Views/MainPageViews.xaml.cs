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
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            TriviaXamarinApp.ViewModels.MainPageViewModels mainPage = new ViewModels.MainPageViewModels();
            this.BindingContext = mainPage;
            mainPage.Push += (p) => Navigation.PushAsync(p);

        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            ((NavigationPage)App.Current.MainPage).BarBackgroundColor = Color.FromHex("#33FFAF");
        }
    }
}