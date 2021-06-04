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
    class RegisterViewModels : INotifyPropertyChanged
    {
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
        private string error;
        public string Error
        {
            get
            {
                return error;
            }
            set
            {
                if (error != value)
                {
                    error = value;
                    OnPropertyChanged(nameof(Error));
                }
            }
        }

        public ICommand RegisterCommand => new Command(Register);
        private async void Register()
        {
            TriviaWebAPIProxy proxy = TriviaWebAPIProxy.CreateProxy();
            User u = new User()
            {
                Email = Email,
                Password = Pass,
                NickName = NickName
            };
            bool b =  await proxy.RegisterUser(u);

            if(b)
            {
                ((App)App.Current).User = u;
                Push?.Invoke(new TriviaPageViews());
            }
            else
                Error = "Nickname or email exist";
        }
    }
}
