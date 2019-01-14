using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
namespace PageFactoryTests
{
public class BmiCalcPage
{
   static string Url = "http://www.calculator.net/calorie-calculator.html";

private static string Title = "BMI Calculator";

[FindsBy(How = How.Id, Using = "cheightfeet")]
[CacheLookup]
private IWebElement HeightField;

[FindsBy(How = How.Id, Using = "cpound")]
private IWebElement WeightField;

[FindsBy(How = How.Id, Using = "cheightinch")]
private IWebElement HeightInches;

private IWebDriver driver;

public BmiCalcPage() {
    driver = new ChromeDriver(@"C:\Selenium_Csharp_LatestBackup\UnitTestProject14June2018\UnitTestProject14June2018\drivers");
	PageFactory.InitElements(driver, this);
}

public void Load()
{
	driver.Navigate().GoToUrl(Url);
    
}

public void Close()
{
	driver.Close();
}

public bool IsLoaded
{
	get { return driver.Title.Equals(Title); }
}

public void CalculateBmi(String height, String weight,String heightInch)
{
    HeightField.Clear();
	HeightField.SendKeys(height);
    WeightField.Clear();
	WeightField.SendKeys(weight);
    HeightInches.Clear();
    HeightInches.SendKeys(heightInch);
    
}

public String heightfeet
{
	get { return HeightField.GetAttribute("value"); }
}

public String heightinch
{
	get { return HeightInches.GetAttribute("value"); }
}
}
}