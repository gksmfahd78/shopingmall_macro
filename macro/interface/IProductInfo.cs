using System;
using System.Web;
using System.Xml;
using System.Collections.Generic;

namespace macro
{
    interface IProductInfo
    {
        string getPrdNo(string link);
        string getOptionStcNo(HtmlAgilityPack.HtmlDocument doc);
        List<List<string>> productOptionCase1(string api, string productNo);
        string productOptionCase0(string api, string productNo);
        bool productOptionClassification(XmlDocument xml);
        string getProductShortLink(string prdNo, string optionStckNo, int optionStock);
    }
}
