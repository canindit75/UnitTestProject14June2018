using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.IO;
using System.Collections.Generic;
namespace ControlFlow
{

    /*
    6.1 Simulating Mouse & Keyboard Operations
    6.2 Capture Screenshots
    6.3 Drag and Drop Operations
    6.4 List Sub menu Items
    6.5 Calendar Control
    */

    [TestFixture]
    public class HandleMouseOps
    {
        static IWebDriver driver;
        [Test]
        public void HandleMouseOpsTest()
        {
            driver = new ChromeDriver(@"C:\Selenium_Csharp_LatestBackup\UnitTestProject14June2018\UnitTestProject14June2018\drivers");          
            

    		//***************************************************************************
		//6.1 Simulating Mouse & Keyboard Operations
		//***************************************************************************
		driver.Navigate().GoToUrl("http://demo.opencart.com/");
		driver.Manage().Window.Maximize();
		driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
		//Click on Components Menu
        driver.FindElement(By.XPath("//*[@id='menu']/div[2]/ul/li[3]/a")).Click();
		Actions action = new Actions(driver);
		//Finding the Printer Element in the Components Menu
		WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
		wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='menu']/div[2]/ul/li[3]/div/div/ul/li[3]/a")));
		IWebElement printerElement = driver.FindElement(By.XPath("//*[@id='menu']/div[2]/ul/li[3]/div/div/ul/li[3]/a"));
		//Moving the mouse to the Printer Element
		action.MoveToElement(printerElement).Build().Perform();
		//Performing click operation on the Printer Element 
		printerElement.Click();

		//***************************************************************************
		//6.2 Capture Screenshots
		//***************************************************************************
		String fileName = "screenshot.jpeg";
        Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
        ss.SaveAsFile(@"C:\Selenium_Csharp_LatestBackup\UnitTestProject14June2018\UnitTestProject14June2018\" + fileName, System.Drawing.Imaging.ImageFormat.Jpeg);

		//***************************************************************************
		//6.3 Drag and Drop Operations
		//***************************************************************************
		driver.Navigate().GoToUrl("http://jqueryui.com/droppable/");
		//Wait for the frame to be available and switch to it
		WebDriverWait wait2 = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
		wait2.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.CssSelector(".demo-frame")));
		IWebElement Sourcelocator = driver.FindElement(By.CssSelector(".ui-draggable"));
		IWebElement Destinationlocator = driver.FindElement(By.CssSelector(".ui-droppable"));
		dragAndDrop(Sourcelocator,Destinationlocator);
		String actualText=driver.FindElement(By.CssSelector("#droppable>p")).Text;
		//Assert.assertEquals(actualText, "Dropped!");

		//***************************************************************************
		//6.4 List Sub menu Items
		//***************************************************************************
		driver.Navigate().GoToUrl("https://demo.opencart.com/");
		driver.FindElement(By.XPath("//*[@id='menu']/div[2]/ul/li[3]/a")).Click();
		//Finding the Printer Element in the Components Menu
		WebDriverWait wait3 = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
		wait3.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='menu']/div[2]/ul/li[3]/div/div/ul/li[1]/a")));
		IList<IWebElement>subMenuList = driver.FindElements(By.XPath("//*[@id='menu']/div[2]/ul/li[3]/div/div/ul/li"));
		for(int i=1;i<=subMenuList.Count;i++){
			Console.WriteLine(driver.FindElement(By.XPath("//*[@id='menu']/div[2]/ul/li[3]/div/div/ul/li["+i+"]/a")).Text);
		}
        //***************************************************************************
		//6.5 Calendar Control
		//**************************************************************************
		  //driver.Navigate().GoToUrl("http://spicejet.com/");
		  //driver.Manage().Window.Maximize();
          //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
		  //for explicit Wait
		  //driver.FindElement(By.XPath("//*[@id='flightSearchContainer']/div[3]/button")).Click();
		  //WebDriverWait  wait1 = new WebDriverWait(driver, TimeSpan.FromSeconds(30));		  
		  //wait1.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='ui-datepicker-div']/table/tbody/tr[5]/td[6]/a")));
		  //IWebElement caldateElementJun29 = driver.FindElement(By.XPath("//*[@id='ui-datepicker-div']/table/tbody/tr[5]/td[6]/a"));
		  //caldateElementJun29.Click();
	}
        //***************************************************************************
        //6.3 Drag and Drop Operations
        //***************************************************************************
        public static void dragAndDrop(IWebElement sourceElement, IWebElement destinationElement) {
		try {
			if (sourceElement.Displayed && destinationElement.Displayed) {
				Actions action = new Actions(driver);
				action.DragAndDrop(sourceElement, destinationElement).Build().Perform();
			} else {
				Console.WriteLine("Element was not displayed to drag");
			}
		} catch (StaleElementReferenceException e) {
			Console.WriteLine("Element with " + sourceElement + "or" + destinationElement + "is not attached to the page document "
					+ e.StackTrace);
		} catch (NoSuchElementException e) {
			Console.WriteLine("Element " + sourceElement + "or" + destinationElement + " was not found in DOM "+ e.StackTrace);
		} catch (Exception e) {
            Console.WriteLine("Error occurred while performing drag and drop operation " + e.StackTrace);
		}
        }
    }
}
