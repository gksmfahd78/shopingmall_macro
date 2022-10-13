using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace macro
{
    public interface IAPI
    {
        HtmlAgilityPack.HtmlDocument getHtml(string link);
        string mobile2PCLink(string link);
    }
}
