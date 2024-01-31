using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksProjectZ.A
{
    class TaskModel:INotifyPropertyChanged
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public bool IsPrompty { get; set; }
        //public string Status { get; set; }
        public DateTime CompletionDare { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
