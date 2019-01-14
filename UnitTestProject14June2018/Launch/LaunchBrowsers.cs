using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System.IO;

namespace Launch
{
    [TestFixture]
    public class LaunchBrowsers
    {

        public enum Drivers
        {
            Chrome,
            Firefox,
            Safari,
            Edge,
            IE
        }


        //public static IWebDriver GetDriver(Drivers driver)
        //{
        //    var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        //    // below is my location where I copied all drivers like chromedriver.exe 
        //    var relativePath = @"..\..\bin\Debug\BrowserDriver";
        //    var chromeDriverPath = Path.GetFullPath(Path.Combine(outPutDirectory, relativePath));
        //    // return this driver , just debug this code and check the "outPutDirectory" path
        //    return new ChromeDriver(chromeDriverPath);
        //}
        [Test]
        public void LaunchTest()
        {
            //IWebDriver driver = new ChromeDriver(@"C:\Users\Anindita\Documents\Visual Studio 2012\Projects\UnitTestProject14June2018\UnitTestProject14June2018\drivers");

            //Console.WriteLine("The relative path 'file.txt' " + Path.GetFullPath("chromedriver.exe"));
            //String ChromeDriverPath = Path.GetFullPath("chromedriver.exe");
            //IWebDriver driver = new ChromeDriver(ChromeDriverPath);
            IWebDriver driver = new ChromeDriver(@"C:\Selenium_Csharp_LatestBackup\UnitTestProject14June2018\UnitTestProject14June2018\drivers");
            driver.Navigate().GoToUrl("http://www.facebook.com");
            driver.FindElement(By.Id("email")).SendKeys("username");
            driver.FindElement(By.Id("pass")).SendKeys("username");
            driver.Close();
 /*           Environment.SetEnvironmentVariable("webdriver.gecko.driver", @"C:\Users\Aspire E5-571\Documents\Visual Studio 2012\Projects\Csharp_Basics\Csharp_Basics\drivers\geckodriver.exe");
            FirefoxDriverService driverService = FirefoxDriverService.CreateDefaultService();
            driverService.FirefoxBinaryPath = @"C:\Program Files (x86)\Mozilla Firefox\firefox.exe";
            driverService.HideCommandPromptWindow = true;
            driverService.SuppressInitialDiagnosticInformation = true;
            FirefoxDriver fdriver = new FirefoxDriver(driverService, new FirefoxOptions(), TimeSpan.FromMilliseconds(600));
            fdriver.Navigate().GoToUrl("http://www.gmail.com");
  */
           /* FirefoxDriverService service = FirefoxDriverService.CreateDefaultService();
            service.FirefoxBinaryPath = @"C:\Program Files (x86)\Mozilla Firefox\firefox.exe";
            IWebDriver fdriver = new FirefoxDriver(service);
            System.Environment.SetEnvironmentVariable("webdriver.gecko.driver", @"C:\Users\Aspire E5-571\Documents\Visual Studio 2012\Projects\Csharp_Basics\Csharp_Basics\drivers\geckodriver.exe");
           // var fdriver = new FirefoxDriver();
            //IWebDriver fdriver = new FirefoxDriver(@"C:\Users\Aspire E5-571\Documents\Visual Studio 2012\Projects\Csharp_Basics\Csharp_Basics\drivers");
            fdriver.Navigate().GoToUrl("http://www.gmail.com");*/
            IWebDriver Idriver = new InternetExplorerDriver(@"C:\Selenium_Csharp_LatestBackup\UnitTestProject14June2018\UnitTestProject14June2018\drivers");
            Idriver.Navigate().GoToUrl("http://www.bbc.com");
        }
    }
}
