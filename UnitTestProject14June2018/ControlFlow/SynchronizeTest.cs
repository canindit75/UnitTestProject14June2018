using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
namespace ControlFlow
{

    /*
    4.1 Implicit Wait 
    4.2 Explicit Wait
    4.3 Thread.sleep
    4.4 Handling Ajax Suggestion box
    4.5 Fluent Wait
    */
    [TestFixture]
    public class SynchronizeTest
    {
        IWebDriver driver;
        [Test]
        public void ImplicitExplicitWait()
        {
            driver = new ChromeDriver(@"C:\Selenium_Csharp_LatestBackup\UnitTestProject14June2018\UnitTestProject14June2018\drivers");
            driver.Navigate().GoToUrl("http://www.google.com");
            driver.Manage().Window.Maximize();

//**************************************************************
		    // 4.1 Implicit Wait
		    //**************************************************************
             //driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
             driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
	         IWebElement search = driver.FindElement(By.Name("q"));
	         search.SendKeys("s");
	         search.SendKeys(Keys.ArrowDown);
		      //**************************************************************
	          //4.3 Thread.sleep
	          //**************************************************************
	         System.Threading.Thread.Sleep(2000);
	         //search.Submit();
	     
			    //**************************************************************
			    //4.2 Explicit Wait
	            //4.4 Handling Ajax Suggestion box
			    //**************************************************************

	         WebDriverWait wait = new WebDriverWait(driver,TimeSpan.FromSeconds(30));
	         wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@role='listbox']/li")));
	         IWebElement ssearch = driver.FindElement(By.XPath("//*[@role='listbox']/li[1]"));
	         //ssearch.sendKeys(Keys.DOWN);
	         IList<IWebElement> lst = driver.FindElements(By.XPath("//*[@role='listbox']/li"));
	         foreach(IWebElement e in lst){
	               Console.WriteLine(e.Text);
	           }


        }
    }
}
