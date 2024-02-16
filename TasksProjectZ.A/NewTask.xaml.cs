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
        public ObservableCollection<Task> Tasks { get; set; }
        public List<string> Statuses {  get; set; } = new List<string>();
        public NewTask()
        {
            InitializeComponent();
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(task)));
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Tasks = new ObservableCollection<Task>();
            Tasks.Add(new Task());

            using (FileStream fs = new FileStream("tasks.json", FileMode.OpenOrCreate))
            {
                JsonSerializer.Serialize(fs, Tasks);
            }
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }
        Task task = new Task();
        public Task Task { get; set; }
      
        public event PropertyChangedEventHandler? PropertyChanged;
    }

    public class Task
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public bool IsPrompty { get; set; }
        public string Status {  get; set; }
        public DateTime CompletionDare { get; set; }
    }
}
