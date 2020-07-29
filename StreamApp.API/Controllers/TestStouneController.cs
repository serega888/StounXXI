using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using Microsoft.AspNetCore.Mvc;
using StreamApp.API.Data;
using StreamApp.API.Models;

namespace StreamApp.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestStouneController : ControllerBase
    {
        private readonly DataContext _dataContext;
        public TestStouneController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }



        [HttpGet("{datereq}")]
        public IActionResult GetRequest(string datereq)
        {
         // http://localhost:5000/teststoune/21.07.2020
           // string date_req = data_req;
           // var request = (HttpWebRequest)WebRequest.Create($"http://www.cbr.ru/scripts/XML_daily.asp?date_req=" + date_req);
            var request = (HttpWebRequest)WebRequest.Create($"http://www.cbr.ru/scripts/XML_daily.asp?date_req=" + datereq);
            var response = (HttpWebResponse)request.GetResponse();
            string responseString;
            using (var stream = response.GetResponseStream())
            {
                using (var reader = new StreamReader(stream))
                {
                    responseString = reader.ReadToEnd();
                }
            }

            XDocument xdoc = XDocument.Parse(responseString);
            var el = xdoc.Element("ValCurs").Elements("Valute");
            string myValue = el.Where(x => x.Attribute("ID").Value == "R01010").Select(x => x.Element("Value").Value).FirstOrDefault();
            string name = el.Where(x => x.Attribute("ID").Value == "R01010").Select(x => x.Element("CharCode").Value).FirstOrDefault();
            string valuteId = el.Where(x => x.Attribute("ID").Value == "R01010").Select(x => x.Attribute("ID").Value).FirstOrDefault();
            

            var kursValute = new KursValute {
              DateKurs = DateTime.Parse(datereq), Name = "Currency in Rub"
            };
            
            _dataContext.KursValutes.Add(kursValute);
            _dataContext.SaveChanges();
            var myValute = new MyValute {
              Name = name, ValueKurs = myValue, KursValuteId = kursValute.Id, MyValuteId = valuteId
            };
            _dataContext.MyValutes.Add(myValute); 
        
            _dataContext.SaveChanges();

           return Ok(myValue);
        }


        [HttpGet]
        public IActionResult GetRequest()
        {
            string date_req = "28.07.2020";
            var request = (HttpWebRequest)WebRequest.Create($"http://www.cbr.ru/scripts/XML_daily.asp?date_req=" + date_req);
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
            string myValue = el.Where(x => x.Attribute("ID").Value == "R01010").Select(x => x.Element("Value").Value).FirstOrDefault();
            string name = el.Where(x => x.Attribute("ID").Value == "R01010").Select(x => x.Element("CharCode").Value).FirstOrDefault();
            string valuteId = el.Where(x => x.Attribute("ID").Value == "R01010").Select(x => x.Attribute("ID").Value).FirstOrDefault();

            var kursValute = new KursValute {
              DateKurs = DateTime.Parse(date_req), Name = "Currency in Rub"
            };
            
            _dataContext.KursValutes.Add(kursValute);
            _dataContext.SaveChanges();
            var myValute = new MyValute {
              Name = name, ValueKurs = myValue, KursValuteId = kursValute.Id, MyValuteId = valuteId
            };
            _dataContext.MyValutes.Add(myValute); 
        
            _dataContext.SaveChanges();

           return Ok(myValue);
        }



    }

}