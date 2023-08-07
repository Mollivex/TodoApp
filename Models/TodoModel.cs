using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.Models
{
    class TodoModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Current ToDo row creation date
        /// </summary>
        public DateTime CreationDate { get; set; } = DateTime.Now;

        private bool _isDone; 
        private string _text;

        public bool isDone
        {
            get { return _isDone; }
            set { _isDone = value; }
        }
        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Informs user about changing data
        /// </summary>
        /// <param name="propertyName"></param>
        protected virtual void OnPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this._text, new PropertyChangedEventArgs(propertyName));
        }


    }
}
