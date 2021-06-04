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
    public partial class ProfileViews : ContentPage
    {
        public ProfileViews()
        {
            InitializeComponent();

            TriviaXamarinApp.ViewModels.ProfileViewModels profile = new ViewModels.ProfileViewModels();
            this.BindingContext = profile;
            profile.Push += (p) => Navigation.PushAsync(p);
        }
    }
}