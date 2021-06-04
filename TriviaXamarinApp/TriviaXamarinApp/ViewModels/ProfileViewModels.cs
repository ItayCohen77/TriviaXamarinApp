using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using TriviaXamarinApp.Services;
using TriviaXamarinApp.Views;
using System.Threading.Tasks;
using TriviaXamarinApp.Models;

namespace TriviaXamarinApp.ViewModels
{
    class ProfileViewModels : INotifyPropertyChanged
    {
        public ProfileViewModels()
        {
            NickName = ((App)App.Current).User.NickName;
            Email = ((App)App.Current).User.Email;
            Pass = ((App)App.Current).User.Password;
            if(((App)App.Current).User.Questions == null)
            {
                ((App)App.Current).User.Questions =  new List<AmericanQuestion>();
                Questions = new ObservableCollection<AmericanQuestion>(((App)App.Current).User.Questions);
            }
            else
            {
                Questions = new ObservableCollection<AmericanQuestion>(((App)App.Current).User.Questions);
            }          
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public event Action<Page> Push;

        private string nickname;
        public string NickName
        {
            get
            {
                return this.nickname;
            }
            set
            {
                if (this.nickname != value)
                {
                    this.nickname = value;
                    OnPropertyChanged(nameof(NickName));
                }
            }
        }

        private string email;
        public string Email
        {
            get
            {
                return this.email;
            }
            set
            {
                if (this.email != value)
                {
                    this.email = value;
                    OnPropertyChanged(nameof(Email));
                }
            }
        }

        private string pass;
        public string Pass
        {
            get
            {
                return this.pass;
            }
            set
            {
                if (this.pass != value)
                {
                    this.pass = value;
                    OnPropertyChanged(nameof(Pass));
                }
            }
        }
        public ICommand EditCommand => new Command<AmericanQuestion>(Edit);
        private void Edit(AmericanQuestion q)
        {
            Push?.Invoke(new TriviaXamarinApp.Views.EditQuestionViews(q));
        }

        public ICommand LogOutCommand => new Command(LogOut);
        private void LogOut()
        {
            ((App)App.Current).User = null;
            Push?.Invoke(new TriviaXamarinApp.Views.MainPage());
        }

        public ICommand DeleteCommand => new Command<AmericanQuestion>(Delete);
        private async void Delete(AmericanQuestion q)
        {
            TriviaWebAPIProxy proxy = TriviaWebAPIProxy.CreateProxy();
            bool worked = await proxy.DeleteQuestion(q);
            if (worked)
            {
                ((App)App.Current).User.Questions.Remove(q);
                Questions.Remove(q);
            }              
        }

        public ObservableCollection<AmericanQuestion> Questions { get; set; }      
        public ICommand DeleteQuestionCommand => new Command<AmericanQuestion>(DeleteQuestion);
        private async void DeleteQuestion(AmericanQuestion a)
        {
            TriviaWebAPIProxy proxy = TriviaWebAPIProxy.CreateProxy();
            await proxy.DeleteQuestion(a);
            Questions.Remove(a);
        }
    }
}
