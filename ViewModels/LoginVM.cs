using MAUIAppBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIAppBase.ViewModels
{    
    public class LoginVM : FunctionModel
    {
        private LoginDBModel LDBM;
        public Command LoginCommand{ get; set; }
        
        public LoginVM()
        {
            LDBM = new LoginDBModel()
            {
                UserName = "",
                Password = ""
            };
            LoginCommand = new Command(LoginButtonClick);
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

        public async void LoginButtonClick()
        {

        }

    }
}
