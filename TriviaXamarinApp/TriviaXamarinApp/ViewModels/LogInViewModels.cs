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
    class LogInViewModels : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public event Action<Page> Push;
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

        public ICommand LogInCommand => new Command(LogIn);
        private async void LogIn()
        {
            TriviaWebAPIProxy proxy = TriviaWebAPIProxy.CreateProxy();
            User u = await proxy.LoginAsync(Email, Pass);
            
            if (u != null)
            {
                ((App)App.Current).User = u;
                Push?.Invoke(new TriviaPageViews());
            }
            else
                Error = "Password or email does not match";
        }
        public ICommand RegisterCommand => new Command(Register);
        private void Register()
        {
            Push?.Invoke(new TriviaXamarinApp.Views.RegisterViews());
        }
    }
}
