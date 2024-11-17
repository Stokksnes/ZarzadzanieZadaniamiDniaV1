using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ZarzadzanieZadaniamiDnia.Models;

namespace ZarzadzanieZadaniamiDnia.Json
{
    public static class DeSSerializacja
    {
        public static readonly string filePath = Path.Combine(FileSystem.Current.AppDataDirectory, "singletask.json");

        public static async Task SaveTasksAsync(ObservableCollection<SingleTask> tasks)
        {
            var json = JsonSerializer.Serialize(tasks);
            await File.WriteAllTextAsync(filePath, json);
        }

        public static async Task<ObservableCollection<SingleTask>> LoadTasksAsync()
        {
            if(!File.Exists(filePath))
            {
                return new ObservableCollection<SingleTask>();
            }
            var json = await File.ReadAllTextAsync(filePath);
            return JsonSerializer.Deserialize<ObservableCollection<SingleTask>> (json) ?? new ObservableCollection<SingleTask>();
        }

    }
}
