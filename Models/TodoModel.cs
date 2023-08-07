using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.Models
{
    class TodoModel
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


    }
}
