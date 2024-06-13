using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using RelevantCodes.ExtentReports;
using SeleniumWebdriver.ComponentHelper;
using ShellFramework.Base;
using ShellFramework.Config;
using ShellTest.Helpers;
using ShellTest.Base;
using ShellTest.Pages;
using System.Diagnostics;
//using AventStack.ExtentReports;
namespace ShellTest
{



    //****************************************
    //MSTESTFRAMEWORK

    //****************************************

    [TestClass]
    public class UnitTest1 : BaseClass
    {
        static int counter = 0;
        public static DBConnectionStringDTO DBConnectionParameters;
        public static DBConnectionStringDTO DBConnectionParameters1;
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
        public UnitTest1() : base(BrowserType.Chrome)
        {
        }
        [TestInitialize]
        public void BeforeTest()
        {
            OpenBrowser(_browserType);
        }
        public void OpenBrowser(BrowserType browsertype)
        {
            try
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
                DriverContext.Driver.Manage().Timeouts().PageLoad = (TimeSpan.FromSeconds(ConfigReader.GetPageLoadTimeOut()));
                DriverContext.Driver.Manage().Timeouts().ImplicitWait = (TimeSpan.FromSeconds(ConfigReader.GetElementLoadTimeOut()));
                BrowserHelper.BrowserMaximize();
                //   childtest = extent.StartTest("Child1", "Test started");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                counter++;
            }
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
        [TestMethod]
        public void Verifysqlconnection()
        {
            //Start Report
            //re
            childtest = extent.StartTest("Verifysqlconnection", "Verifysqlconnection ");
            //av
            //  childtest = extent.CreateTest("Verifysqlconnection", "Verifysqlconnection ");
            Thread.Sleep(34000);




            //working
       //     DBHelper.ExecuteSPwithInputParameters("select * from [dbo].[Students]");




            //not opening excel ----format issue
         //   DBHelper.executesqlandwritetoexcel(DriverContext.Driver, ConfigReader.logFilePath(), "sql", "select * from [dbo].[Students]");


            //working
             DBHelper.executesqlandwritetocsv(DriverContext.Driver, ConfigReader.logFilePath(), "sql", "select * from [dbo].[Students]");

            ExcelHelper.Readcsvcolumnnamerownumberwise(DriverContext.Driver, ConfigReader.logFilePath(), "sql", "StudentId", 2);

            ExcelHelper.Readcsvcolumnnamerownumberwise(DriverContext.Driver, ConfigReader.logFilePath(), "sql", "StudentName",3);
            ExcelHelper.Readcsvcolumnnamerownumberwise(DriverContext.Driver, ConfigReader.logFilePath(), "sql", "Country", 5);

            ExcelHelper.Readcsvcolumnnamerownumberwise(DriverContext.Driver, ConfigReader.logFilePath(), "sql", "Age", 4);
            ExcelHelper.Readcsvcolumnnamerownumberwise(DriverContext.Driver, ConfigReader.logFilePath(), "sql", "Email", 1);

            ExcelHelper.Readcsvcolumnnamerownumberwise(DriverContext.Driver, ConfigReader.logFilePath(), "sql", "Age", 2);

            ExcelHelper.Readcsvcolumnnamerownumberwise(DriverContext.Driver, ConfigReader.logFilePath(), "sql", "Email", 3);
            ExcelHelper.Readcsvcolumnnamerownumberwise(DriverContext.Driver, ConfigReader.logFilePath(), "sql", "Email", 5);



            //re
            childtest.Log(LogStatus.Info, " Successfully Verified sqlconnection");
            //av
            //  childtest.Log(Status.Info, " Successfully Verified sqlconnection");
            childtest.AssignCategory("Regression");


        }
        [TestMethod]
        public void VerifyDragandDrop()
        {
            //Start Report
            //re
            childtest = extent.StartTest("VerifyDragandDrop", "VerifyDragandDrop ");
            //av
            //  childtest = extent.CreateTest("VerifyDragandDrop", "VerifyDragandDrop ");
            Thread.Sleep(34000);
            string url = ConfigReader.GetUrlsix();
            LogHelper.CreateLogFile();
            LogHelper.Write("Open the url");
            DriverContext.Driver.Navigate().GoToUrl(url);
            Thread.Sleep(10000);
            LoginPage l = new LoginPage(driver);
            //re
            childtest.Log(LogStatus.Info, " VerifyDragandDrop");
            //av
            //   childtest.Log(Status.Info, " VerifyDragandDrop");
            l.DragandDropmethod();
            //re
            childtest.Log(LogStatus.Info, " Successfully Dragged and Dropped");
            //av
            // childtest.Log(Status.Info, " Successfully Dragged and Dropped");
            childtest.AssignCategory("Regression");
            Thread.Sleep(5000);
        }
        [TestMethod]
        public void VerifySelect()
        {
            //Start Report
            //re
            childtest = extent.StartTest("VerifySelect", "VerifySelect ");
            //av
            // childtest = extent.CreateTest("VerifySelect", "VerifySelect ");
            Thread.Sleep(34000);
            string url = ConfigReader.GetUrlfive();
            LogHelper.CreateLogFile();
            LogHelper.Write("Open the url");
            DriverContext.Driver.Navigate().GoToUrl(url);
            Thread.Sleep(10000);
            LoginPage l = new LoginPage(DriverContext.Driver);
            //re
            childtest.Log(LogStatus.Info, " VerifySelect");
            //av
            //   childtest.Log(Status.Info, " VerifySelect");
            l.Selectspeed("Database Testing");
            childtest.AssignCategory("Regression");
        }
        [TestMethod]
        public void Verifytextbox()
        {
            //Start Report
            //re
            childtest = extent.StartTest("Verifytextbox", "Verifytextbox ");
            //av
            //  childtest = extent.CreateTest("Verifytextbox", "Verifytextbox ");
            Thread.Sleep(34000);
            string url = ConfigReader.GetUrlfour();
            LogHelper.CreateLogFile();
            LogHelper.Write("Open the url");
            DriverContext.Driver.Navigate().GoToUrl(url);
            LoginPage l = new LoginPage(driver);
            //re
            childtest.Log(LogStatus.Info, "type name");
            //av
            //  childtest.Log(Status.Info, "type name");
            l.typename("I love shwetabh");
            childtest.AssignCategory("Regression");
        }
        [TestMethod]
        public void Checkboxradio()
        {
            //Start Report
            //re
            //  childtest = extent.StartTest("Checkboxradio", "Verify Checkboxradio ");
            childtest = extent.StartTest("TestNumber" + counter);
            //av
            //  childtest = extent.CreateTest("Verifytextbox", "Verifytextbox ");
            //  childtest = extent.CreateTest("TestNumber" + counter);
            Thread.Sleep(4000);
            string url = ConfigReader.GetUrlthree();
            LogHelper.CreateLogFile();
            LogHelper.Write("Open the url");
            DriverContext.Driver.Navigate().GoToUrl(url);
            LoginPage l = new LoginPage(driver);
            //re
            childtest.Log(LogStatus.Info, "ClickRadio");
            //av
            //childtest.Log(Status.Info, "ClickRadio");
            l.ClickRadio();
            //re
            childtest.Log(LogStatus.Info, "Clickcheckbox");
            //av
            // childtest.Log(Status.Info, "Clickcheckbox");
            l.Clickcheckbox();
            childtest.AssignCategory("Regression");
        }


