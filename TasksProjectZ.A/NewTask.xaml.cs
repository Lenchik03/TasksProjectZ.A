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
        private ObservableCollection<TaskModel> Tasks {  get; set; } = new ObservableCollection<TaskModel>();
        //public List<TaskModel> Statuses {  get; set; }
        public NewTask()
        {
            InitializeComponent();
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(task)));
            //Statuses = new List<TaskModel>();
            //Statuses.Add(new TaskModel
            //{
            //    Status = "Ожидает"
            //});

            //Statuses.Add(new TaskModel
            //{
            //    Status = "В работе"
            //});
        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            
            Tasks.Add(new TaskModel{
                Title = "dfgsdf",
                Description = "dvasdv",
                IsPrompty = true
            });

            using (FileStream fs = new FileStream("tasks.json", FileMode.OpenOrCreate))
            {
                JsonSerializer.Serialize(fs, Tasks);
            }
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            NewTask newTask = new NewTask();
            newTask.Close();
        }
        TaskModel task = new TaskModel();
        //public TaskModel Newtask { get; set; }
      
        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
