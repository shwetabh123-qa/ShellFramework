using System;
using System.Threading;
//using AventStack.ExtentReports;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using RelevantCodes.ExtentReports;
using RelevantCodes.ExtentReports;
using SeleniumWebdriver.ComponentHelper;
using ShellFramework.Base;
using ShellFramework.Config;
using ShellTest.Base;
using ShellTest.Pages;


namespace ShellTest
{


    //****************************************
    //MSTESTFRAMEWORK

    //****************************************


    [TestClass]


    public class UnitTest2: BaseClass
    {






        //private TestContext testContextInstance;

        //public TestContext TestContext
        //{


        //    get { return testContextInstance; }
        //    set { testContextInstance = value; }
        //}


        //public TestContext getContext()
        //{
        //    return this.TestContext;
        //}

        //public void setContext(TestContext Context)
        //{
        //    this.TestContext = Context;
        //}



        // string url = "http://www.executeautomation.com/site/";

        //  string url = ConfigReader.InitializeTest();

        public UnitTest2() : base(BrowserType.Chrome)
        {






        }

        [TestInitialize]

        public  void BeforeTest()

        {
           

            OpenBrowser(_browserType);

        }



        public void OpenBrowser(BrowserType browsertype)
        {



            //string browser = ConfigReader.GetBrowser();



            //driver = new ChromeDriver();


            //driver.Navigate().GoToUrl(url);

            //driver.Manage().Window.Maximize();



            //DriverContext.Driver = new ChromeDriver();

            //DriverContext.Driver.Navigate().GoToUrl(url);

            //DriverContext.Driver.Manage().Window.Maximize();

            if (browsertype == BrowserType.IExplorer)
            {
                DriverContext.Driver = new InternetExplorerDriver();
                DriverContext.Browser = new Browser(DriverContext.Driver);

                //    break;
            }
            else if (browsertype == BrowserType.Chrome)
            {
                DriverContext.Driver = new ChromeDriver();

                DriverContext.Browser = new Browser(DriverContext.Driver);


                //  break;
            }
            else if (browsertype == BrowserType.Firefox)

            {
                DriverContext.Driver = new FirefoxDriver();

                DriverContext.Browser = new Browser(DriverContext.Driver);

                //     break;
            }

              



            


            DriverContext.Driver.Manage().Timeouts().PageLoad=(TimeSpan.FromSeconds(ConfigReader.GetPageLoadTimeOut()));


            DriverContext.Driver.Manage().Timeouts().ImplicitWait=(TimeSpan.FromSeconds(ConfigReader.GetElementLoadTimeOut()));


            BrowserHelper.BrowserMaximize();
           
          //  childtest = extent.StartTest("Child2", "Test started");




        }


        //  public IWebDriver driver;


        ////  [TestInitialize]
        //  public void OpenBrowser1(BrowserType browserType)
        //  {
        //      //driver = new ChromeDriver();


        //      //driver.Navigate().GoToUrl(url);

        //      //driver.Manage().Window.Maximize();


        //      //DriverContext.Driver = new ChromeDriver();

        //      //DriverContext.Driver.Navigate().GoToUrl(url);

        //      //DriverContext.Driver.Manage().Window.Maximize();



        //      switch(browserType)

        //          {
        //          case BrowserType.InternetExplorer:

        //              DriverContext.Driver = new InternetExplorerDriver();
        //              DriverContext.Browser = new Browser(DriverContext.Driver);

        //              break;

        //          case BrowserType.Chrome:

        //             DriverContext.Driver = new ChromeDriver();

        //              DriverContext.Browser = new Browser(DriverContext.Driver);

        //              break;

        //          case BrowserType.FireFox:

        //              DriverContext.Driver = new FirefoxDriver();

        //              DriverContext.Browser = new Browser(DriverContext.Driver);

        //              break;


        //          default:


        //              break;




        //      }



        //[TestInitialize]
        //public void OpenBrowser()
        //{



        //    string browser = ConfigReader.GetBrowser();



        //    //driver = new ChromeDriver();


        //    //driver.Navigate().GoToUrl(url);

        //    //driver.Manage().Window.Maximize();



        //    //DriverContext.Driver = new ChromeDriver();

        //    //DriverContext.Driver.Navigate().GoToUrl(url);

        //    //DriverContext.Driver.Manage().Window.Maximize();

        //    switch (browser)

        //    {
        //        case "InternetExplorer":

        //            DriverContext.Driver = new InternetExplorerDriver();
        //            DriverContext.Browser = new Browser(DriverContext.Driver);

        //            break;

        //        case "Chrome":

        //            DriverContext.Driver = new ChromeDriver();

        //            DriverContext.Browser = new Browser(DriverContext.Driver);

        //            break;

        //        case "FireFox":

        //            DriverContext.Driver = new FirefoxDriver();

        //            DriverContext.Browser = new Browser(DriverContext.Driver);