        [TestMethod]
        ///WORKING ---FROM YOUTUBE VIDEO
        ///

        public void WritetoExcel()
        {


            string xlFilePath = "D:/ExcelFiles/TestData.xlsx";

            ExcelHelperNew eat = new ExcelHelperNew(xlFilePath);
            eat.SetCellData("Credentials", "Java", 5, "20");


        }




        //DataDriven Testing ---WORKING---without ui
        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
            "|DataDirectory|\\Data\\data.csv", "data#csv", DataAccessMethod.Sequential)]
        [Description("This will ReadDatafromCSVTestMethod")]
        public void ReadDatafromCSVTestMethod()
        {
            //  D:\\CWorkspace\\ShellWorkspace\\ShellTest\\Data\\data.csv
            //aventstack
            //   childtest = extent.CreateTest("TestNumber" + counter);
            //releventcodes
            childtest = extent.StartTest("TestNumber" + counter);
            var calc = new Calculator();
            var number1 = Int32.Parse(TestContext.DataRow["number1"].ToString());
            Console.WriteLine("First Number is :" + number1);
            //re
            childtest.Log(LogStatus.Info, "First Number is :" + number1);
            //av
            //   childtest.Log(Status.Info, "First Number is :" + number1);
            var number2 = Int32.Parse(TestContext.DataRow["number2"].ToString());
            Console.WriteLine("Second Number is :" + number2);
            //re
            childtest.Log(LogStatus.Info, "Second Number is :" + number2);
            //av
            //  childtest.Log(Status.Info, "Second Number is :" + number2);
            var expectedSum = Int32.Parse(TestContext.DataRow["sum"].ToString());
            Console.WriteLine("Expected is  :" + expectedSum);
            //re
            childtest.Log(LogStatus.Info, "Expected is  :" + expectedSum);
            //av
            // childtest.Log(Status.Info, "Expected is  :" + expectedSum);
            var actualresult = calc.Add(number1, number2);
            Console.WriteLine("Actual is  :" + actualresult);
            //re
            childtest.Log(LogStatus.Info, "Actual is  :" + actualresult);
            //av
            // childtest.Log(Status.Info, "Actual is  :" + actualresult);
            Assert.AreEqual(expectedSum, actualresult);
            //re
            childtest.Log(LogStatus.Info, "Addition Matches");
            //av
            //  childtest.Log(Status.Info, "Addition Matches");
        }



        //DataDriven Testing ---WORKING---with UI
        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
            "|DataDirectory|\\Data\\data.csv", "data#csv", DataAccessMethod.Sequential)]
        [Description("This will ReadDatafromCSVTestMethodwithUI")]
        public void ReadDatafromCSVTestMethodwithUI()
        {
            //  D:\\CWorkspace\\ShellWorkspace\\ShellTest\\Data\\data.csv
            try
            {
                //aventstack
                //   childtest = extent.CreateTest("TestNumber" + counter);
                //releventcodes
                //childtest = extent.StartTest("TestNumber" + counter);
                //Start Report
                //aventstack
                //  childtest = extent.CreateTest("TestNumber" +counter);
                // childtest = extent.CreateTest("ReadDatafromExcelTestMethod", "ReadDatafromExcelTestMethod ");
                //releventcodes
                childtest = extent.StartTest("TestNumber" + counter);
                childtest.AssignCategory("Regression");
                //  childtest = extent.StartTest("ReadDatafromExcelTestMethod", "ReadDatafromExcelTestMethod ");
                Thread.Sleep(4000);
                // OpenBrowser(browser);
                string url = ConfigReader.GetUrlone();
                DriverContext.Driver.Navigate().GoToUrl(url);
                Thread.Sleep(24000);
                // LogHelper.CreateLogFile();
                //  LogHelper.Write("Open the url");
                LoginPage l = new LoginPage(driver);
                Thread.Sleep(4000);
                l.lnklogin.Click();
                childtest.Log(LogStatus.Info, "Clicked loginlink");
                //    var number1 = Int32.Parse(TestContext.DataRow["number1"].ToString());
                Thread.Sleep(4000);
                l.txtUserName.SendKeys(TestContext.DataRow["number1"].ToString());
                Thread.Sleep(4000);
                // LogHelper.Write("Type username from CSV sheet");
                childtest.Log(LogStatus.Info, "Type username from CSV sheet");
                //  l.txtPassword.SendKeys("password");
                l.txtPassword.SendKeys(TestContext.DataRow["number2"].ToString());
                Thread.Sleep(4000);
                //   LogHelper.Write("Type password from CSV sheet");
                childtest.Log(LogStatus.Info, "Type password from CSV sheet");
                l.btnLogin.Submit();
                //Login Info
                //   LogHelper.Write("Clicked submit button");
                childtest.Log(LogStatus.Info, "Clicked submit button");
                Thread.Sleep(4000);
                l.txtUserName.Clear();
                Thread.Sleep(4000);
                l.txtPassword.Clear();
                Thread.Sleep(4000);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }


        //*********************************************EXCEL*****************************************************
        // Not DataDriven Testing --WORKING
        [TestMethod]
        [Description("This will ReadDatafromExcelTestMethod")]
        public void ReadDatafromExcelTestMethod()
        {
            //D:\\CWorkspace\\ShellWorkspace\\ShellTest\\Data\\Login.xls
            try
            {
                string pth = AppDomain.CurrentDomain.BaseDirectory;
                string actualPath = pth.Substring(0, pth.LastIndexOf("bin"));
                string projectPath = new Uri(actualPath).LocalPath;
                string fileName = projectPath + "Data\\Login.xlsx";
                ExcelHelper.PopulateInCollection(fileName);
                //Start Report
                //aventstack
                //  childtest = extent.CreateTest("TestNumber" +counter);
                // childtest = extent.CreateTest("ReadDatafromExcelTestMethod", "ReadDatafromExcelTestMethod ");
                //releventcodes
                childtest = extent.StartTest("TestNumber" + counter);
                childtest.AssignCategory("Regression");
                //  childtest = extent.StartTest("ReadDatafromExcelTestMethod", "ReadDatafromExcelTestMethod ");
                Thread.Sleep(4000);
                // OpenBrowser(browser);
                string url = ConfigReader.GetUrlone();
                DriverContext.Driver.Navigate().GoToUrl(url);
                Thread.Sleep(14000);
                LogHelper.CreateLogFile();
                LogHelper.Write("Open the url");
                LoginPage l = new LoginPage(driver);
                l.lnklogin.Click();
                Thread.Sleep(4000);
                childtest.Log(LogStatus.Info, "Clicked loginlink");
                l.txtUserName.SendKeys(ExcelHelper.ReadData(1, "UserName"));
                Thread.Sleep(4000);
                LogHelper.Write("Type username from excel sheet");
                childtest.Log(LogStatus.Info, "Type username from excel sheet");
                //  l.txtPassword.SendKeys("password");
                l.txtPassword.SendKeys(ExcelHelper.ReadData(1, "Password"));
                Thread.Sleep(4000);
                LogHelper.Write("Type password from excel sheet");
                childtest.Log(LogStatus.Info, "Type password from excel sheet");
                l.btnLogin.Submit();
                //Login Info
                Thread.Sleep(4000);
                LogHelper.Write("Clicked submit button");
                childtest.Log(LogStatus.Info, "Clicked submit button");
                l.txtUserName.Clear();
                Thread.Sleep(4000);
                l.txtPassword.Clear();
                Thread.Sleep(4000);
                l.txtUserName.SendKeys(ExcelHelper.ReadData(2, "UserName"));
                Thread.Sleep(4000);
                childtest.Log(LogStatus.Info, "Type username from excel sheet");
                l.txtPassword.SendKeys(ExcelHelper.ReadData(2, "Password"));
                childtest.Log(LogStatus.Info, "Type password from excel sheet");
                Thread.Sleep(4000);
                l.btnLogin.Submit();
                Thread.Sleep(4000);
                childtest.Log(LogStatus.Info, "Clicked submit button");
                l.txtUserName.Clear();
                Thread.Sleep(4000);
                l.txtPassword.Clear();
                Thread.Sleep(4000);
                l.txtUserName.SendKeys(ExcelHelper.ReadData(3, "UserName"));
                childtest.Log(LogStatus.Info, "Type username from excel sheet");
                Thread.Sleep(4000);
                l.txtPassword.SendKeys(ExcelHelper.ReadData(3, "Password"));
                Thread.Sleep(4000);
                childtest.Log(LogStatus.Info, "Type password from excel sheet");
                l.btnLogin.Submit();
                Thread.Sleep(4000);
                childtest.Log(LogStatus.Info, "Clicked submit button");
                l.txtUserName.Clear();
                Thread.Sleep(4000);
                l.txtPassword.Clear();
                Thread.Sleep(4000);
                l.txtUserName.SendKeys(ExcelHelper.ReadData(4, "UserName"));
                childtest.Log(LogStatus.Info, "Type username from excel sheet");
                Thread.Sleep(4000);
                l.txtPassword.SendKeys(ExcelHelper.ReadData(4, "Password"));
                childtest.Log(LogStatus.Info, "Type password from excel sheet");
                Thread.Sleep(4000);
                l.btnLogin.Submit();
                Thread.Sleep(4000);
                childtest.Log(LogStatus.Info, "Clicked submit button");
                l.txtUserName.Clear();
                Thread.Sleep(4000);
                l.txtPassword.Clear();
                Thread.Sleep(4000);
                //Debug.WriteLine("************************");
                //Debug.WriteLine("First Username  is "+ ExcelHelper.ReadData(1, "UserName"));
                //Debug.WriteLine("First Password  is " + ExcelHelper.ReadData(1, "Password"));
                //Debug.WriteLine("************************");
                //Debug.WriteLine("second Username  is " + ExcelHelper.ReadData(2, "UserName"));
                //Debug.WriteLine("second Password  is " + ExcelHelper.ReadData(2, "Password"));
                //Debug.WriteLine("************************");
                //Debug.WriteLine("Third  Username  is " + ExcelHelper.ReadData(3, "UserName"));
                //Debug.WriteLine("Third Password  is " + ExcelHelper.ReadData(3, "Password"));
                //Debug.WriteLine("************************");
                //Debug.WriteLine("Fourth Username  is " + ExcelHelper.ReadData(4, "UserName"));
                //Debug.WriteLine("Fourth Password  is " + ExcelHelper.ReadData(4, "Password"));
                //Debug.WriteLine("************************");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        // Not DataDriven Testing --WORKING
        [TestMethod]
        [Description("This will ReadDatafromExcelTestMethodnew")]
        public void ReadDatafromExcelTestMethodnew()

        {


            //http://www.executeautomation.com/site/ 

            //D:\\CWorkspace\\ShellWorkspace\\ShellTest\\Data\\Login.xls
            try
            {
                string pth = AppDomain.CurrentDomain.BaseDirectory;
                string actualPath = pth.Substring(0, pth.LastIndexOf("bin"));
                string projectPath = new Uri(actualPath).LocalPath;
                // string fileName = projectPath + "Data\\Login1.xlsx";
                string fileName = "D:\\CWorkspace\\ShellWorkspace\\ShellTest\\Data\\Login.xlsx";
                //  ExcelHelper.PopulateInCollection(fileName);
                ExcelHelper eat = new ExcelHelper(fileName);
                string strWorksheetName = eat.getExcelSheetName(fileName, 1);
                //Start Report
                //aventstack
                //  childtest = extent.CreateTest("TestNumber" +counter);
                // childtest = extent.CreateTest("ReadDatafromExcelTestMethod", "ReadDatafromExcelTestMethod ");
                //releventcodes
                childtest = extent.StartTest("TestNumber" + counter);
                childtest.AssignCategory("Regression");
                //  childtest = extent.StartTest("ReadDatafromExcelTestMethod", "ReadDatafromExcelTestMethod ");
                Thread.Sleep(4000);
                // OpenBrowser(browser);
                string url = ConfigReader.GetUrlone();

               // --http://www.executeautomation.com/site/
                DriverContext.Driver.Navigate().GoToUrl(url);
                Thread.Sleep(14000);
                //   LogHelper.CreateLogFile();
                //   LogHelper.Write("Open the url");
                LoginPage l = new LoginPage(driver);
                l.lnklogin.Click();
                Thread.Sleep(4000);
                childtest.Log(LogStatus.Info, "Clicked loginlink");
                //  l.txtUserName.SendKeys(ExcelHelper.ReadData(1, "UserName"));
                string cellValue = eat.GetCellData(strWorksheetName, "UserName", 2);
                l.txtUserName.SendKeys(cellValue);
                Thread.Sleep(4000);
                //   LogHelper.Write("Type username from excel sheet");
                childtest.Log(LogStatus.Info, "Type 1 username from excel sheet");
                //   l.txtPassword.SendKeys(ExcelHelper.ReadData(1, "Password"));
                l.txtPassword.SendKeys(eat.GetCellData(strWorksheetName, "Password", 2));
                Thread.Sleep(4000);
                //    LogHelper.Write("Type password from excel sheet");
                childtest.Log(LogStatus.Info, "Type 1 password from excel sheet");
                l.btnLogin.Submit();
                //Login Info
                Thread.Sleep(4000);
                //    LogHelper.Write("Clicked submit button");
                childtest.Log(LogStatus.Info, "Clicked submit button");
                l.txtUserName.Clear();
                Thread.Sleep(4000);
                l.txtPassword.Clear();
                Thread.Sleep(4000);
                string cellValue1 = eat.GetCellData(strWorksheetName, "UserName", 6);
                l.txtUserName.SendKeys(cellValue1);
                Thread.Sleep(4000);
                //   LogHelper.Write("Type username from excel sheet");
                childtest.Log(LogStatus.Info, "Type 2 username from excel sheet");
                //   l.txtPassword.SendKeys(ExcelHelper.ReadData(1, "Password"));
                l.txtPassword.SendKeys(eat.GetCellData(strWorksheetName, "Password", 6));
                Thread.Sleep(4000);
                //    LogHelper.Write("Type password from excel sheet");
                childtest.Log(LogStatus.Info, "Type 2 password from excel sheet");
                l.btnLogin.Submit();
                //Login Info
                Thread.Sleep(4000);
                //    LogHelper.Write("Clicked submit button");
                childtest.Log(LogStatus.Info, "Clicked submit button");
                l.txtUserName.Clear();
                Thread.Sleep(4000);
                l.txtPassword.Clear();
                Thread.Sleep(4000);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        //working
        //DataDriven Testing --WORKING
        [TestMethod]
        [Description("This will ReadDatafromExcelDataDriven")]
        public void ReadDatafromExcelDataDriven()
        {
            //  D:\\CWorkspace\\ShellWorkspace\\ShellTest\\Data\\Login.xls
            try
            {
                string pth = AppDomain.CurrentDomain.BaseDirectory;
                string actualPath = pth.Substring(0, pth.LastIndexOf("bin"));
                string projectPath = new Uri(actualPath).LocalPath;
                string fileName = projectPath + "Data\\Login.xlsx";
                ExcelHelper.PopulateInCollection(fileName);
                ExcelHelper eat = new ExcelHelper(fileName);
                int rowCount = eat.GetRowCount("Sheet1");
                //  Console.WriteLine("Total Number of Rows : " + rowCount);
                // Console.Read();
                //Start Report
                //aventstack
                //  childtest = extent.CreateTest("TestNumber" +counter);
                // childtest = extent.CreateTest("ReadDatafromExcelTestMethod", "ReadDatafromExcelTestMethod ");
                //releventcodes
                // childtest = extent.StartTest("TestNumber" + counter);
                //   LogHelper.CreateLogFile();
                //   LogHelper.Write("Open the url");
                for (int i = 1; i < rowCount; i++)
                {
                    childtest = extent.StartTest("TestNumber" + i);
                    childtest.AssignCategory("Regression");
                    //  childtest = extent.StartTest("ReadDatafromExcelTestMethod", "ReadDatafromExcelTestMethod ");
                    // OpenBrowser(browser);
                    string url = ConfigReader.GetUrlone();
                    DriverContext.Driver.Navigate().GoToUrl(url);
                    Thread.Sleep(14000);
                    LoginPage l = new LoginPage(driver);
                    l.lnklogin.Click();
                    Thread.Sleep(4000);
                    childtest.Log(LogStatus.Info, "Clicked loginlink");
                    l.txtUserName.SendKeys(ExcelHelper.ReadData(i, "UserName"));
                    Thread.Sleep(4000);
                    //  LogHelper.Write("Type username from excel sheet");
                    childtest.Log(LogStatus.Info, "Type " + i + " username from excel sheet");
                    //  l.txtPassword.SendKeys("password");
                    l.txtPassword.SendKeys(ExcelHelper.ReadData(i, "Password"));
                    Thread.Sleep(4000);
                    //  LogHelper.Write("Type password from excel sheet");
                    childtest.Log(LogStatus.Info, "Type  " + i + " password from excel sheet");
                    l.btnLogin.Submit();
                    //Login Info
                    Thread.Sleep(4000);
                    //   LogHelper.Write("Clicked submit button");
                    childtest.Log(LogStatus.Info, "Clicked submit button");
                    l.txtUserName.Clear();
                    Thread.Sleep(4000);
                    l.txtPassword.Clear();
                    Thread.Sleep(4000);
                }
                //******************************************
                //l.txtUserName.SendKeys(ExcelHelper.ReadData(2, "UserName"));
                //Thread.Sleep(4000);
                //childtest.Log(LogStatus.Info, "Type username from excel sheet");
                //l.txtPassword.SendKeys(ExcelHelper.ReadData(2, "Password"));
                //childtest.Log(LogStatus.Info, "Type password from excel sheet");
                //Thread.Sleep(4000);
                //l.btnLogin.Submit();
                //Thread.Sleep(4000);
                //childtest.Log(LogStatus.Info, "Clicked submit button");
                //l.txtUserName.Clear();
                //Thread.Sleep(4000);
                //l.txtPassword.Clear();
                //Thread.Sleep(4000);
                //l.txtUserName.SendKeys(ExcelHelper.ReadData(3, "UserName"));
                //childtest.Log(LogStatus.Info, "Type username from excel sheet");
                //Thread.Sleep(4000);
                //l.txtPassword.SendKeys(ExcelHelper.ReadData(3, "Password"));
                //Thread.Sleep(4000);
                //childtest.Log(LogStatus.Info, "Type password from excel sheet");
                //l.btnLogin.Submit();
                //Thread.Sleep(4000);
                //childtest.Log(LogStatus.Info, "Clicked submit button");
                //l.txtUserName.Clear();
                //Thread.Sleep(4000);
                //l.txtPassword.Clear();
                //Thread.Sleep(4000);
                //l.txtUserName.SendKeys(ExcelHelper.ReadData(4, "UserName"));
                //childtest.Log(LogStatus.Info, "Type username from excel sheet");
                //Thread.Sleep(4000);
                //l.txtPassword.SendKeys(ExcelHelper.ReadData(4, "Password"));
                //childtest.Log(LogStatus.Info, "Type password from excel sheet");
                //Thread.Sleep(4000);
                //l.btnLogin.Submit();
                //Thread.Sleep(4000);
                //childtest.Log(LogStatus.Info, "Clicked submit button");
                //l.txtUserName.Clear();
                //Thread.Sleep(4000);
                //l.txtPassword.Clear();
                //Thread.Sleep(4000);
                //**********************************
                //Debug.WriteLine("************************");
                //Debug.WriteLine("First Username  is "+ ExcelHelper.ReadData(1, "UserName"));
                //Debug.WriteLine("First Password  is " + ExcelHelper.ReadData(1, "Password"));
                //Debug.WriteLine("************************");
                //Debug.WriteLine("second Username  is " + ExcelHelper.ReadData(2, "UserName"));
                //Debug.WriteLine("second Password  is " + ExcelHelper.ReadData(2, "Password"));
                //Debug.WriteLine("************************");
                //Debug.WriteLine("Third  Username  is " + ExcelHelper.ReadData(3, "UserName"));
                //Debug.WriteLine("Third Password  is " + ExcelHelper.ReadData(3, "Password"));
                //Debug.WriteLine("************************");
                //Debug.WriteLine("Fourth Username  is " + ExcelHelper.ReadData(4, "UserName"));
                //Debug.WriteLine("Fourth Password  is " + ExcelHelper.ReadData(4, "Password"));
                //Debug.WriteLine("************************");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        //Not working
        //    [TestMethod]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
        //    "|DataDirectory|\\Data\\data.csv", "data#csv", DataAccessMethod.Sequential)]
        [DataSource("System.Data.Odbc", @"Dsn=EXCEL;Driver={Microsoft Excel Driver(*.xls, *.xlsx, *.xlsm, *.xlsb)};" +
            "dbq=D:\\CWorkspace\\ShellWorkspace\\ShellTest\\Login.xlsx;defaultdir=.;driverid=790;maxbuffersize=2048;pagetimeout=5;readonly=true",
            "Sheet1$", DataAccessMethod.Sequential), TestMethod]
        [Description("This will ReadDatafromExcelDataDrivennew")]
        public void ReadDatafromExcelDataDrivennew()
        {
            //  D:\\CWorkspace\\ShellWorkspace\\ShellTest\\Data\\Login.xls
            try
            {
                //aventstack
                //   childtest = extent.CreateTest("TestNumber" + counter);
                //releventcodes
                //childtest = extent.StartTest("TestNumber" + counter);
                //Start Report
                //aventstack
                //  childtest = extent.CreateTest("TestNumber" +counter);
                // childtest = extent.CreateTest("ReadDatafromExcelTestMethod", "ReadDatafromExcelTestMethod ");
                //releventcodes
                childtest = extent.StartTest("TestNumber" + counter);
                childtest.AssignCategory("Regression");
                //  childtest = extent.StartTest("ReadDatafromExcelTestMethod", "ReadDatafromExcelTestMethod ");
                Thread.Sleep(4000);
                // OpenBrowser(browser);
                string url = ConfigReader.GetUrlone();
                DriverContext.Driver.Navigate().GoToUrl(url);
                Thread.Sleep(24000);
                // LogHelper.CreateLogFile();
                //  LogHelper.Write("Open the url");
                LoginPage l = new LoginPage(driver);
                Thread.Sleep(4000);
                l.lnklogin.Click();
                childtest.Log(LogStatus.Info, "Clicked loginlink");
                //    var number1 = Int32.Parse(TestContext.DataRow["number1"].ToString());
                Thread.Sleep(4000);
                l.txtUserName.SendKeys(TestContext.DataRow["UserName"].ToString());
                Thread.Sleep(4000);
                // LogHelper.Write("Type username from CSV sheet");
                childtest.Log(LogStatus.Info, "Type username from Excel sheet--DD");
                //  l.txtPassword.SendKeys("password");
                l.txtPassword.SendKeys(TestContext.DataRow["Password"].ToString());
                Thread.Sleep(4000);
                //   LogHelper.Write("Type password from CSV sheet");
                childtest.Log(LogStatus.Info, "Type password from Excel sheet--DD");
                l.btnLogin.Submit();
                //Login Info
                //   LogHelper.Write("Clicked submit button");
                childtest.Log(LogStatus.Info, "Clicked submit button");
                Thread.Sleep(4000);
                l.txtUserName.Clear();
                Thread.Sleep(4000);
                l.txtPassword.Clear();
                Thread.Sleep(4000);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        //****************************First approach without pagefactory *****************************//
        [TestMethod]
        public void LoginTestwithoutpagefactory()
        {
            //  OpenBrowser(BrowserType.Chrome);
            //   string browser  = ConfigReader.GetBrowser();
            //Start Report
            //re
            childtest = extent.StartTest("LoginTestwithoutpagefactory", "Verify LoginTest ");
            //av
            //  childtest = extent.CreateTest("LoginTestwithoutpagefactory", "Verify LoginTest ");
            Thread.Sleep(34000);
            // OpenBrowser(browser);
            string url = ConfigReader.GetUrlone();
            LogHelper.CreateLogFile();
            LogHelper.Write("Open the url");
            DriverContext.Driver.Navigate().GoToUrl(url);
            LoginPage l = new LoginPage(driver);
            //Login Info
            l.Loginmethod("shwetabh123", "faridabad3$");
            LogHelper.Write("Clicked loginlink");
            childtest.Log(LogStatus.Info, "Clicked loginlink");
            LogHelper.Write("Type username");
            childtest.Log(LogStatus.Info, "Type username");
            LogHelper.Write("Type password");
            childtest.Log(LogStatus.Info, "Type password");
            LogHelper.Write("Clicked submit button");
            childtest.Log(LogStatus.Info, "Clicked submit button");
            childtest.AssignCategory("Regression");
            EmployeePage e = new EmployeePage();
        }
        //****************************Second approach with pagefactory *****************************//
        //[TestMethod]
        //public void LoginTestusingpagefactory()
        //{
        //    //  OpenBrowser(BrowserType.Chrome);
        //    //   string browser  = ConfigReader.GetBrowser();
        //    //Start Report
        //    childtest = extent.StartTest("LoginTest", "Verify LoginTest ");
        //    Thread.Sleep(34000);
        //    // OpenBrowser(browser);
        //    string url = ConfigReader.GetUrlone();
        //    LogHelper.CreateLogFile();
        //    LogHelper.Write("Open the url");
        //    DriverContext.Driver.Navigate().GoToUrl(url);
        //    LoginPage l = new LoginPage();
        //    LogHelper.Write("Clicked loginlink");
        //    l.lnklogin.Click();
        //    childtest.Log(LogStatus.Info, "Clicked loginlink");
        //    LogHelper.Write("Type username");
        //    l.txtUserName.SendKeys("admin");
        //    childtest.Log(LogStatus.Info, "Type username");
        //    LogHelper.Write("Type password");
        //    l.txtPassword.SendKeys("password");
        //    childtest.Log(LogStatus.Info, "Type password");
        //    LogHelper.Write("Clicked submit button");
        //    l.btnLogin.Submit();
        //    //Login Info
        //    childtest.Log(LogStatus.Info, "Clicked submit button");
        //    childtest.AssignCategory("Regression");
        //    EmployeePage e = new EmployeePage();
        //}
        ////****************************Third  approach with pagefactory & ExcelHelper    *****************************//
        //[TestMethod]
        //public void LoginTestusingexcelhelper()
        //{
        //    //  OpenBrowser(BrowserType.Chrome);
        //    //   string browser  = ConfigReader.GetBrowser();
        //    //   string fileName = Path.GetDirectoryName(Environment.CurrentDirectory).ToString() + "\\Data\\Login.xlsx";
        //    string pth = AppDomain.CurrentDomain.BaseDirectory;
        //    string actualPath = pth.Substring(0, pth.LastIndexOf("bin"));
        //    string projectPath = new Uri(actualPath).LocalPath;
        //    string fileName = projectPath + "Data\\Login.xlsx";
        //    ExcelHelper.PopulateInCollection(fileName);
        //    //Start Report
        //    childtest = extent.StartTest("LoginTestnew", "Verify LoginTestnew ");
        //    Thread.Sleep(4000);
        //    // OpenBrowser(browser);
        //    string url = ConfigReader.GetUrlone();
        //    DriverContext.Driver.Navigate().GoToUrl(url);
        //    Thread.Sleep(34000);
        //    LogHelper.CreateLogFile();
        //    LogHelper.Write("Open the url");
        //    LoginPage l = new LoginPage();
        //    l.lnklogin.Click();
        //    childtest.Log(LogStatus.Info, "Clicked loginlink");
        //    //   l.txtUserName.SendKeys("admin");
        //    l.txtUserName.SendKeys(ExcelHelper.ReadData(1, "UserName"));
        //    LogHelper.Write("Type username from excel sheet");
        //    childtest.Log(LogStatus.Info, "Type username from excel sheet");
        //    //  l.txtPassword.SendKeys("password");
        //    l.txtPassword.SendKeys(ExcelHelper.ReadData(1, "Password"));
        //    LogHelper.Write("Type password from excel sheet");
        //    childtest.Log(LogStatus.Info, "Type password from excel sheet");
        //    l.btnLogin.Submit();
        //    //Login Info
        //    LogHelper.Write("Clicked submit button");
        //    childtest.Log(LogStatus.Info, "Clicked submit button");
        //    childtest.AssignCategory("Regression");
        //    EmployeePage e = new EmployeePage();
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
                // childtest.Log(Status.Fail, "Test Failed");
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
                //  childtest.Log(Status.Pass, "Test Passed");
                //re
                childtest.Log(LogStatus.Pass, "Snapshot below: " + childtest.AddScreenCapture(screenShotPath));
                //av
                // childtest.Log(Status.Pass, "Snapshot below: " + childtest.AddScreenCaptureFromPath(screenShotPath));
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
                //   childtest.Log(Status.Skip, "Test Skipped");
                //re
                childtest.Log(LogStatus.Skip, "Snapshot below: " + childtest.AddScreenCapture(screenShotPath));
                //av
                //   childtest.Log(Status.Skip, "Snapshot below: " + childtest.AddScreenCaptureFromPath(screenShotPath));
            }
            if (DriverContext.Driver != null)
            {
                //End test report
                //re
                // extent.EndTest(childtest);
                //av
                //  extent.RemoveTest(childtest);
                // DriverContext.Driver.Manage().Cookies.DeleteAllCookies();
                BaseClass.extent.Flush();
                DriverContext.Driver.Close();
                DriverContext.Driver.Quit();
            }
            //    Logger.Info(" Stopping the Driver  ");
        }
    }
}