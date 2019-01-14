using NUnit.Framework;
namespace PageFactoryTests
{
[TestFixture]
public class BmiCalcTests
{
[Test]
public void TestBmiCalculator()
{
BmiCalcPage bmiCalcPage = new BmiCalcPage();
bmiCalcPage.Load();
//Assert.IsTrue(bmiCalcPage.IsLoaded);
bmiCalcPage.CalculateBmi("6", "180","4");
Assert.AreEqual("6", bmiCalcPage.heightfeet);
Assert.AreEqual("4", bmiCalcPage.heightinch);

bmiCalcPage.Close();
}
}
}