        //            break;


        //        default:


        //            break;




        //    }


        //    DriverContext.Driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(ConfigReader.GetPageLoadTimeOut()));


        //    DriverContext.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(ConfigReader.GetElementLoadTimeOut()));


        //    BrowserHelper.BrowserMaximize();
        //    childtest = extent.StartTest("Child", "Test started");




        //}



        //****************************Second approach without pagefactory *****************************//

        //[TestMethod]
        //public void Login()
        //{

        //    LoginPage l = new LoginPage(driver);

        //    l.Loginmethod("admin","password");







        //}

        //****************************First approach with pagefactory *****************************//

        //[TestMethod]
        //public void LaptopsNotebooksTest()
        //{


        //    //  OpenBrowser(BrowserType.Chrome);


        //    //   string browser  = ConfigReader.GetBrowser();



        //    //Start Report

        //    childtest = extent.StartTest("LaptopsNotebooksTest", "Verify LaptopsNotebooksTest ");

        //    Thread.Sleep(14000);



        //    // OpenBrowser(browser);

        //    string url = ConfigReader.GetUrltwo();


        //    DriverContext.Driver.Navigate().GoToUrl(url);

            
          
        //    LoginPage l = new LoginPage();
        //    Thread.Sleep(14000);

        //    l.LaptopsNotebooks.Click();
        //    Thread.Sleep(14000);


        //    //LaptopsNotebooks Info

        //    childtest.Log(LogStatus.Info, "Clicked LaptopsNotebooks");

        //    childtest.AssignCategory("Smoke");


        //}

        //  MSTest
        [TestCleanup]

        ////NUNIT
        //[TearDown]
        public void TestCleanup()

        {



            //     //StackTrace details for failed Testcases

            //    var status = TestContext.CurrentContext.Result.Outcome.Status;

            //   //  var stacktrace = "<pre>" + TestContext.CurrentContext.Result.StackTrace + "</pre>";


            //     //var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace)
            //     //        ? ""
            //     //        : string.Format("{0}", TestContext.CurrentContext.Result.StackTrace);



            //  //   var errorMessage = TestContext.CurrentContext.Result.Message;




            //    // var statusmstest = TestContext.CurrentTestOutcome;

            var status = TestContext.CurrentTestOutcome;

            if (status == UnitTestOutcome.Failed)
            {

                string screenShotPath = BaseClass.Capture("screesnshotname");


                //re
                 childtest.Log(LogStatus.Fail, "Test Failed");

                //av
              //  childtest.Log(Status.Fail, "Test Failed");

                //re
                 childtest.Log(LogStatus.Fail, "Snapshot below: " + childtest.AddScreenCapture(screenShotPath));


                //av
              //  childtest.Log(Status.Fail, "Snapshot below: " + childtest.AddScreenCaptureFromPath(screenShotPath));


            }

            else if (status == UnitTestOutcome.Passed)

            {

                string screenShotPath = BaseClass.Capture("screesnshotname");
                //re
                childtest.Log(LogStatus.Pass, "Test Passed");


                //av
               // childtest.Log(Status.Pass, "Test Passed");


                //re
                   childtest.Log(LogStatus.Pass, "Snapshot below: " + childtest.AddScreenCapture(screenShotPath));

                //av

                //childtest.Log(Status.Pass, "Snapshot below: " + childtest.AddScreenCaptureFromPath(screenShotPath));



            }

            else if (status == UnitTestOutcome.Error)

            {
                string screenShotPath = BaseClass.Capture("screesnshotname");



                //re
                childtest.Log(LogStatus.Error, "Test Failed");

                //av

               // childtest.Log(Status.Error, "Test Failed");


                //re

                childtest.Log(LogStatus.Error, "Snapshot below: " + childtest.AddScreenCapture(screenShotPath));


                //av
               // childtest.Log(Status.Error, "Snapshot below: " + childtest.AddScreenCaptureFromPath(screenShotPath));


            }
            else if (status == UnitTestOutcome.Unknown)

            {
                string screenShotPath = BaseClass.Capture("screesnshotname");

                //re
                  childtest.Log(LogStatus.Skip, "Test Skipped");

                //av
              //  childtest.Log(Status.Skip, "Test Skipped");


                //re

                 childtest.Log(LogStatus.Skip, "Snapshot below: " + childtest.AddScreenCapture(screenShotPath));

                //av

                //childtest.Log(Status.Skip, "Snapshot below: " + childtest.AddScreenCaptureFromPath(screenShotPath));


            }
            if (DriverContext.Driver != null)
            {


                //End test report
               
                //re
                 extent.EndTest(childtest);


                //av


              //  extent.RemoveTest(childtest);

                BaseClass.extent.Flush();



                DriverContext.Driver.Close();
                DriverContext.Driver.Quit();
            }
            //    Logger.Info(" Stopping the Driver  ");

        }

    }
}
