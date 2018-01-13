using StringMath;
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

            var result = lhs.ArithmeticAdd(rhs);

            Assert.AreEqual(correctResult, result,
                $"Expected for {lhs} + {rhs} : {correctResult}; Actual: {result}");
        }

        [TestMethod]
        public void ZeroLhsTrimTest_Success()
        {
            const string lhs = "0000000000000";
            const string rhs = "0";
            const string correctResult = "0";

            var result = lhs.ArithmeticAdd(rhs);

            Assert.AreEqual(correctResult, result,
                $"Expected for {lhs} + {rhs} : {correctResult}; Actual: {result}");
        }

        [TestMethod]
        public void ZeroRhsTrimTest_Success()
        {
            const string lhs = "0";
            const string rhs = "0000000000000";
            const string correctResult = "0";

            var result = lhs.ArithmeticAdd(rhs);

            Assert.AreEqual(correctResult, result,
                $"Expected for {lhs} + {rhs} : {correctResult}; Actual: {result}");
        }

        [TestMethod]
        public void ZeroSmallTest_Success()
        {
            const string lhs = "0";
            const string rhs = "0";
            const string correctResult = "0";

            var result = lhs.ArithmeticAdd(rhs);

            Assert.AreEqual(correctResult, result,
                $"Expected for {lhs} + {rhs} : {correctResult}; Actual: {result}");
        }

        [TestMethod]
        public void SmallTest_Success()
        {
            const string lhs = "2";
            const string rhs = "3";
            const string correctResult = "5";

            var result = lhs.ArithmeticAdd(rhs);

            Assert.AreEqual(correctResult, result,
                $"Expected for {lhs} + {rhs} : {correctResult}; Actual: {result}");
        }

        [TestMethod]
        public void LargeLeftOperandTest_Success()
        {
            const string lhs = "9999999999999999999999999999999999999999";
            const string rhs = "5";
            const string correctResult = "10000000000000000000000000000000000000004";

            var result = lhs.ArithmeticAdd(rhs);

            Assert.AreEqual(correctResult, result,
                $"Expected for {lhs} + {rhs} : {correctResult}; Actual: {result}");
        }

        [TestMethod]
        public void LargeRightOperandTest_Success()
        {
            const string lhs = "5";
            const string rhs = "9999999999999999999999999999999999999999";
            const string correctResult = "10000000000000000000000000000000000000004";

            var result = lhs.ArithmeticAdd(rhs);

            Assert.AreEqual(correctResult, result,
                $"Expected for {lhs} + {rhs} : {correctResult}; Actual: {result}");
        }

        [TestMethod]
        public void LargeTest_Success()
        {
            const string lhs = "9999999999999999999999999999999999999999";
            const string rhs = "9999999999999999999999999999999999999999";
            const string correctResult = "19999999999999999999999999999999999999998";

            var result = lhs.ArithmeticAdd(rhs);

            Assert.AreEqual(correctResult, result,
                $"Expected for {lhs} + {rhs} : {correctResult}; Actual: {result}");
        }

        [TestMethod]
        public void PollutedLhsTest_Success()
        {
            const string lhs = "11111q11111";
            const string rhs = "1111111111";
            const string correctResult = "2222222222";

            var result = lhs.ArithmeticAdd(rhs);

            Assert.AreEqual(correctResult, result,
                $"Expected for {lhs} + {rhs} : {correctResult}; Actual: {result}");
        }

        [TestMethod]
        public void PollutedRhsTest_Success()
        {
            const string lhs = "1111111111";
            const string rhs = "11111r11111";
            const string correctResult = "2222222222";

            var result = lhs.ArithmeticAdd(rhs);

            Assert.AreEqual(correctResult, result,
                $"Expected for {lhs} + {rhs} : {correctResult}; Actual: {result}");
        }

        [TestMethod]
        public void PollutedBothTest_Success()
        {
            const string lhs = "11111Q11111";
            const string rhs = "11111R11111";
            const string correctResult = "2222222222";

            var result = lhs.ArithmeticAdd(rhs);

            Assert.AreEqual(correctResult, result,
                $"Expected for {lhs} + {rhs} : {correctResult}; Actual: {result}");
        }

        [TestMethod]
        public void NegativeLhsPositiveResultTest_Success()
        {
            const string lhs = "-2";
            const string rhs = "3";
            const string correctResult = "1";

            var result = lhs.ArithmeticAdd(rhs);

            Assert.AreEqual(correctResult, result,
                $"Expected for {lhs} + {rhs} : {correctResult}; Actual: {result}");
        }

        [TestMethod]
        public void NegativeRhsPositiveResultTest_Success()
        {
            const string lhs = "3";
            const string rhs = "-1";
            const string correctResult = "2";

            var result = lhs.ArithmeticAdd(rhs);

            Assert.AreEqual(correctResult, result,
                $"Expected for {lhs} + {rhs} : {correctResult}; Actual: {result}");
        }

        [TestMethod]
        public void NegativeLhsNegativeResultTest_Success()
        {
            const string lhs = "-3";
            const string rhs = "2";
            const string correctResult = "-1";

            var result = lhs.ArithmeticAdd(rhs);

            Assert.AreEqual(correctResult, result,
                $"Expected for {lhs} + {rhs} : {correctResult}; Actual: {result}");
        }

        [TestMethod]
        public void NegativeRhsNegativeResultTest_Success()
        {
            const string lhs = "1";
            const string rhs = "-3";
            const string correctResult = "-2";

            var result = lhs.ArithmeticAdd(rhs);

            Assert.AreEqual(correctResult, result,
                $"Expected for {lhs} + {rhs} : {correctResult}; Actual: {result}");
        }

        [TestMethod]
        public void NegativeLhsZeroResultTest_Success()
        {
            const string lhs = "-3";
            const string rhs = "3";
            const string correctResult = "0";

            var result = lhs.ArithmeticAdd(rhs);

            Assert.AreEqual(correctResult, result,
                $"Expected for {lhs} + {rhs} : {correctResult}; Actual: {result}");
        }

        [TestMethod]
        public void NegativeRhsZeroResultTest_Success()
        {
            const string lhs = "1";
            const string rhs = "-1";
            const string correctResult = "0";

            var result = lhs.ArithmeticAdd(rhs);

            Assert.AreEqual(correctResult, result,
                $"Expected for {lhs} + {rhs} : {correctResult}; Actual: {result}");
        }

        [TestMethod]
        public void NegativeSmallTest_Success()
        {
            const string lhs = "-3";
            const string rhs = "-2";
            const string correctResult = "-5";

            var result = lhs.ArithmeticAdd(rhs);

            Assert.AreEqual(correctResult, result,
                $"Expected for {lhs} + {rhs} : {correctResult}; Actual: {result}");
        }

        [TestMethod]
        public void NegativeLargeTest_Success()
        {
            const string lhs = "-9999999999999999999999999999999999999999";
            const string rhs = "-9999999999999999999999999999999999999999";
            const string correctResult = "-19999999999999999999999999999999999999998";

            var result = lhs.ArithmeticAdd(rhs);

            Assert.AreEqual(correctResult, result,
                $"Expected for {lhs} + {rhs} : {correctResult}; Actual: {result}");
        }

        [TestMethod]
        public void NegativeLhsLargeZeroResultTest_Success()
        {
            const string lhs = "-9999999999999999999999999999999999999999";
            const string rhs = "9999999999999999999999999999999999999999";
            const string correctResult = "0";

            var result = lhs.ArithmeticAdd(rhs);

            Assert.AreEqual(correctResult, result,
                $"Expected for {lhs} + {rhs} : {correctResult}; Actual: {result}");
        }

        [TestMethod]
        public void NegativeRhsLargeZeroResultTest_Success()
        {
            const string lhs = "9999999999999999999999999999999999999999";
            const string rhs = "-9999999999999999999999999999999999999999";
            const string correctResult = "0";

            var result = lhs.ArithmeticAdd(rhs);

            Assert.AreEqual(correctResult, result,
                $"Expected for {lhs} + {rhs} : {correctResult}; Actual: {result}");
        }

        #endregion

        #region decimal tests

        [TestMethod]
        public void DecimalZeroTrimStartTest_Success()
        {
            const string lhs = ".0000000000000";
            const string rhs = ".0000000000000";
            const string correctResult = "0";

            var result = lhs.ArithmeticAdd(rhs);

            Assert.AreEqual(correctResult, result,
                $"Expected for {lhs} + {rhs} : {correctResult}; Actual: {result}");
        }

        [TestMethod]
        public void DecimalZeroTrimMiddleTest_Success()
        {
            const string lhs = "0000000000000.000";
            const string rhs = "0000000000000.000";
            const string correctResult = "0";

            var result = lhs.ArithmeticAdd(rhs);

            Assert.AreEqual(correctResult, result,
                $"Expected for {lhs} + {rhs} : {correctResult}; Actual: {result}");
        }

        [TestMethod]
        public void DecimalZeroTrimEndTest_Success()
        {
            const string lhs = "0000000000000000.";
            const string rhs = "0000000000000000.";
            const string correctResult = "0";

            var result = lhs.ArithmeticAdd(rhs);

            Assert.AreEqual(correctResult, result,
                $"Expected for {lhs} + {rhs} : {correctResult}; Actual: {result}");
        }

        [TestMethod]
        public void DecimalZeroLhsTrimStartTest_Success()
        {
            const string lhs = ".0000000000000";
            const string rhs = "0";
            const string correctResult = "0";

            var result = lhs.ArithmeticAdd(rhs);

            Assert.AreEqual(correctResult, result,
                $"Expected for {lhs} + {rhs} : {correctResult}; Actual: {result}");
        }

        [TestMethod]
        public void DecimalZeroLhsTrimMiddleTest_Success()
        {
            const string lhs = "0000000.000000";
            const string rhs = "0";
            const string correctResult = "0";

            var result = lhs.ArithmeticAdd(rhs);

            Assert.AreEqual(correctResult, result,
                $"Expected for {lhs} + {rhs} : {correctResult}; Actual: {result}");
        }

        [TestMethod]
        public void DecimalZeroLhsTrimEndTest_Success()
        {
            const string lhs = "0000000000000.";
            const string rhs = "0";
            const string correctResult = "0";

            var result = lhs.ArithmeticAdd(rhs);

            Assert.AreEqual(correctResult, result,
                $"Expected for {lhs} + {rhs} : {correctResult}; Actual: {result}");
        }

        [TestMethod]
        public void DecimalZeroRhsTrimStartTest_Success()
        {
            const string lhs = "0";
            const string rhs = ".0000000000000";
            const string correctResult = "0";

            var result = lhs.ArithmeticAdd(rhs);

            Assert.AreEqual(correctResult, result,
                $"Expected for {lhs} + {rhs} : {correctResult}; Actual: {result}");
        }

        [TestMethod]
        public void DecimalZeroRhsTrimMiddleTest_Success()
        {
            const string lhs = "0";
            const string rhs = "000000.0000000";
            const string correctResult = "0";

            var result = lhs.ArithmeticAdd(rhs);

            Assert.AreEqual(correctResult, result,
                $"Expected for {lhs} + {rhs} : {correctResult}; Actual: {result}");
        }

        [TestMethod]
        public void DecimalZeroRhsTrimEndTest_Success()
        {
            const string lhs = "0";
            const string rhs = "0000000000000.";
            const string correctResult = "0";

            var result = lhs.ArithmeticAdd(rhs);

            Assert.AreEqual(correctResult, result,
                $"Expected for {lhs} + {rhs} : {correctResult}; Actual: {result}");
        }

        [TestMethod]
        public void DecimalZeroSmallTest_Success()
        {
            const string lhs = "0.0";
            const string rhs = "0.0";
            const string correctResult = "0";

            var result = lhs.ArithmeticAdd(rhs);

            Assert.AreEqual(correctResult, result,
                $"Expected for {lhs} + {rhs} : {correctResult}; Actual: {result}");
        }

        [TestMethod]
        public void DecimalSmallTest_Success()
        {
            const string lhs = "2.1";
            const string rhs = "3.5";
            const string correctResult = "5.6";

            var result = lhs.ArithmeticAdd(rhs);

            Assert.AreEqual(correctResult, result,
                $"Expected for {lhs} + {rhs} : {correctResult}; Actual: {result}");
        }

        [TestMethod]
        public void DecimalLeftLargeLeftOperandTest_Success()
        {
            const string lhs = "9999999999999999999999999999999999999999.1";
            const string rhs = "5";
            const string correctResult = "10000000000000000000000000000000000000004.1";

            var result = lhs.ArithmeticAdd(rhs);

            Assert.AreEqual(correctResult, result,
                $"Expected for {lhs} + {rhs} : {correctResult}; Actual: {result}");
        }

        [TestMethod]
        public void DecimalLeftLargeRightOperandTest_Success()
        {
            const string lhs = "5.1";
            const string rhs = "9999999999999999999999999999999999999999";
            const string correctResult = "10000000000000000000000000000000000000004.1";

            var result = lhs.ArithmeticAdd(rhs);

            Assert.AreEqual(correctResult, result,
                $"Expected for {lhs} + {rhs} : {correctResult}; Actual: {result}");
        }

        [TestMethod]
        public void DecimalRightLargeLeftOperandTest_Success()
        {
            const string lhs = "9999999999999999999999999999999999999999";
            const string rhs = "5.2";
            const string correctResult = "10000000000000000000000000000000000000004.2";

            var result = lhs.ArithmeticAdd(rhs);

            Assert.AreEqual(correctResult, result,
                $"Expected for {lhs} + {rhs} : {correctResult}; Actual: {result}");
        }

        [TestMethod]
        public void DecimalRightLargeRightOperandTest_Success()
        {
            const string lhs = "5";
            const string rhs = "9999999999999999999999999999999999999999.2";
            const string correctResult = "10000000000000000000000000000000000000004.2";

            var result = lhs.ArithmeticAdd(rhs);

            Assert.AreEqual(correctResult, result,
                $"Expected for {lhs} + {rhs} : {correctResult}; Actual: {result}");
        }

        [TestMethod]
        public void DecimalLeftLargeTest_Success()
        {
            const string lhs = "9999999999999999999999999999999999999999.1";
            const string rhs = "9999999999999999999999999999999999999999";
            const string correctResult = "19999999999999999999999999999999999999998.1";

            var result = lhs.ArithmeticAdd(rhs);

            Assert.AreEqual(correctResult, result,
                $"Expected for {lhs} + {rhs} : {correctResult}; Actual: {result}");
        }

        [TestMethod]
        public void DecimalRightLargeTest_Success()
        {
            const string lhs = "9999999999999999999999999999999999999999";
            const string rhs = "9999999999999999999999999999999999999999.1";
            const string correctResult = "19999999999999999999999999999999999999998.1";

            var result = lhs.ArithmeticAdd(rhs);

            Assert.AreEqual(correctResult, result,
                $"Expected for {lhs} + {rhs} : {correctResult}; Actual: {result}");
        }

        [TestMethod]
        public void DecimalBothLargeTest_Success()
        {
            const string lhs = "9999999999999999999999999999999999999999.2";
            const string rhs = "9999999999999999999999999999999999999999.1";
            const string correctResult = "19999999999999999999999999999999999999998.3";

            var result = lhs.ArithmeticAdd(rhs);

            Assert.AreEqual(correctResult, result,
                $"Expected for {lhs} + {rhs} : {correctResult}; Actual: {result}");
        }

        [TestMethod]
        public void DecimalPollutedLhsTest_Success()
        {
            const string lhs = "11111q11111.1";
            const string rhs = "1111111111";
            const string correctResult = "2222222222.1";

            var result = lhs.ArithmeticAdd(rhs);

            Assert.AreEqual(correctResult, result,
                $"Expected for {lhs} + {rhs} : {correctResult}; Actual: {result}");
        }

        [TestMethod]
        public void DecimalPollutedRhsTest_Success()
        {
            const string lhs = "1111111111";
            const string rhs = "11111r11111.1";
            const string correctResult = "2222222222.1";

            var result = lhs.ArithmeticAdd(rhs);

            Assert.AreEqual(correctResult, result,
                $"Expected for {lhs} + {rhs} : {correctResult}; Actual: {result}");
        }

        [TestMethod]
        public void DecimalPollutedBothTest_Success()
        {
            const string lhs = "11111Q11111.1";
            const string rhs = "11111R11111.1";
            const string correctResult = "2222222222.2";

            var result = lhs.ArithmeticAdd(rhs);

            Assert.AreEqual(correctResult, result,
                $"Expected for {lhs} + {rhs} : {correctResult}; Actual: {result}");
        }

        [TestMethod]
        public void DecimalNegativeLhsPositiveResultTest_Success()
        {
            const string lhs = "-2.2";
            const string rhs = "3";
            const string correctResult = "0.8";

            var result = lhs.ArithmeticAdd(rhs);

            Assert.AreEqual(correctResult, result,
                $"Expected for {lhs} + {rhs} : {correctResult}; Actual: {result}");
        }

        [TestMethod]
        public void DecimalNegativeRhsPositiveResultTest_Success()
        {
            const string lhs = "3.2";
            const string rhs = "-1";
            const string correctResult = "2.2";

            var result = lhs.ArithmeticAdd(rhs);

            Assert.AreEqual(correctResult, result,
                $"Expected for {lhs} + {rhs} : {correctResult}; Actual: {result}");
        }

        [TestMethod]
        public void DecimalNegativeLhsNegativeResultTest_Success()
        {
            const string lhs = "-3.2";
            const string rhs = "2";
            const string correctResult = "-1.2";

            var result = lhs.ArithmeticAdd(rhs);

            Assert.AreEqual(correctResult, result,
                $"Expected for {lhs} + {rhs} : {correctResult}; Actual: {result}");
        }

        [TestMethod]
        public void DecimalNegativeRhsNegativeResultTest_Success()
        {
            const string lhs = "1";
            const string rhs = "-3.2";
            const string correctResult = "-2.2";

            var result = lhs.ArithmeticAdd(rhs);

            Assert.AreEqual(correctResult, result,
                $"Expected for {lhs} + {rhs} : {correctResult}; Actual: {result}");
        }

        [TestMethod]
        public void DecimalNegativeLhsZeroResultTest_Success()
        {
            const string lhs = "-3.1";
            const string rhs = "3.1";
            const string correctResult = "0";

            var result = lhs.ArithmeticAdd(rhs);

            Assert.AreEqual(correctResult, result,
                $"Expected for {lhs} + {rhs} : {correctResult}; Actual: {result}");
        }

        [TestMethod]
        public void DecimalNegativeRhsZeroResultTest_Success()
        {
            const string lhs = "1.2";
            const string rhs = "-1.2";
            const string correctResult = "0";

            var result = lhs.ArithmeticAdd(rhs);

            Assert.AreEqual(correctResult, result,
                $"Expected for {lhs} + {rhs} : {correctResult}; Actual: {result}");
        }

        [TestMethod]
        public void DecimalNegativeSmallTest_Success()
        {
            const string lhs = "-3.4";
            const string rhs = "-2.5";
            const string correctResult = "-5.9";

            var result = lhs.ArithmeticAdd(rhs);

            Assert.AreEqual(correctResult, result,
                $"Expected for {lhs} + {rhs} : {correctResult}; Actual: {result}");
        }

        [TestMethod]
        public void DecimalNegativeLargeTest_Success()
        {
            const string lhs = "-9999999999999999999999999999999999999999.9999999999999999999999999999999";
            const string rhs = "-9999999999999999999999999999999999999999.9999999999999999999999999999999";
            const string correctResult = "-19999999999999999999999999999999999999999.9999999999999999999999999999998";

            var result = lhs.ArithmeticAdd(rhs);

            Assert.AreEqual(correctResult, result,
                $"Expected for {lhs} + {rhs} : {correctResult}; Actual: {result}");
        }

        [TestMethod]
        public void DecimalNegativeLhsLargeZeroResultTest_Success()
        {
            const string lhs = "-9999999999999999999999999999999999999999.999999999999999999997";
            const string rhs = "9999999999999999999999999999999999999999.999999999999999999997";
            const string correctResult = "0";

            var result = lhs.ArithmeticAdd(rhs);

            Assert.AreEqual(correctResult, result,
                $"Expected for {lhs} + {rhs} : {correctResult}; Actual: {result}");
        }

        [TestMethod]
        public void DecimalNegativeRhsLargeZeroResultTest_Success()
        {
            const string lhs = "9999999999999999999999999999999999999999.999999999999999999997";
            const string rhs = "-9999999999999999999999999999999999999999.999999999999999999997";
            const string correctResult = "0";

            var result = lhs.ArithmeticAdd(rhs);

            Assert.AreEqual(correctResult, result,
                $"Expected for {lhs} + {rhs} : {correctResult}; Actual: {result}");
        }

        #endregion

    }
}
