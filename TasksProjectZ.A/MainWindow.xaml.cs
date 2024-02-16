using System;
using System.Collections.Generic;
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
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            NewTask newTask = new NewTask();
            var f = new FileInfo("tasks.json");
            if (f.Exists && f.Length > 0)
            {
                using (FileStream fs = new FileStream("tasks.json", FileMode.OpenOrCreate))
                {
                    newTask.Task = JsonSerializer.Deserialize<Task>(fs);
                }
            }
            else
                newTask.Task = new Task();


        }
    }
}
