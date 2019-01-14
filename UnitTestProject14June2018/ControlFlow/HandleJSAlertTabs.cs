using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;

namespace ControlFlow
{
    /*
    5.1 Execute JavaScript
    5.2.1 Handling JavaScript Alerts - Alert
    5.2.2 Handling JavaScript Alerts - Confirm
    5.2.3 Handling JavaScript Alerts - Prompt  
    5.3 Handling Browse Multiple tabs/Windows
     */
    [TestFixture]
    public class HandleJSAlertTabs
    {
        IWebDriver driver;
        [Test]
        public void Handle_JSAlertsTabs()
        {
            driver = new ChromeDriver(@"C:\Selenium_Csharp_LatestBackup\UnitTestProject14June2018\UnitTestProject14June2018\drivers");
            driver.Navigate().GoToUrl("http://www.google.com");
            driver.Manage().Window.Maximize();

            		//**************************************************************
		//5.1 Execute JavaScript
		//5.2.1 Handling JavaScript Alerts - Alert
		//**************************************************************
		IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
		js.ExecuteScript("alert('This is an alert box!')");
		//how to handle alert box
		IAlert alert = driver.SwitchTo().Alert();
		Console.WriteLine("Text on alert :" + alert.Text);
		System.Threading.Thread.Sleep(3000);
		alert.Accept();

		//**************************************************************
		//5.1 Execute JavaScript
		//5.2.2 Handling JavaScript Alerts - confirm
		//**************************************************************
		
		js.ExecuteScript("confirm('Do you want to continue? Yes/No')");
		alert = driver.SwitchTo().Alert();
		Console.WriteLine("Text on alert :" + alert.Text);
		System.Threading.Thread.Sleep(3000);
		alert.Dismiss();
		//yes
		//do some set of actions
		//no
		//another set of actions
		//**************************************************************
		//5.1 Execute JavaScript
		//5.2.3 Handling JavaScript Alerts - prompt
		//**************************************************************
		String s= (String)js.ExecuteScript("var retval = prompt('Enter your course name','selenium'); return retval");
		alert = driver.SwitchTo().Alert();
		System.Threading.Thread.Sleep(2000);
		alert.Accept();
		
		//**************************************************************
		//5.3 Handling Browse Multiple tabs/Windows
		//**************************************************************
		  driver.Navigate().GoToUrl("https://www.online.citibank.co.in/products-services/online-services/internet-banking.htm");
		  driver.Manage().Window.Maximize();
		  driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
		  driver.FindElement(By.XPath("//*[@title='LOGIN NOW']")).Click();//click on LOGIN NOW button
          IList<String> winids = driver.WindowHandles;
		  String MainWinID = winids[0].ToString();
		  String SubWinID = winids[1].ToString();
		  driver.SwitchTo().Window(SubWinID);

		  driver.FindElement(By.XPath("//*[@id='User_Id']")).SendKeys("Selenium");
		  //switch to main window
		  driver.SwitchTo().DefaultContent();
		  driver.SwitchTo().Window(MainWinID);
		  //click on Investing menu
		  IWebElement topMenuInvesting = driver.FindElement(By.Id("topMnuinvesting"));
		  topMenuInvesting.Click();


        }
    }
}
