using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZarzadzanieZadaniamiDnia.Models
{
    public partial class SingleTask : ObservableObject
    {
        [ObservableProperty]
        private string name, priority;

        [ObservableProperty]
        private bool isCompleted;
    }
}
