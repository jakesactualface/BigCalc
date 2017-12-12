using BigCalc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StringArithmeticTest
{
    [TestClass]
    public class AdditionTest
    {
        [TestMethod]
        public void SmallAdditionTest_Success()
        {
            const string lhs = "2";
            const string rhs = "3";
            const string correctResult = "5";

            var result = lhs.Addition(rhs);

            Assert.AreEqual(correctResult, result,
                $"Expected for {lhs} + {rhs} : {result}; Actual: {correctResult}");
        }

        [TestMethod]
        public void LargeLeftOperandTest_Success()
        {
            const string lhs = "9999999999999999999999999999999999999999";
            const string rhs = "5";
            const string correctResult = "10000000000000000000000000000000000000004";

            var result = lhs.Addition(rhs);

            Assert.AreEqual(correctResult, result,
                $"Expected for {lhs} + {rhs} : {result}; Actual: {correctResult}");
        }

        [TestMethod]
        public void LargeRightOperandTest_Success()
        {
            const string lhs = "5";
            const string rhs = "9999999999999999999999999999999999999999";
            const string correctResult = "10000000000000000000000000000000000000004";

            var result = lhs.Addition(rhs);

            Assert.AreEqual(correctResult, result,
                $"Expected for {lhs} + {rhs} : {result}; Actual: {correctResult}");
        }

        [TestMethod]
        public void LargeAdditionTest_Success()
        {
            const string lhs = "9999999999999999999999999999999999999999";
            const string rhs = "9999999999999999999999999999999999999999";
            const string correctResult = "19999999999999999999999999999999999999998";

            var result = lhs.Addition(rhs);

            Assert.AreEqual(correctResult, result,
                $"Expected for {lhs} + {rhs} : {result}; Actual: {correctResult}");
        }
    }
}
