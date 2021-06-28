using NUnit.Framework;
using TaxCalculator.Services;

namespace TaxCalculator.Tests
{
    public class CalculationTests
    {
        //just write some tests for future security and calmness
        decimal maxTaxableIncome;
        decimal minTaxableIncome;

        [SetUp]
        public void Setup()
        {
           maxTaxableIncome = 3000;
           minTaxableIncome = 1000;
        }

        [Test]
        public void CheckNetSalaryWhenItIsUnderMinTaxableIncome()
        {
            decimal salary = 980;
            decimal netSalary = Calculator.CalculateNetSalary(salary);
            Assert.AreEqual(netSalary, salary);
        }

        [Test]
        public void CheckNetSalaryWhenItIsEqualToMinTaxableIncome()
        {
            decimal salary = minTaxableIncome;
            decimal netSalary = Calculator.CalculateNetSalary(salary);
            Assert.AreEqual(netSalary, salary);
        }

        [Test]
        public void CheckNetSalaryWhenItIsMoreThanMaxTaxableIncome()
        {
            decimal salary = 3400;
            decimal netSalary = Calculator.CalculateNetSalary(salary);
            Assert.Greater(salary, netSalary);
        }

        [Test]
        public void CheckNetSalaryWhenItIsEqualToMaxTaxableIncome()
        {
            decimal salary = maxTaxableIncome;
            decimal netSalary = Calculator.CalculateNetSalary(salary);
            Assert.Greater(salary, netSalary);
        }

        [Test]
        public void CheckNetSalaryWhenItIsZero()
        {
            decimal salary = 0;
            decimal netSalary = Calculator.CalculateNetSalary(salary);
            Assert.AreEqual(netSalary, 0);
        }
    }
}