using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using TriviaXamarinApp.Views;

namespace TriviaXamarinApp.ViewModels
{
    class MainPageViewModels : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public event Action<Page> Push;
        private string text;
        public string Text
        {
            get
            {
                return this.text;
            }
            set
            {
                if (this.text != value)
                {
                    this.text = value;
                    OnPropertyChanged(nameof(Text));
                }
            }
        }
        public ICommand LogInCommand => new Command(LogIn);
        private void LogIn()
        {
            Push?.Invoke(new TriviaXamarinApp.Views.LogIn());
        }

        public ICommand RegisterCommand => new Command(Register);
        private void Register()
        {
            Push?.Invoke(new TriviaXamarinApp.Views.RegisterViews());
        }

        public ICommand GuestCommand => new Command(Guest);
        private void Guest()
        {
            Push?.Invoke(new TriviaXamarinApp.Views.TriviaPageViews());
        }
    }
}
