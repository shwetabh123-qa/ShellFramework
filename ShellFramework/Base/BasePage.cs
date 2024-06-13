using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShellFramework.Base
{
    public abstract class BasePage
    {
      
        //public BasePage(IWebDriver driver)
        //{

        //    PageFactory.InitElements(driver,this);
        
        //}

        public BasePage()
        {

            PageFactory.InitElements(DriverContext.Driver, this);

        }
    }




}
