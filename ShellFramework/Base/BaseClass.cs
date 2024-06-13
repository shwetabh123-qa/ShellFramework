

//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using OpenQA.Selenium;
//using OpenQA.Selenium.Chrome;
//using OpenQA.Selenium.Firefox;
//using OpenQA.Selenium.IE;
//using OpenQA.Selenium.PhantomJS;
//using RelevantCodes.ExtentReports;
//using SeleniumWebdriver.ComponentHelper;

//using ShellFramework.Config;
//using System;
//using System.Drawing.Imaging;

//namespace ShellFramework.Base
//{
//    [TestClass]

//    public class BaseClass
//    {

//        public static IWebDriver driver;



//        public static  ExtentReports extent;

//        public static  ExtentTest test;
//        public  static ExtentTest childtest;

//        //  public static ExtentTest parentTest;

//        //  public static   ExtentTest childTest;



//        //public static TestContext TestContext { get; set; }


//        //public  TestContext _testContext;


//        public BrowserType _browserType;

//        public BaseClass(BrowserType browser)
//        {
//            _browserType = browser;
//        }



//        private static FirefoxProfile GetFirefoxptions()
//        {
//            FirefoxProfile profile = new FirefoxProfile();
//            FirefoxProfileManager manager = new FirefoxProfileManager();
//            profile = manager.GetProfile("default");
//            //  Logger.Info(" Using Firefox Profile ");
//            return profile;
//        }

//        //private static FirefoxOptions GetOptions()
//        //{
//        //    FirefoxProfileManager manager = new FirefoxProfileManager();

//        //    FirefoxOptions options = new FirefoxOptions()
//        //    {
//        //        Profile = manager.GetProfile("default"),
//        //        AcceptInsecureCertificates = true,

//        //    };
//        //    return options;
//        //}
//        private static ChromeOptions GetChromeOptions()
//        {
//            ChromeOptions option = new ChromeOptions();
//            option.AddArgument("start-maximized");
//            option.AddArgument("--headless");
//            option.AddExtension(@"C:\Users\rahul.rathore\Desktop\Cucumber\extension_3_0_12.crx");
//            //  Logger.Info(" Using Chrome Options ");
//            return option;
//        }

//        private static InternetExplorerOptions GetIEOptions()
//        {
//            InternetExplorerOptions options = new InternetExplorerOptions();
//            options.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
//            options.EnsureCleanSession = true;
//            options.ElementScrollBehavior = InternetExplorerElementScrollBehavior.Bottom;
//            //   Logger.Info(" Using Internet Explorer Options ");
//            return options;
//        }

//        //private static FirefoxDriver GetFirefoxDriver()
//        //{
//        //    FirefoxOptions options = new FirefoxOptions();
//        //    FirefoxDriver driver = new FirefoxDriver(GetFirefoxptions());
//        //    return driver;
//        //}

//        private static ChromeDriver GetChromeDriver()
//        {
//            ChromeDriver driver = new ChromeDriver(GetChromeOptions());
//            return driver;
//        }

//        private static InternetExplorerDriver GetIEDriver()
//        {
//            InternetExplorerDriver driver = new InternetExplorerDriver(GetIEOptions());
//            return driver;
//        }

//        private static PhantomJSDriver GetPhantomJsDriver()
//        {
//            PhantomJSDriver driver = new PhantomJSDriver(GetPhantomJsDrvierService());

//            return driver;
//        }

//        private static PhantomJSOptions GetPhantomJsptions()
//        {
//            PhantomJSOptions option = new PhantomJSOptions();
//            option.AddAdditionalCapability("handlesAlerts", true);
//            //     Logger.Info(" Using PhantomJS Options  ");
//            return option;
//        }

//        private static PhantomJSDriverService GetPhantomJsDrvierService()
//        {
//            PhantomJSDriverService service = PhantomJSDriverService.CreateDefaultService();
//            service.LogFile = "TestPhantomJS.log";
//            service.HideCommandPromptWindow = false;
//            service.LoadImages = true;
//            //   Logger.Info(" Using PhantomJS Driver Service  ");
//            return service;
//        }
     
