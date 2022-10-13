using System;
using System.Xml;
using System.Collections.Generic;

namespace macro
{
    class ProductInfoService
    {
        /* Link prameter start */
        public static string ROOTURL = "https://buy.m.11st.co.kr//MW/Order/orderBasicFirstStep.tmall?&";
        public static string INCOMMINGCODE = "incommingCode=01";
        public static string PRDAPPMTDBDLBCD = "prdAppmtDbDlvCd=01";
        public static string MOBILEYN = "mobileYn=N";
        public static string BCKTEXYN = "bcktExYn=N";
        private static string OPTIONPRC = "optionPrc=0";
        public static string optionStock = "";
        /* Link prameter end */

        private XmlDocument xml = null;
        //html get optionStckNo
        //parameter in ParsingService class getHtml fucntion use
        public string getOptionStcNo(HtmlAgilityPack.HtmlDocument doc)
        {
            try
            {
                //html in body tag search
                HtmlAgilityPack.HtmlNode body = doc.DocumentNode.SelectSingleNode("//body");
                //html body tag in input search
                HtmlAgilityPack.HtmlNode osn = doc.DocumentNode.SelectSingleNode("//*[@id='layBodyWrap']/div/div[1]/div[2]/div/div[2]/form[2]/input[27]");
                //input attribute value get 
                string optionStckNo = osn.GetAttributeValue("value", "");
                //optionStckNo return
                return optionStckNo;
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public List<string> getOptionStcNoList(HtmlAgilityPack.HtmlDocument doc)
        {
            List<string> list = new List<string>();

            try
            {
                HtmlAgilityPack.HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes("//*[@id='optlst_0']/li");

                foreach (HtmlAgilityPack.HtmlNode node in nodes)
                {
                    list.Add(node.SelectSingleNode("a").GetAttributeValue("data-stockno", ""));
                }

                return list;
            } 
            
            catch(Exception ex)
            {
                Console.WriteLine("error : " + ex);
                return null;
            }
        }

        /*  product option search and get optPrdNm start */
        //product setting option one more...
        public List<List<string>> productOptionCase1(string api, string productNo)
        {
            List<List<string>> opt = new List<List<string>>();

            string url = "http://openapi.11st.co.kr/openapi/OpenApiService.tmall?key=" + api + "&apiCode=ProductInfo&productCode=" + productNo + "&option=PdOption";
            xml.Load(url);

            try
            {

                //value tag search and input list 
                XmlNodeList node = xml.GetElementsByTagName("Value");

                for (int i = 0; i < node.Count; i++)
                {
                    opt[i].Add(node[i].SelectSingleNode("Order").InnerText);
                    opt[i].Add(node[i].SelectSingleNode("ValueName").InnerText);
                    //example
                    //{no, name}, {no, name} ...
                }

                return opt;
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        //product setting option zero
        public string productOptionCase0(string api, string productNo)
        {
            string opt;
            string url = "http://openapi.11st.co.kr/openapi/OpenApiService.tmall?key=" + api + "&apiCode=ProductInfo&productCode=" + productNo + "&option=PdOption";
            xml.Load(url);

            try
            {
                XmlNode node = xml.SelectSingleNode("ProductName");
                opt = node.InnerText;
                return opt;
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public bool productBuyState(HtmlAgilityPack.HtmlDocument doc)
        {

            try
            {
                HtmlAgilityPack.HtmlNode buyBtn = doc.DocumentNode.SelectSingleNode("/html/body");

                if (buyBtn.InnerText.Contains("구매하기")) 
                    return true;
                else
                    return false;
            } 
            
            catch (Exception ex)
            {
                Console.WriteLine("productBuyState err : " + ex);
                return false;
            }
        }

        public string productBuyPrice(HtmlAgilityPack.HtmlDocument doc)
        {

            try
            {
                HtmlAgilityPack.HtmlNode price = doc.DocumentNode.SelectSingleNode("//*[@id='layBodyWrap']/div/div[1]/div/div/div[1]/div[2]/div[2]/div[4]/div[1]/ul/li/dl[1]/dd/strong/span[1]");
                string value = price.InnerText.Replace(",", "");
                return value;
            }

            catch (Exception ex)
            {
                Console.WriteLine("productBuyState err : " + ex);
                return null;
            }
        }

        /*  product option search and get optPrdNm end */

        //product buy page shortcut
        public string getProductShortLink(string prdNo, string optionStckNo, int optionStock)
        {
            string str = ROOTURL + "prdNo=" + prdNo + "&" + INCOMMINGCODE + "&" + PRDAPPMTDBDLBCD + "&"
                       + MOBILEYN + "&" + BCKTEXYN + "&" + "optionStckNo=" + optionStckNo + "&"
                       + OPTIONPRC + "&" + "optionStock=" + optionStock;
            return str;
        }
    }
}
