using System.Net;
using System.Web;

namespace macro
{
    public class ParsingService
    {
        //get product pc html or mobile html
        public HtmlAgilityPack.HtmlDocument getHtml(string link)
        {
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            HtmlAgilityPack.HtmlWeb web = new HtmlAgilityPack.HtmlWeb();
            doc = web.Load(link);

            return doc;
        }

        //mobile link convert pc link
        public string mobile2PCLink(string link)
        {
            string str = link.Replace("m.", "").Replace("/m", "");
            return str;
        }

        //pc link convert mobile pc link
        public string pC2MobileLink(string link)
        {
            string str = link.Replace("www", "m").Replace("products/", "products/m/");
            return str;
        }
    }
}
