using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShellFramework.Base
{
   public static  class DriverContext
    {

        private static  IWebDriver driver;

        public static IWebDriver Driver

        {

            get
            {
                return driver;

            }
            set
            {

                driver = value;

            }

        }




        public static Browser Browser { get; set; }



    }
}
