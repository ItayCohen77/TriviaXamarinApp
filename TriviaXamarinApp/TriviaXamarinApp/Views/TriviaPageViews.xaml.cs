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
    public partial class TriviaPageViews : ContentPage
    {
        private TriviaXamarinApp.ViewModels.TriviaPageViewModels trivia;
        public TriviaPageViews()
        {
            trivia = new ViewModels.TriviaPageViewModels();
            this.BindingContext = trivia;
            trivia.Push += (p) => Navigation.PushAsync(p);

            trivia.Popup += AlertYesNo;
            trivia.Guest += AlertLogIn;

            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            trivia.IsEnabled = ((App)App.Current).User != null;
        }

        public async Task<bool> AlertYesNo()
        {
            bool answer = await DisplayAlert("Question?", "Would you like to add a question?", "Yes", "No");

            return answer;
        }

        public async Task<bool> AlertLogIn()
        {
            bool guest = await DisplayAlert("Alert", "You must log in to add new Question", "LogIn", "Continue");

            return guest;
        }
    }
}