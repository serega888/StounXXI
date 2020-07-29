using System;
using System.Collections.Generic;

namespace StreamApp.API.Models
{
    public class KursValute
    {
        public int Id {get;set;}
        public DateTime DateKurs {get;set;}
        public string Name {get; set;}
        public virtual ICollection<MyValute> MyValutes {get;set;}
        
    }
}