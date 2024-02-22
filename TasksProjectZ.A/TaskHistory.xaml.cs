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
    /// Логика взаимодействия для TaskHistory.xaml
    /// </summary>
    public partial class TaskHistory : Window
    {
        public ObservableCollection<TaskModel> FilterTasks { get; set; }

        private void NewTask_Click(object sender, RoutedEventArgs e)
        {
            NewTask task = new NewTask();
            task.ShowDialog();
        }
        void Signal(string prop) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        public TaskHistory()
        {
            InitializeComponent();
            ViewTasks();
            DataContext = this;
        }
        private void ViewTasks()
        {
            FilterTasks = new ObservableCollection<TaskModel>(Save.Tasks.Where(filterTask => filterTask.Status == Status.Выполнена.ToString() || filterTask.Status == Status.Отклонена.ToString()));
            Signal(nameof(FilterTasks));
        }
        public event PropertyChangedEventHandler? PropertyChanged;
       
    }
}
