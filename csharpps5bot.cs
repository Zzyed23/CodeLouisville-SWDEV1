using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using HtmlAgilityPack;  //using the HTMLagility pack to make our parsing easier
using System.Collections.Generic;
using System.Linq;



namespace PS5bot
{
    class Program
    {

    }
    static void Main(string[] args)
    {
        GetHtmlAsync();
        Console.ReadLine();

    }
    private static async void GetHtmlAsync()
    {
        //URL that we will parese through
        var url = "https://www.ebay.com/sch/i.html?LH_SALE_CURRENCY=0&_dmd=1&_ex_kw=&_fpos=40219&_fsct=&_fspt=1&_ftrt=901&_ftrv=1&_in_kw=1&_ipg=60&_nkw=ps5&_sabdhi=&_sabdlo=&_sacat=0&_sadis=10&_samihi=&_samilow=&_sofindtype=5&_sop=12&_udhi=&_udlo=&_fosrp=1";

        var httpCLient = new HttpClient();
        var html = await httpCLient.GetStringAsync(url);

        var htmlDocument = new HtmlDocument();
        htmlDocument.LoadHtml(html);

        var ProductsHtml = htmlDocument.DocumentNode.Descendants("ul") //looking for unordered lists
            .Where(node => node.GetAttributeValue("id", "") //looking for the token "id"
            .Equals("ListViewInner")).ToList();

        var ProductListItems = ProductsHtml[0].Descendants("li") //looking for the list of products
            .Where(node => node.GetAttributeValue("id", "") //again another id tag
            .Contains("item")).ToList()

        foreach (var Product in ProductListItems) // foreach loop to go through the html and display the contents below
        {
            //will print the product id
            Console.WriteLine(ProductListItems.GetAttributeValue("lisitngid", ""));

            //will print the name of the product
            Console.WriteLine(ProductListItems.Descendants("h3")
            .Where(node => node.GetAttributeValue("class", "")
            .Equals("lvtitle")).FirstOrDefault().InnerText.Trim('\r', '\n', '\t')
            );

            //will print out the price
            Console.WriteLine(ProductListItems.Descendants("li")
            .Where(node => node.GetAttributeValue("class", "")
            .Equals("lvtitle")).FirstOrDefault().InnerText.Trim('\r', '\n', '\t')
            );

            //will print out the URL
            Console.WriteLine(
                ProductListItems.Descendants("a").FirstOrDefault().GetAtttributeValue("href", ""));

            

            Console.WriteLine();
        }

        



            Console.WriteLine();

    }
}

