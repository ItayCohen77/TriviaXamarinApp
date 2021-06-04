using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TriviaXamarinApp.ViewModels;
using TriviaXamarinApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TriviaXamarinApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditQuestionViews : ContentPage
    {
        public EditQuestionViews(AmericanQuestion q)
        {
            EditQuestionViewModels edit = new EditQuestionViewModels(q);
            this.BindingContext = edit;

            edit.Push += (p) => Navigation.PushAsync(p);

            InitializeComponent();
        }
    }
}