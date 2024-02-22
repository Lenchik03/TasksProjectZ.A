using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TasksProjectZ.A
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();

          
            ViewTasks();
            DataContext = this;


        }

        private void ViewTasks()
        {
            FilterTasks = new ObservableCollection<TaskModel>(Save.Tasks.Where(filterTask => filterTask.Status == Status.В_ожидании.ToString()));
            Signal(nameof(FilterTasks));
        }

        public ObservableCollection<TaskModel> FilterTasks { get; set; }

        public TaskModel SelectedTask { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
        void Signal(string prop) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));

        private void NewTask_Click(object sender, RoutedEventArgs e)
        {
            NewTask task = new NewTask();
            task.ShowDialog();
            ViewTasks();
        }

        private void TaskHistory_Click(object sender, RoutedEventArgs e)
        {
            TaskHistory history = new TaskHistory();
            history.Show();
        }

        private void ComplateClick_Button(object sender, RoutedEventArgs e)
        {
            var selectedTask = SelectedTask;
            if (selectedTask != null)
            {
                selectedTask.Status = Status.Выполнена.ToString();
                selectedTask.CompletionDare = DateTime.Today;
                Save.SaveTask();
                ViewTasks();
            }
        }

        private void Click_Button(object sender, RoutedEventArgs e)
        {
            var selectedTask = SelectedTask;
            if (selectedTask != null)
            {
                selectedTask.Status = Status.Отклонена.ToString();
                selectedTask.CompletionDare = DateTime.Today;
                Save.SaveTask();
                ViewTasks();
            }
        }
    }
}
