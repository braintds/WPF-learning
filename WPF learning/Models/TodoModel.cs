using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_learning.Models
{
    class TodoModel : INotifyPropertyChanged
    {
        public DateTime CreationDate { get; set; } = DateTime.Now;
        private bool IsDone;
        private string Text;

        public event PropertyChangedEventHandler PropertyChanged;

        public bool isDone
        {
            get { return this.IsDone; }
            set
            {
                if (this.IsDone == value)
                    return;
                this.IsDone = value;
                OnPropertyChanged("isDone");
            }
        }
        public string text
        {
            get { return this.Text; }
            set
            {

                if (this.Text == value)
                    return;
                this.Text = value;
                OnPropertyChanged("text");
            }
        }
        protected virtual void OnPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}