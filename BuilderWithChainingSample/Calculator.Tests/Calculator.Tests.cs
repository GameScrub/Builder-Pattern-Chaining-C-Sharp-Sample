using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculator.Tests
{
    [TestClass]
    public class BuilderTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var value = BuilderWithChainingSample.Calculator.Start(10).Add(5).Subtract(10).Build();

            Assert.AreEqual(5, value);
        }
    }
}
