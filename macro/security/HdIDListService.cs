using System.Net;
using System.Management;
using System.Collections.Generic;
using System.Net.NetworkInformation;

namespace macro
{
    class HdIDListService
    {
        public List<string> getCPUIDList() {
            List<string> list = new List<string>();
            string query = "Select * FROM Win32_Processor";
            ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher(query);
            foreach (ManagementObject managementObject in managementObjectSearcher.Get()) {
                list.Add(managementObject.GetPropertyValue("ProcessorId").ToString()); 
            }
            return list; 
        }

        public string getCPUIDList2str(List<string> list)
        {
            HdIDListService cpuIDListService = new HdIDListService();
            List<string> vs = cpuIDListService.getCPUIDList();
            string str = "";
            foreach (string c in vs)
            {
                str += c;
            }
            return str;
        }

        public string getLenMACAddress() 
        {
            NetworkInterface[] networkInterfaceArray = NetworkInterface.GetAllNetworkInterfaces(); 
            foreach (NetworkInterface networkInterface in networkInterfaceArray) {
                if (networkInterface.OperationalStatus == OperationalStatus.Up) {
                    PhysicalAddress physicalAddress = networkInterface.GetPhysicalAddress();
                    return physicalAddress.ToString(); 
                } 
            } 
            return null;
        }

        public string getGpuName()
        {
            string gpuName;

            using (ManagementObjectSearcher mos = new ManagementObjectSearcher("Select * From Win32_DisplayConfiguration"))
            {
                foreach (ManagementObject moj in mos.Get())
                {
                    gpuName = moj["Description"].ToString();
                    return gpuName;
                }
            }
            return null;
        }

        public string getHostIP()
        {
            string link = "https://ipipip.kr/";
            ParsingService parsingService = new ParsingService();
            HtmlAgilityPack.HtmlDocument doc = parsingService.getHtml(link);
            string hostIP = doc.DocumentNode.SelectSingleNode("//*[@id='ip_data']").InnerText;
            return hostIP;
        }
    }
}
