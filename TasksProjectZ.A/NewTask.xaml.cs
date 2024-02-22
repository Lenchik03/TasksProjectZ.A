using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TasksProjectZ.A
{
    /// <summary>
    /// Логика взаимодействия для NewTask.xaml
    /// </summary>
    public partial class NewTask : Window, INotifyPropertyChanged
    {
        public TaskModel task { get; set; } = new TaskModel();
        //public List<TaskModel> Statuses {  get; set; }
        public event PropertyChangedEventHandler? PropertyChanged;
        public NewTask()
        {
            InitializeComponent();
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(task)));
            DataContext = this;
            task.Status = Status.В_ожидании.ToString();
        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {

            Save.Tasks.Add(task);
            Save.SaveTask();

            Close();
        }
        //public TaskModel Newtask { get; set; }

    }
}
