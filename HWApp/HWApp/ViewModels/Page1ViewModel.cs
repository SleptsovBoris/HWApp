using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using HWApp.Pages;
using System.Windows.Input;
using System.Runtime.CompilerServices;

namespace HWApp.ViewModels
{
    public class Root
    {
        public int userId { get; set; }
        public int id { get; set; }
        public string title { get; set; }
    }
    public class Page1ViewModel:INotifyPropertyChanged
    {
        private const string url = "https://jsonplaceholder.typicode.com/albums";
        private HttpClient _Client = new HttpClient();
        private ObservableCollection<Root> Groot;
        public ObservableCollection<Root> GRoot
        {
            get => Groot;
            set 
            { 
                Groot = value;
                OnPropertyChanged();
            }
        }

        private string SomeText = "Привет, я работаю!";

        public event PropertyChangedEventHandler PropertyChanged;

        public string Text
        {
            get => SomeText;
            set
            {
                SomeText = value;
                OnPropertyChanged();
            }
        }
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public async Task Output()
        {
            var content = await _Client.GetStringAsync(url);
            var root = JsonConvert.DeserializeObject<List<Root>>(content);
            GRoot = new ObservableCollection<Root>(root);
        }
        public async Task ChangeLabel()
        {
            await Task.Delay(1000);
            if (Text== "Привет, я работаю!")
            {
                Text = "Я изменился";
            }
            else
            {
                Text = "Привет, я работаю!";
            }
        }
        public ICommand LoadData => new Command(async value =>
        {
            await Output();
        });
        public ICommand ButtonCommand => new Command(async value =>
        {
            await ChangeLabel();
        });
    }
}
