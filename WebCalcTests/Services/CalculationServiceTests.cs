using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebCalc.Api;
using WebCalc.Services;

namespace WebCalcTests.Services
{
    [TestClass()]
    public class CalculationServiceTests
    {
        [TestMethod()]
        public void CalculateTestRealAdd()
        {
            var exampleDto = new ExampleDto
            {
                FirstNumber = 1,
                SecondNumber = 2,
                Operation = "+",
                RealNum = true
            };
            var result = CalculationService.Calculate(exampleDto);
            Assert.AreEqual(3, result);
        }


        [TestMethod()]
        public void CalculateTestComplexAdd()
        {
            var exampleDto = new ExampleDto
            {
                FirstNumber = 1,
                SecondNumber = 3,
                Operation = "+",
                RealNum = false
            };
            var result = CalculationService.Calculate(exampleDto);
            Assert.AreEqual(4, result);
        }

        [TestMethod()]
        public void CalculateTestRealDivide()
        {
            var exampleDto = new ExampleDto
            {
                FirstNumber = 1,
                SecondNumber = 2,
                Operation = "/",
                RealNum = false
            };
            var result = CalculationService.Calculate(exampleDto);
            Assert.AreEqual(0, result);
        }

        [TestMethod()]
        public void CalculateTestComplexDivide()
        {
            var exampleDto = new ExampleDto
            {
                FirstNumber = 1,
                SecondNumber = 3,
                Operation = "/",
                RealNum = true
            };
            var result = CalculationService.Calculate(exampleDto);
            Assert.AreEqual(0.33333333333333331, result);
        }
    }
}