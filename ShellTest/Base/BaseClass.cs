//using AventStack.ExtentReports;
//using AventStack.ExtentReports.Reporter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using RelevantCodes.ExtentReports;
using SeleniumWebdriver.ComponentHelper;
using ShellFramework.Base;
using ShellFramework.Config;
using System;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
namespace ShellTest.Base
{

    //****************************************
    //MSTESTFRAMEWORK

    //****************************************
    [TestClass]
    public abstract class BaseClass
    {
        public static IWebDriver driver;
       public static ExtentReports extent;
        public static ExtentTest test;
        public static ExtentTest parenttest;
        public static ExtentTest childtest;
        //  public  static ThreadLocal<ExtentTest> parentTest = new ThreadLocal<ExtentTest>();
        //   public static ThreadLocal<ExtentTest> childTest = new ThreadLocal<ExtentTest>();
        //  public TestContext TestContext { get; set; }
        private TestContext testContextInstance;
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }
        //public TestContext getContext()
        //{
        //    return this.TestContext;
        //}
        //public void setContext(TestContext Context)
        //{
        //    this.TestContext = Context;
        //}
        public BrowserType _browserType;
        public BaseClass(BrowserType browser)
        {
            _browserType = browser;
        }
        private static FirefoxProfile GetFirefoxptions()
        {
            FirefoxProfile profile = new FirefoxProfile();
            FirefoxProfileManager manager = new FirefoxProfileManager();
            profile = manager.GetProfile("default");
            //  Logger.Info(" Using Firefox Profile ");
            return profile;
        }
        //private static FirefoxOptions GetOptions()
        //{
        //    FirefoxProfileManager manager = new FirefoxProfileManager();
        //    FirefoxOptions options = new FirefoxOptions()
        //    {
        //        Profile = manager.GetProfile("default"),
        //        AcceptInsecureCertificates = true,
        //    };
        //    return options;
        //}
        private static ChromeOptions GetChromeOptions()
        {
            ChromeOptions option = new ChromeOptions();
            option.AddArgument("start-maximized");
            option.AddArgument("--headless");
            option.AddExtension(@"C:\Users\rahul.rathore\Desktop\Cucumber\extension_3_0_12.crx");
            //  Logger.Info(" Using Chrome Options ");
            return option;
        }
        private static InternetExplorerOptions GetIEOptions()
        {
            InternetExplorerOptions options = new InternetExplorerOptions();
            options.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
            options.EnsureCleanSession = true;
            options.ElementScrollBehavior = InternetExplorerElementScrollBehavior.Bottom;
            //   Logger.Info(" Using Internet Explorer Options ");
            return options;
        }
        //private static FirefoxDriver GetFirefoxDriver()
        //{
        //    FirefoxOptions options = new FirefoxOptions();
        //    FirefoxDriver driver = new FirefoxDriver(GetFirefoxptions());
        //    return driver;
        //}
        private static ChromeDriver GetChromeDriver()
        {
            ChromeDriver driver = new ChromeDriver(GetChromeOptions());
            return driver;
        }
        private static InternetExplorerDriver GetIEDriver()
        {
            InternetExplorerDriver driver = new InternetExplorerDriver(GetIEOptions());
            return driver;
        }
        //private static PhantomJSDriver GetPhantomJsDriver()
        //{
        //    PhantomJSDriver driver = new PhantomJSDriver(GetPhantomJsDrvierService());
        //    return driver;
        //}
        //private static PhantomJSOptions GetPhantomJsptions()
        //{
        //    PhantomJSOptions option = new PhantomJSOptions();
        //    option.AddAdditionalCapability("handlesAlerts", true);
        //    //     Logger.Info(" Using PhantomJS Options  ");
        //    return option;
        //}
        //private static PhantomJSDriverService GetPhantomJsDrvierService()
        //{
        //    PhantomJSDriverService service = PhantomJSDriverService.CreateDefaultService();
        //    service.LogFile = "TestPhantomJS.log";
        //    service.HideCommandPromptWindow = false;
        //    service.LoadImages = true;
        //    //   Logger.Info(" Using PhantomJS Driver Service  ");
        //    return service;
        //}
        public static string Capture( string ScreenShotName)
        {
            DateTime dt = DateTime.Now; // Or whatever
            string dateName = dt.ToString("yyyyMMddHHmmss");
            ITakesScreenshot ts = (ITakesScreenshot)DriverContext.Driver;
            Screenshot Screenshot = ts.GetScreenshot();
            string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string uptobinpath = path.Substring(0, path.LastIndexOf("bin")) + "Screenshots\\" + ScreenShotName + dateName + ".png";
            //    +DateTime.Now.ToString(“Dd_MMMM_hh_mm_ss_tt”) + “.Png”;
            string localpath = new Uri(uptobinpath).LocalPath;
            Screenshot.SaveAsFile(localpath, ScreenshotImageFormat.Png);
            return localpath;
        }
        [AssemblyInitialize]
        public static void SetupTests(TestContext TestContext)
        {
            // Relevantcodes extent Report 2.41
            //*******************************************************************************************
            // //To obtain the current solution path/project path
            // string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            // string actualPath = pth.Substring(0, pth.LastIndexOf("bin"));
            // string projectPath = new Uri(actualPath).LocalPath;
            // Console.WriteLine(projectPath);
            // //Append the html report file to current project path
            // string reportPath = projectPath + "Report\\TestRunReport.html";
            // Console.WriteLine(reportPath);
            // //Boolean value for replacing exisisting report
            //extent = new ExtentReports(reportPath, true);
            // //Add QA system info to html report
            // extent.AddSystemInfo("Host Name", "Shwetabh")
            //     .AddSystemInfo("Environment", "Stage")
            //    .AddSystemInfo("Username", "shwetabh123");
            // //Adding config.xml file
            // extent.LoadConfig(projectPath + "extent-config.xml"); //Get the config.xml file from http://extentreports.com
            //******************************************
            //aventstack extentreport 3.0.0
            //****************************************************
            //To obtain the current solution path/project path
            //string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            // string pth = System.Environment.CurrentDirectory;
            //  string pth = AppDomain.CurrentDomain.BaseDirectory;
            string pth = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            string actualPath = pth.Substring(0, pth.LastIndexOf("bin"));
            string projectPath = new Uri(actualPath).LocalPath;
            Console.WriteLine(projectPath);
            //Append the html report file to current project path
            string reportPath = projectPath + "Report\\TestRunReport.html";
            //string reportPath = "TestRunReport.html";
            Console.WriteLine(reportPath);
            //aventstack
            //  ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(reportPath);
            //Boolean value for replacing exisisting report
            //relevent codes
            extent = new ExtentReports(reportPath,true);
            //aventstack
         //   extent = new ExtentReports();
            //// report title
            //  htmlReporter.Config.DocumentTitle = "aventstack - ExtentReports";
            //// encoding, default = UTF-8
            //  htmlReporter.Config.Encoding = "UTF-8";
            //  htmlReporter.Config.Theme = Theme.Standard;
            //// report or build name
            //   htmlReporter.Config.ReportName = "Build-1224";
            //// chart location - top, bottom
            //htmlReporter.Configuration().ChartLocation = ChartLocation.Top;
            //// theme - standard, dark
            ////htmlReporter.Configuration().Theme = Theme.Dark;
            //// add custom css
            //htmlReporter.Configuration().CSS = "css-string";
            //// add custom javascript
            //htmlReporter.Configuration().JS = "js-string";
            //// create ExtentReports and attach reporter(s)
            //aventstack
         //   extent.AttachReporter(htmlReporter);
            extent.AddSystemInfo("Platform", "Windows");
            extent.AddSystemInfo("Host Name", "localhost");
            extent.AddSystemInfo("Environment", "QA");
            extent.AddSystemInfo("User Name", "testUser");
            //************
            //Gives full path package---class name---test name
            // parentTest = extent.CreateTest(TestContext.CurrentContext.Test.ClassName);
            //Gives only class name----use this
            //parentTest = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            //    childTest = parentTest.CreateNode(TestContext.TestName);
            //  parenttest = extent.StartTest("Parent", "Test Started");
        }
        ////  MSTest
        //[TestCleanup]
        //////NUNIT
        ////[TearDown]
        //public static void TestCleanup(TestContext TestContext)
        //{
        //    var status = TestContext.CurrentTestOutcome;
        //    if (status == UnitTestOutcome.Failed)
        //    {
        //        string screenShotPath = BaseClass.Capture( "screesnshotname");
        //        childtest.Log(LogStatus.Pass, "Test Failed");
        //        childtest.Log(LogStatus.Fail, "Snapshot below: " + childtest.AddScreenCapture(screenShotPath));
        //    }
        //    else if (status == UnitTestOutcome.Passed)
        //    {
        //        string screenShotPath = BaseClass.Capture("screesnshotname");
        //        childtest.Log(LogStatus.Pass, "Test Passed");
        //        childtest.Log(LogStatus.Pass, "Snapshot below: " + childtest.AddScreenCapture(screenShotPath));
        //    }
        //    else if (status == UnitTestOutcome.Error)
        //    {
        //        string screenShotPath = BaseClass.Capture("screesnshotname");
        //        childtest.Log(LogStatus.Pass, "Test Failed");
        //        childtest.Log(LogStatus.Error, "Snapshot below: " + childtest.AddScreenCapture(screenShotPath));
        //    }
        //    else if (status == UnitTestOutcome.Unknown)
        //    {
        //        string screenShotPath = BaseClass.Capture("screesnshotname");
        //        childtest.Log(LogStatus.Pass, "Test Skipped");
        //        childtest.Log(LogStatus.Skip, "Snapshot below: " + childtest.AddScreenCapture(screenShotPath));
        //    }
        //    if (DriverContext.Driver != null)
        //    {
        //        //End test report
        //        extent.EndTest(childtest);
        //        DriverContext.Driver.Close();
        //        DriverContext.Driver.Quit();
        //    }
        //    //    Logger.Info(" Stopping the Driver  ");
        //}
        //MSTest
        // [ClassCleanup]
        [AssemblyCleanup]
        //  [ClassCleanup]
        //NUnit
        // [OneTimeTearDown]
        public static void TearDown()
        {
            BaseClass.extent.Flush();
        }
    }
}
