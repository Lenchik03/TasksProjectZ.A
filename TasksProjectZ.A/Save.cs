using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;

namespace TasksProjectZ.A
{
    public class Save
    {
        public static ObservableCollection<TaskModel> Tasks { get; set; }

        static Save()
        {
            using (FileStream fs = new FileStream("tasks.json", FileMode.OpenOrCreate))
            {
                if (fs.Length > 0)
                    Tasks = JsonSerializer.Deserialize<ObservableCollection<TaskModel>>(fs);
                else
                    Tasks = new ObservableCollection<TaskModel>();
            }
        }

        public static void SaveTask()
        {
            using (FileStream fs = new FileStream("tasks.json", FileMode.OpenOrCreate))
            {
                JsonSerializer.Serialize(fs, Tasks);
            }
        }
    }
}
