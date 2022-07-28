using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using HtmlAgilityPack;

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
        var url = "https://www.ebay.com/sch/i.html?LH_SALE_CURRENCY=0&_dmd=1&_ex_kw=&_fpos=40219&_fsct=&_fspt=1&_ftrt=901&_ftrv=1&_in_kw=1&_ipg=60&_nkw=ps5&_sabdhi=&_sabdlo=&_sacat=0&_sadis=10&_samihi=&_samilow=&_sofindtype=5&_sop=12&_udhi=&_udlo=&_fosrp=1";

        var httpCLient = new HttpClient();
        var html = await httpCLient.GetStringAsync(url);

        var htmlDocument = new HtmlDocument();
        htmlDocument.LoadHtml(html);

        var ProductsHtml = htmlDocument.DocumentNode.Descendants("ul")
            .Where(node => node.GetAttributeValue("id", "")
            .Equals("ListViewInner")).ToList();

        var ProductListItems = ProductsHtml[0].Descendants("li")
            .Where(node => node.GetAttributeValue("id", "")
            .Contains("item")).ToList();   



            Console.WriteLine();

    }
}

