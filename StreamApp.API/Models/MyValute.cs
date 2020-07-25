using System.Collections.Generic;

namespace StreamApp.API.Models
{
    public class MyValute
    {
        public int Id {get;set;}
        public int KursValuteId { get; set; }
        public string MyValuteId {get;set;}
        public string Name {get;set;}
        public KursValute KursValute { get; set; }   
        
    }
}