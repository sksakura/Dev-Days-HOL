using MyEvents.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MyEvents.ViewModels
{
    public class SpeakersViewModel : ViewModelBase
    {
        public ObservableCollection<Speaker> Speakers { get; set; }
        public SpeakersViewModel()
        {
            Speakers = new ObservableCollection<Speaker>();
            Title = "Speakers";
            GetSpeakersCommand = new Command(
                async () => await GetSpeakers(),
                () => !IsBusy);
        }

        public Command GetSpeakersCommand { get; set; }

        private async Task GetSpeakers()
        {
            if (IsBusy)
                return;
            Exception error = null;
            try
            {
                IsBusy = true;
                using (var client = new HttpClient())
                {
                    //grab json from server
                    var json = await client.GetStringAsync("https://demo4404797.mockable.io/speakers");
                    var items = JsonConvert.DeserializeObject<List<Speaker>>(json);
                    Speakers.Clear();
                    foreach (var item in items)
                        Speakers.Add(item);
                }

            }
            catch (Exception ex)
            {
                error = ex;
            }
            finally
            {
                IsBusy = false;
            }
            if (error != null)
                await Application.Current.MainPage.DisplayAlert("Error!", error.Message, "OK");
        }
    }
}
