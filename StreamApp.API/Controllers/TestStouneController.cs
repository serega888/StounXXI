using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using Microsoft.AspNetCore.Mvc;

namespace StreamApp.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestStouneController : ControllerBase
    {
     //[HttpGet("{data_req}")]
     [HttpGet]
      public IActionResult GetRequest() 
      {
          var request = (HttpWebRequest)WebRequest.Create($"http://www.cbr.ru/scripts/XML_daily.asp?date_req=22.08.2019");
          var response = (HttpWebResponse)request.GetResponse();
          string responseString;
          using (var stream = response.GetResponseStream())
           {
           using (var reader = new StreamReader(stream))
            {
                responseString = reader.ReadToEnd();
            }
             }
        //   var web = new WebClient();
        //   var url = @"http://www.cbr.ru/scripts/XML_daily.asp?date_req=21.08.2019";
        //   var responseString =  web.DownloadString(url);
       //----------------------------------------------------------
        //    My responseTwo = null; 

        //   String aciesresponseString = "<?xml version=\"1.0\" encoding=\"UTF-8\"?><Valute><NumCode>test</NumCode></Valute>";
           
        // //    XmlSerializer serializer = new XmlSerializer(typeof(My));
        // //    using (XmlReader readerTwo = new XmlNodeReader(aciesresponseString)
        // //     {
        // //      responseTwo = (My)serializer.Deserialize(readerTwo);
        // //     }
        //--------------------------------------------------------------------------
          //  My responseTwo ; 
          //  using(TextReader sr = new StringReader(responseString))
          //  {
            
          //    var serializer = new System.Xml.Serialization.XmlSerializer(typeof(My));
          //     responseTwo = (My) serializer.Deserialize(sr);
              
          //   }

          //     return Ok(responseTwo);
        // ----------------------------------------------------------------------------
            XDocument xdoc = XDocument.Parse(responseString);
            var el = xdoc.Element("ValCurs").Elements("Valute");
             string dollar = el.Where(x => x.Attribute("ID").Value == "R01010").Select(x => x.Element("Value").Value).FirstOrDefault();
            string eur = el.Where(x => x.Attribute("ID").Value == "R01239").Select(x => x.Element("Value").Value).FirstOrDefault();
           return Ok(dollar);
      }
       
      

    }

     [System.Xml.Serialization.XmlRoot("ValCurs")]
       public class My{
        public String NumCode;
      }



      
}