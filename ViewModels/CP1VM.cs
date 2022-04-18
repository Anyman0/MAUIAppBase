using MAUIAppBase.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIAppBase.ViewModels
{
    public class CP1VM : FunctionModel
    {
        private Model1 model;        
        public CP1VM()
        {
            model = new Model1()
            {
                Id = 0,
                Name = "Name1"
            };
        }   
        public string Name
        {
            get { return model.Name; }
            set 
            { 
                model.Name = value;
                OnPropertyChanged("Name");
                OnPropertyChanged("AllAbove");
            }
        }
        public int Id
        {
            get { return model.Id; }
            set 
            {
                model.Id = value;
                OnPropertyChanged("Id");
                OnPropertyChanged("AllAbove");
            }
        }

        // This gets data from azure backend. Uri example: "https://newapp.azurewebsites.net". api example: "/api/newdatapage".
        public static async void GetData(string uri, string api)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(uri);
            string json = await client.GetStringAsync(api);
            string[] data = JsonConvert.DeserializeObject<string[]>(json);            
        }
       
    }
}
