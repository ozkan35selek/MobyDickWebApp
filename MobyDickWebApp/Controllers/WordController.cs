using MobyDickWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;

namespace MobyDickWebApp.Controllers
{
    public class WordController : Controller
    {
        // GET: List
        public ActionResult List()
        {
            List<WordModel> words = new List<WordModel>();
            XmlDocument doc = new XmlDocument();
            doc.Load(Server.MapPath("~/XML/mobydickwords.xml"));

            int i = 0;
            foreach (XmlNode node in doc.SelectNodes("/words/word"))
            {
                if (i == 10) break;
                words.Add(new WordModel
                {
                    text = Convert.ToString(node.Attributes[0].Value),
                    count = Convert.ToInt32(node.Attributes[1].Value)
                });
                i++;
            }
             
            return View(words);
        }
          
    }
}