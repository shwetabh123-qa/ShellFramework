using System;
using System.Configuration;
using System.Xml.XPath;
using System.IO;

namespace ShellFramework.Config
{
    public class ConfigReader
    {



        //public static string InitializeTest()
        //{

        //    return ConfigurationManager.AppSettings["AUT"].ToString();

        //}



        public static string logFilePath()
        {
            return ConfigurationManager.AppSettings["logFilePath"].ToString();

        }



        public static string TCESReportingserverName()
        {
            return ConfigurationManager.AppSettings["TCESReportingserverName"].ToString();

        }

        public static string TCESReportingDB()
        {
            return ConfigurationManager.AppSettings["TCESReportingDB"].ToString();

        }
        public static string userName()
        {
            return ConfigurationManager.AppSettings["userName"].ToString();

        }
        public static string password()
        {
            return ConfigurationManager.AppSettings["password"].ToString();

        }



        public static string GetUrlone()
        {
            return ConfigurationManager.AppSettings["Url1"].ToString();

        }

        public static string GetUrltwo()
        {
            return ConfigurationManager.AppSettings["Url2"].ToString();

        }

        public static string GetUrlthree()
        {
            return ConfigurationManager.AppSettings["Url3"].ToString();

        }

        public static string GetUrlfour()
        {
            return ConfigurationManager.AppSettings["Url4"].ToString();

        }
        public static string GetUrlfive()
        {
            return ConfigurationManager.AppSettings["Url5"].ToString();

        }



        public static string GetUrlsix()
        {
            return ConfigurationManager.AppSettings["Url6"].ToString();

        }




        //public BrowserType? GetBrowser()
        //{
        //    string browser = ConfigurationManager.AppSettings["Browser"].ToString();
        //    try
        //    {
        //        return (BrowserType)Enum.Parse(typeof(BrowserType), browser);
        //    }
        //    catch (Exception)
        //    {
        //        return null;
        //    }
        //}



        public static string GetBrowser()
        {
            return  ConfigurationManager.AppSettings["Browser"].ToString();


            //try
            //{
            //    return (BrowserType)Enum.Parse(typeof(BrowserType), browser);
            //}
            //catch (Exception)
            //{
            //    return null;
            //}
        }



        public static int GetElementLoadTimeOut()
        {
            string timeout = ConfigurationManager.AppSettings["ElementLoadTimeout"].ToString();
            if (timeout == null)
                return 30;
            return Convert.ToInt32(timeout);

        }

        public static int GetPageLoadTimeOut()
        {
            string timeout = ConfigurationManager.AppSettings["PageLoadTimeout"].ToString();
            if (timeout == null)
                return 30;
            return Convert.ToInt32(timeout);
        }

        public static string GetPassword()
        {
            return ConfigurationManager.AppSettings["Password"].ToString();
        }

        public static string GetUsername()
        {
            return ConfigurationManager.AppSettings["Username"].ToString();
        }



        public static void SetFrameworkSettings()
        {

            XPathItem aut;
            XPathItem testtype;
            XPathItem islog;
            XPathItem isreport;
            XPathItem buildname;
            XPathItem logPath;

            string strFilename = Environment.CurrentDirectory.ToString() + "\\Config\\GlobalConfig.xml";
            FileStream stream = new FileStream(strFilename, FileMode.Open);
            XPathDocument document = new XPathDocument(stream);
            XPathNavigator navigator = document.CreateNavigator();

            //Get XML Details and pass it in XPathItem type variables
            aut = navigator.SelectSingleNode("EAAutoFramework/RunSettings/AUT");
            buildname = navigator.SelectSingleNode("EAAutoFramework/RunSettings/BuildName");
            testtype = navigator.SelectSingleNode("EAAutoFramework/RunSettings/TestType");
            islog = navigator.SelectSingleNode("EAAutoFramework/RunSettings/IsLog");
            isreport = navigator.SelectSingleNode("EAAutoFramework/RunSettings/IsReport");
            logPath = navigator.SelectSingleNode("EAAutoFramework/RunSettings/LogPath");

            //Set XML Details in the property to be used accross framework
            Settings.AUT = aut.Value.ToString();
            Settings.BuildName = buildname.Value.ToString();
            Settings.TestType = testtype.Value.ToString();
            Settings.IsLog = islog.Value.ToString();
            Settings.IsReporting = isreport.Value.ToString();
            Settings.LogPath = logPath.Value.ToString();
        }

    }
}
