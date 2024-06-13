using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using ShellFramework.Base;
using ShellTest.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShellTest.Pages
{
    class LoginPage:BasePage
    {


           public IWebDriver driver;



        //*********************using Pagefactory Pattern ***************************//


        //Initialize Page


        //public LoginPage(IWebDriver driver)
        //{

        //   PageFactory.InitElements(driver, this);
         
        //}


        //public LoginPage(IWebDriver driver):base (driver)
        //{

            

        //}





        [FindsBy(How = How.XPath, Using = "//span[contains(.,'LOGIN')]")]

        public IWebElement lnklogin { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='side-user-login']")]

        public IWebElement txtUserName { get; set; }


        [FindsBy(How = How.XPath, Using = "//*[@id='sidebar-user-pass']")]

        public IWebElement txtPassword { get; set; }


        [FindsBy(How = How.XPath, Using = "//*[@id='sidebar-wp-submit']")]


        public IWebElement btnLogin { get; set; }

        [FindsBy(How = How.XPath, Using = "(//a[contains(.,'Laptops & Notebooks')])[1]")]


        public IWebElement LaptopsNotebooks { get; set; }


        //********************Pagefactory Pattern*********************//




        //****************************Second approach without pagefactory *****************************//

        By lnklogin1;

        By txtUserName1;

        By txtPassword1;

        By btnLogin1;
        By Radio;
        By Checkbox;

        By Name;

        By Dropdown;
        By Drag;

        By Drop;


        public LoginPage(IWebDriver driver)
        {

            this.driver = driver;



            this.lnklogin1 = By.XPath("//span[contains(.,'LOGIN')]");

            this.txtUserName1 = By.XPath("//*[@id='side-user-login']");

            this.txtPassword1 = By.XPath("//*[@id='sidebar-user-pass']");

            this.btnLogin1 = By.XPath("//*[@id='sidebar-wp-submit']");

            this.Radio = By.XPath("//label[contains(.,'London')]//span[1]");


            this.Checkbox = By.XPath("//label[contains(.,'5 Star')]//span[1]");

            this.Name = By.XPath("//*[@id='userName']");



            this.Dropdown = By.XPath("//select[@id='testingDropdown']");


            this.Drag = By.XPath("//*[@id='draggable']");


            this.Drop= By.XPath("//*[@id='droppable']");



        }





        //public void Loginmethod( String userName, String password)
        //{



        //    driver.FindElement(lnklogin).Click();


        //    driver.FindElement(txtUserName).SendKeys(userName);
        //    driver.FindElement(txtPassword).SendKeys(password);

        //    driver.FindElement(btnLogin).Click();


        //}

        //**************using without pagefactory *******************//

        public void Loginmethod(String userName, String password)
        {

          
                GenericHelper.GetElement(lnklogin1).Click();

            GenericHelper.WaitforElement( lnklogin1,180);

            GenericHelper.GetElement(txtUserName1).SendKeys(userName);

            GenericHelper.WaitforElement( txtUserName1, 180);


            GenericHelper.GetElement(txtPassword1).SendKeys(password);

            GenericHelper.WaitforElement(txtPassword1, 120);

            GenericHelper.GetElement(btnLogin1).Click();

            GenericHelper.WaitforElement( btnLogin1, 60);


        }

        public void ClickRadio()
        {


            GenericHelper.GetElement(Radio).Click();
            GenericHelper.WaitTime();
        }

        public void Clickcheckbox()
        {


            GenericHelper.GetElement(Checkbox).Click();
            GenericHelper.WaitTime();
        }

        public void typename(string name)
        {


            GenericHelper.GetElement(Name).SendKeys(name);
            GenericHelper.WaitTime();
        }
        public void Selectspeed(string text)
        {

            GenericHelper.SelectElementByText(Dropdown, text);


         //   GenericHelper.SelectInDropdownByText(DriverContext.Driver, speed, text);
        }


        public void DragandDropmethod()
        {

            DragandDropHelper.DragandDrop(Drag, Drop);


           
        }



    }
}
