using MAUIAppBase.Data;
using MAUIAppBase.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIAppBase.ViewModels
{    
    public class LoginVM : FunctionModel
    {
        private LoginDBModel LDBM;
        private LoginDB LDB;
        public List<string> LoginData;
        private Color BackgroundClr = (Color)AppResource("NotActiveRed");
                            
        public Command LoginCommand{ get; set; }
        
        public LoginVM()
        {
            LDBM = new LoginDBModel()
            {
                UserName = "",
                Password = "",
                RememberMe = false
            };
            LoginCommand = new Command(LoginButtonClick);            
            LoginData = new List<string>();            
        }

        public Color BackgroundColorChange
        {
            get { return BackgroundClr; }
            set
            {
                if(value != BackgroundClr)
                {
                    BackgroundClr = value;                    
                }
            }
        }
            
        

        public bool RememberMe
        {
            get
            {
                return LDBM.RememberMe;
            }
            set
            {
                LDBM.RememberMe = value;
                if (value == true) BackgroundClr = (Color)AppResource("ActiveGreen");
                else BackgroundClr = (Color)AppResource("NotActiveRed");
                OnPropertyChanged("BackgroundColorChange");
                OnPropertyChanged("RememberMe");
            }
        }

        public string UserName
        {
            get
            {
                return LDBM.UserName;
            }
            set
            {
                LDBM.UserName = value;
                OnPropertyChanged("UserName");                
            }
        }

        public string Password
        {
            get { return LDBM.Password; }
            set
            {
                LDBM.Password = value;
                OnPropertyChanged("Password");
            }
        }

        // This gets data from azure backend. Uri example: "https://newapp.azurewebsites.net". api example: "/api/newdatapage".
        public async void GetData(string uri, string api)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(uri);
            string json = await client.GetStringAsync(api);
            string[] data = JsonConvert.DeserializeObject<string[]>(json);
            foreach(var item in data)
            {
                LoginData.Add(item);                
            }
        }

        public async void LoginButtonClick(object obj)
        {              
            if(LDBM.UserName == LoginData[0] && LDBM.Password == LoginData[1])
            {
                // Log in and remember login
                if(LDBM.RememberMe)
                {
                    await LDB.SaveItemSync(LDBM);
                }
                else // Log in but dont save login info
                {
                    
                }
            }            
        }

    }
}
