using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIAppBase.Models
{
    public class Model1
    {        
        public int Id { get; set; }
        public string Name { get; set; }
        public string AllAbove()
        {
            return $"{Id} {Name}";
        }
    }
}
