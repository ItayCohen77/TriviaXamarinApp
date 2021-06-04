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
    class AddQViewModels : INotifyPropertyChanged
    {
        public AddQViewModels()
        {
            OtherAnswers = new string[3];
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public event Action<Page> Push;

        private string correctanswer;
        public string CorrectAnswer
        {
            get
            {
                return correctanswer;
            }
            set
            {
                if (correctanswer != value)
                {
                    correctanswer = value;
                    OnPropertyChanged(nameof(CorrectAnswer));
                }
            }
        }

        private string nickname;
        public string NickName
        {
            get
            {
                return nickname;
            }
            set
            {
                if (nickname != value)
                {
                    nickname = value;
                    OnPropertyChanged(nameof(NickName));
                }
            }
        }

        private string qtext;
        public string QText
        {
            get
            {
                return qtext;
            }
            set
            {
                if (qtext != value)
                {
                    qtext = value;
                    OnPropertyChanged(nameof(QText));
                }
            }
        }

        private string[] otheranswers;
        public string[] OtherAnswers
        {
            get
            {
                return otheranswers;
            }
            set
            {
                if (otheranswers != value)
                {
                    otheranswers = value;
                    OnPropertyChanged(nameof(OtherAnswers));
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

        public ICommand AddQCommand => new Command(AddQ);
        private async void AddQ()
        {
            TriviaWebAPIProxy proxy = TriviaWebAPIProxy.CreateProxy();
            AmericanQuestion a = new AmericanQuestion()
            {
                QText = QText,
                CreatorNickName = ((App)App.Current).User.NickName,
                CorrectAnswer = CorrectAnswer,
                OtherAnswers = OtherAnswers
            };

            if(!NotEmpty(a))
            {
                Error = "You cant add empty question, please try again";
            }
            else
            {
                bool b = await proxy.PostNewQuestion(a);
                ((App)App.Current).User.Questions.Add(a);

                Push?.Invoke(new TriviaXamarinApp.Views.TriviaPageViews());
            }            
        }
        private bool NotEmpty(AmericanQuestion q)
        {
            return (q.QText != "" && q.CorrectAnswer != "" && q.OtherAnswers[0] != "" && q.OtherAnswers[1] != ""
                 && q.OtherAnswers[2] != "" && q.CreatorNickName != "");
        }
    }
}
