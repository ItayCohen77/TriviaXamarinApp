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
    public partial class AddQViews : ContentPage
    {
        public AddQViews()
        {
            InitializeComponent();

            TriviaXamarinApp.ViewModels.AddQViewModels addQ = new ViewModels.AddQViewModels();
            this.BindingContext = addQ;
            addQ.Push += (p) => Navigation.PushAsync(p);

            ((NavigationPage)App.Current.MainPage).BarBackgroundColor = Color.FromHex("#33FFAF");
        }
    }
}