//        public static string Capture(IWebDriver driver, string ScreenShotName)
//        {

//            ITakesScreenshot ts = (ITakesScreenshot)driver;
//            Screenshot Screenshot = ts.GetScreenshot();

//            string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
//            string uptobinpath = path.Substring(0, path.LastIndexOf("bin")) + "Screenshots\\" + ScreenShotName + ".png";

//            //    +DateTime.Now.ToString(“Dd_MMMM_hh_mm_ss_tt”) + “.Png”;

//            string localpath = new Uri(uptobinpath).LocalPath;

//            Screenshot.SaveAsFile(localpath, ImageFormat.Png);

//            return localpath;
//        }




//        [ClassInitialize]
      
//        public  void SetupTests()

//        {
           

//            // Relevantcodes extent Report 2.41
//            //*******************************************************************************************



//            // //To obtain the current solution path/project path

//            // string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;

//            // string actualPath = pth.Substring(0, pth.LastIndexOf("bin"));

//            // string projectPath = new Uri(actualPath).LocalPath;


//            // Console.WriteLine(projectPath);

//            // //Append the html report file to current project path

//            // string reportPath = projectPath + "Report\\TestRunReport.html";

//            // Console.WriteLine(reportPath);



//            // //Boolean value for replacing exisisting report

//            //extent = new ExtentReports(reportPath, true);



//            // //Add QA system info to html report

//            // extent.AddSystemInfo("Host Name", "Shwetabh")

//            //     .AddSystemInfo("Environment", "Stage")

//            //    .AddSystemInfo("Username", "shwetabh123");



//            // //Adding config.xml file

//            // extent.LoadConfig(projectPath + "extent-config.xml"); //Get the config.xml file from http://extentreports.com




//            //******************************************



//            //aventstack extentreport 3.0.0

//            //****************************************************

//            //To obtain the current solution path/project path

//            string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;

//            string actualPath = pth.Substring(0, pth.LastIndexOf("bin"));

//            string projectPath = new Uri(actualPath).LocalPath;


//            Console.WriteLine(projectPath);

//            //Append the html report file to current project path

//            string reportPath = projectPath + "Report\\TestRunReport.html";

//            Console.WriteLine(reportPath);


//            //ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(reportPath);


//            extent = new ExtentReports(reportPath);




//            //// report title
//            //  htmlReporter.Config.DocumentTitle = "aventstack - ExtentReports";

//            //// encoding, default = UTF-8
//            //  htmlReporter.Config.Encoding = "UTF-8";

//            //  htmlReporter.Config.Theme = Theme.Standard;

//            //// report or build name
//            //   htmlReporter.Config.ReportName = "Build-1224";

//            //// chart location - top, bottom
//            //htmlReporter.Configuration().ChartLocation = ChartLocation.Top;

//            //// theme - standard, dark
//            ////htmlReporter.Configuration().Theme = Theme.Dark;

//            //// add custom css
//            //htmlReporter.Configuration().CSS = "css-string";

//            //// add custom javascript
//            //htmlReporter.Configuration().JS = "js-string";


//            //// create ExtentReports and attach reporter(s)

//            extent.AddSystemInfo("Platform", "Windows");

//            // extent.AttachReporter(htmlReporter);





//            //************
//            //Gives full path package---class name---test name

//            // parentTest = extent.CreateTest(TestContext.CurrentContext.Test.ClassName);

//            //Gives only class name----use this

//            //parentTest = extent.CreateTest(TestContext.CurrentContext.Test.Name);

            
//            //childTest = parentTest.CreateNode(TestContext.TestName);
           
//        }





//        //MSTest
//        [ClassCleanup]

//        //  [ClassCleanup]


//        //NUnit

//       // [OneTimeTearDown]

//        public void TearDown()
//        {
           


//            BaseClass.extent.Flush();


//        }


















//    }
//}
