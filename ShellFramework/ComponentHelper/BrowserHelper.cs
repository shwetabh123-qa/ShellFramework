using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;
//using log4net;
using OpenQA.Selenium;

using ShellFramework.Base;

namespace SeleniumWebdriver.ComponentHelper
{
    public static class BrowserHelper
    {
       // private static readonly ILog Logger = Log4NetHelper.GetXmlLogger(typeof(BrowserHelper));
        public static void BrowserMaximize()
        {
            DriverContext.Driver.Manage().Window.Maximize();
       //     Logger.Info(" Browser Maximize ");
        }

        public static void GoBack()
        {
            DriverContext.Driver.Navigate().Back();

        }

        public static void Forward()
        {
            DriverContext.Driver.Navigate().Forward();
        }

        public static void RefreshPage()
        {
            DriverContext.Driver.Navigate().Refresh();
        }

        public static void SwitchToWindow(int index = 0)
        {
            Thread.Sleep(1000);
            ReadOnlyCollection<string> windows = DriverContext.Driver.WindowHandles;

            if ((windows.Count - 1) < index)
            {
                throw new NoSuchWindowException("Invalid Browser Window Index" + index);
            }


            DriverContext.Driver.SwitchTo().Window(windows[index]);
            Thread.Sleep(1000);
            BrowserMaximize();

        }


        public static void SwitchToParent()
        {
            var windowids = DriverContext.Driver.WindowHandles;


            for (int i = windowids.Count - 1; i > 0;)
            {
                DriverContext.Driver.Close();
                i = i - 1;
                Thread.Sleep(2000);
                DriverContext.Driver.SwitchTo().Window(windowids[i]);
            }
            DriverContext.Driver.SwitchTo().Window(windowids[0]);

        }

        public static void SwitchToFrame(By locator)
        {
            DriverContext.Driver.SwitchTo().Frame(DriverContext.Driver.FindElement(locator));
        }
    }
}
