using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using ShellFramework.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShellTest.Pages
{
    class EmployeePage : BasePage
    {
        //Initialize Page

        //public EmployeePage(IWebDriver driver)
        //{

        //    PageFactory.InitElements(driver, this);

        //}



        //public EmployeePage(IWebDriver driver) : base(driver)
        //{



        //}







        [FindsBy(How = How.XPath, Using = "//span[contains(.,'LOGIN')]")]

        public IWebElement lnklogin { get; set; }



    }
}
