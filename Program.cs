using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;


namespace Ebaybot
{
    class Bot
    {
        static void Main(string[] args)
        {
            HtmlAgilityPack.HtmlWeb website = new HtmlAgilityPack.HtmlWeb();
            HtmlAgilityPack.HtmlDocument document = website.Load("https://www.ebay.com/sch/i.html?_from=R40&_trksid=p2380057.m570.l1313&_nkw=yeezy&_sacat=0");
            var ebayList = document.DocumentNode.SelectNodes("//div[@class ='srp-river-results']").ToList();
                foreach (var content in ebayList)
            {
                Console.WriteLine(content.InnerHtml);
          
            }
            Console.Read();


                }
    }
}