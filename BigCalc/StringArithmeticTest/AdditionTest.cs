using BigCalc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StringArithmeticTest
{
    [TestClass]
    public class AdditionTest
    {

        #region integer tests

        [TestMethod]
        public void ZeroTrimTest_Success()
        {
            const string lhs = "0000000000000";
            const string rhs = "0000000000000";
            const string correctResult = "0";

            var result = lhs.Addition(rhs);

            Assert.AreEqual(correctResult, result,
                $"Expected for {lhs} + {rhs} : {correctResult}; Actual: {result}");
        }

        [TestMethod]
        public void ZeroLhsTrimTest_Success()
        {
            const string lhs = "0000000000000";
            const string rhs = "0";
            const string correctResult = "0";

            var result = lhs.Addition(rhs);

            Assert.AreEqual(correctResult, result,
                $"Expected for {lhs} + {rhs} : {correctResult}; Actual: {result}");
        }

        [TestMethod]
        public void ZeroRhsTrimTest_Success()
        {
            const string lhs = "0";
            const string rhs = "0000000000000";
            const string correctResult = "0";

            var result = lhs.Addition(rhs);

            Assert.AreEqual(correctResult, result,
                $"Expected for {lhs} + {rhs} : {correctResult}; Actual: {result}");
        }

        [TestMethod]
        public void ZeroSmallTest_Success()
        {
            const string lhs = "0";
            const string rhs = "0";
            const string correctResult = "0";

            var result = lhs.Addition(rhs);

            Assert.AreEqual(correctResult, result,
                $"Expected for {lhs} + {rhs} : {correctResult}; Actual: {result}");
        }

        [TestMethod]
        public void SmallTest_Success()
        {
            const string lhs = "2";
            const string rhs = "3";
            const string correctResult = "5";

            var result = lhs.Addition(rhs);

            Assert.AreEqual(correctResult, result,
                $"Expected for {lhs} + {rhs} : {correctResult}; Actual: {result}");
        }

        [TestMethod]
        public void LargeLeftOperandTest_Success()
        {
            const string lhs = "9999999999999999999999999999999999999999";
            const string rhs = "5";
            const string correctResult = "10000000000000000000000000000000000000004";

            var result = lhs.Addition(rhs);

            Assert.AreEqual(correctResult, result,
                $"Expected for {lhs} + {rhs} : {correctResult}; Actual: {result}");
        }

        [TestMethod]
        public void LargeRightOperandTest_Success()
        {
            const string lhs = "5";
            const string rhs = "9999999999999999999999999999999999999999";
            const string correctResult = "10000000000000000000000000000000000000004";

            var result = lhs.Addition(rhs);

            Assert.AreEqual(correctResult, result,
                $"Expected for {lhs} + {rhs} : {correctResult}; Actual: {result}");
        }

        [TestMethod]
        public void LargeTest_Success()
        {
            const string lhs = "9999999999999999999999999999999999999999";
            const string rhs = "9999999999999999999999999999999999999999";
            const string correctResult = "19999999999999999999999999999999999999998";

            var result = lhs.Addition(rhs);

            Assert.AreEqual(correctResult, result,
                $"Expected for {lhs} + {rhs} : {correctResult}; Actual: {result}");
        }

        [TestMethod]
        public void PollutedLhsTest_Success()
        {
            const string lhs = "11111q11111";
            const string rhs = "1111111111";
            const string correctResult = "2222222222";

            var result = lhs.Addition(rhs);

            Assert.AreEqual(correctResult, result,
                $"Expected for {lhs} + {rhs} : {correctResult}; Actual: {result}");
        }

        [TestMethod]
        public void PollutedRhsTest_Success()
        {
            const string lhs = "1111111111";
            const string rhs = "11111r11111";
            const string correctResult = "2222222222";

            var result = lhs.Addition(rhs);

            Assert.AreEqual(correctResult, result,
                $"Expected for {lhs} + {rhs} : {correctResult}; Actual: {result}");
        }

        [TestMethod]
        public void PollutedBothTest_Success()
        {
            const string lhs = "11111Q11111";
            const string rhs = "11111R11111";
            const string correctResult = "2222222222";

            var result = lhs.Addition(rhs);

            Assert.AreEqual(correctResult, result,
                $"Expected for {lhs} + {rhs} : {correctResult}; Actual: {result}");
        }

        [TestMethod]
        public void NegativeLhsPositiveResultTest_Success()
        {
            const string lhs = "-2";
            const string rhs = "3";
            const string correctResult = "1";

            var result = lhs.Addition(rhs);

            Assert.AreEqual(correctResult, result,
                $"Expected for {lhs} + {rhs} : {correctResult}; Actual: {result}");
        }

        [TestMethod]
        public void NegativeRhsPositiveResultTest_Success()
        {
            const string lhs = "3";
            const string rhs = "-1";
            const string correctResult = "2";

            var result = lhs.Addition(rhs);

            Assert.AreEqual(correctResult, result,
                $"Expected for {lhs} + {rhs} : {correctResult}; Actual: {result}");
        }

        [TestMethod]
        public void NegativeLhsNegativeResultTest_Success()
        {
            const string lhs = "-3";
            const string rhs = "2";
            const string correctResult = "-1";

            var result = lhs.Addition(rhs);

            Assert.AreEqual(correctResult, result,
                $"Expected for {lhs} + {rhs} : {correctResult}; Actual: {result}");
        }

        [TestMethod]
        public void NegativeRhsNegativeResultTest_Success()
        {
            const string lhs = "-3";
            const string rhs = "1";
            const string correctResult = "-2";

            var result = lhs.Addition(rhs);

            Assert.AreEqual(correctResult, result,
                $"Expected for {lhs} + {rhs} : {correctResult}; Actual: {result}");
        }

        [TestMethod]
        public void NegativeLhsZeroResultTest_Success()
        {
            const string lhs = "-3";
            const string rhs = "3";
            const string correctResult = "0";

            var result = lhs.Addition(rhs);

            Assert.AreEqual(correctResult, result,
                $"Expected for {lhs} + {rhs} : {correctResult}; Actual: {result}");
        }

        [TestMethod]
        public void NegativeRhsZeroResultTest_Success()
        {
            const string lhs = "1";
            const string rhs = "-1";
            const string correctResult = "0";

            var result = lhs.Addition(rhs);

            Assert.AreEqual(correctResult, result,
                $"Expected for {lhs} + {rhs} : {correctResult}; Actual: {result}");
        }

        [TestMethod]
        public void NegativeSmallTest_Success()
        {
            const string lhs = "-3";
            const string rhs = "-2";
            const string correctResult = "-5";

            var result = lhs.Addition(rhs);

            Assert.AreEqual(correctResult, result,
                $"Expected for {lhs} + {rhs} : {correctResult}; Actual: {result}");
        }

        [TestMethod]
        public void NegativeLargeTest_Success()
        {
            const string lhs = "-9999999999999999999999999999999999999999";
            const string rhs = "-9999999999999999999999999999999999999999";
            const string correctResult = "-19999999999999999999999999999999999999998";

            var result = lhs.Addition(rhs);

            Assert.AreEqual(correctResult, result,
                $"Expected for {lhs} + {rhs} : {correctResult}; Actual: {result}");
        }

        [TestMethod]
        public void NegativeLhsLargeZeroResultTest_Success()
        {
            const string lhs = "-9999999999999999999999999999999999999999";
            const string rhs = "9999999999999999999999999999999999999999";
            const string correctResult = "0";

            var result = lhs.Addition(rhs);

            Assert.AreEqual(correctResult, result,
                $"Expected for {lhs} + {rhs} : {correctResult}; Actual: {result}");
        }

        [TestMethod]
        public void NegativeRhsLargeZeroResultTest_Success()
        {
            const string lhs = "9999999999999999999999999999999999999999";
            const string rhs = "-9999999999999999999999999999999999999999";
            const string correctResult = "0";

            var result = lhs.Addition(rhs);

            Assert.AreEqual(correctResult, result,
                $"Expected for {lhs} + {rhs} : {correctResult}; Actual: {result}");
        }

        #endregion

    }
}
