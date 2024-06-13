using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShellFramework.Base
{
   public class Browser
    {

        private readonly IWebDriver _driver;

        public Browser(IWebDriver driver)
        {
            _driver = driver;

        }



        public void GoToUrl(string url)
        {

            DriverContext.Driver.Url = url;
        }




        public BrowserType Type { get; set; }

        public enum BrowserType
        {
        InternetExplorer,
        FireFox,
        Chrome
        
        
        }




    }
}
