using System;
using System.Linq;
using System.Text;
using StringMath.Common;

namespace StringMath
{
    public static class StringAddition
    {
        private static Operand LeftOperand { get; set; }
        private static Operand RightOperand { get; set; }
        private static bool AdditionLogic { get; set; }
        private static bool SignFlipOccurred { get; set; }
        private static bool CarryOccurred { get; set; }

        /// <summary>
        /// Performs the addition of two strings, interpreted as numeric values.
        /// </summary>
        /// <param name="lhs">Left-hand side operand of the addition (can be negative)</param>
        /// <param name="rhs">Right-hand side operand of the addition (can be negative)</param>
        /// <returns>Numeric result of the addition, as a string</returns>
        public static string ArithmeticAdd(this string lhs, string rhs)
        {
            SignFlipOccurred = false;
            CarryOccurred = false;
            LeftOperand = ParseOperand(lhs);
            RightOperand = ParseOperand(rhs);

            PadOperandLengths();
            AdditionLogic = CheckForAdditionLogic();

            var result = AddOperands();

            return result.ToNumericString();
        }

        private static string AddNumericStrings(string leftInput, string rightInput)
        {
            var result = new StringBuilder();
            var startingIndex = leftInput.Length - 1;

            for (var i = startingIndex; i >= 0; i--)
            {
                var leftDigit = leftInput[i] - Constants.ZeroCharacter;
                var rightDigit = rightInput[i] - Constants.ZeroCharacter;

                var nextDigit = AdditionLogic
                    ? leftDigit + rightDigit + (CarryOccurred ? 1 : 0)
                    : leftDigit - rightDigit - (CarryOccurred ? 1 : 0);

                CarryOccurred = AdditionLogic ? nextDigit >= 10 : nextDigit < 0;

                if (CarryOccurred)
                {
                    nextDigit = AdditionLogic ? nextDigit % 10 : Math.Abs(nextDigit);
                }

                result.Insert(0, nextDigit.ToString());
            }

            return result.ToString();
        }

        private static Operand AddOperands()
        {
            var result = new Operand();

            result.Decimals = AddNumericStrings(LeftOperand.Decimals, RightOperand.Decimals);
            result.Integers = AddNumericStrings(LeftOperand.Integers, RightOperand.Integers);

            if (CarryOccurred)
            {
                if (AdditionLogic)
                {
                    result.Integers = $"1{result.Integers}";
                }
                else
                {
                    SignFlipOccurred = true;
                }
            }

            result.IsNegative = SignFlipOccurred ? !LeftOperand.IsNegative : LeftOperand.IsNegative;
            result.HasDecimal = result.Decimals.Length > 0;

            if (result.Integers.Length == 0)
            {
                result.Integers = Constants.ZeroCharacter.ToString();
            }

            if (result.Digits.Equals(Constants.ZeroCharacter.ToString()))
            {
                result.IsNegative = false;
            }

            return result;
        }

        private static bool CheckForAdditionLogic()
        {
            return LeftOperand.IsNegative == RightOperand.IsNegative;
        }

        private static void PadOperandDecimalLengths()
        {
            if (LeftOperand.Decimals.Length < RightOperand.Decimals.Length)
            {
                LeftOperand.Decimals =
                    LeftOperand.Decimals.PadRight(RightOperand.Decimals.Length, Constants.ZeroCharacter);
            }
            else
            {
                RightOperand.Decimals =
                    RightOperand.Decimals.PadRight(LeftOperand.Decimals.Length, Constants.ZeroCharacter);
            }
        }

        private static void PadOperandIntegerLengths()
        {
            if (LeftOperand.Integers.Length < RightOperand.Integers.Length)
            {
                LeftOperand.Integers =
                    LeftOperand.Integers.PadLeft(RightOperand.Integers.Length, Constants.ZeroCharacter);
            }
            else
            {
                RightOperand.Integers =
                    RightOperand.Integers.PadLeft(LeftOperand.Integers.Length, Constants.ZeroCharacter);
            }
        }

        private static void PadOperandLengths()
        {
            PadOperandIntegerLengths();
            PadOperandDecimalLengths();
        }

        private static bool CheckDecimal(string str)
        {
            return str.Contains(Constants.DecimalCharacter.ToString());
        }

        private static bool CheckNegative(string str)
        {
            return str.StartsWith(Constants.NegationCharacter);
        }

        private static string GetDecimalString(string input)
        {
            var builder = new StringBuilder();

            if (CheckDecimal(input))
            {
                for (var i = input.Length - 1; i >= 0 && !input[i].Equals(Constants.DecimalCharacter); i--)
                {
                    builder.Insert(0, input[i]);
                }
            }

            return builder.ToString();
        }

        private static string GetIntegerString(string input)
        {
            var builder = new StringBuilder();

            foreach (var character in input)
            {
                if (character.Equals(Constants.NegationCharacter)) continue;

                if (character.Equals(Constants.DecimalCharacter)) break;

                builder.Append(character);
            }

            return builder.ToString();
        }

        private static string GetValidCharacters(string input)
        {
            var builder = new StringBuilder();
            var negationPlacePassed = false;
            var negationPresent = false;
            var decimalPresent = false;

            foreach (var character in input)
            {
                if (!IsValid(character)) continue;

                // only accept negative sign if it is first valid character
                if (character.Equals(Constants.NegationCharacter) && negationPlacePassed)
                {
                    negationPresent = true;

                    break;
                }

                negationPlacePassed = true;

                // early exit if more than one decimal character is present
                if (character.Equals(Constants.DecimalCharacter))
                {
                    if (decimalPresent) break;

                    decimalPresent = true;
                }

                builder.Append(character);
            }

            // remove negation character for string trimming
            if (negationPresent)
            {
                builder.Remove(0, 1);
            }

            var result = builder.ToString();

            if (decimalPresent)
            {
                // trim zero character from both ends of string
                result = result.Trim(Constants.ZeroCharacter);
                builder = new StringBuilder(result);

                if (result.StartsWith(Constants.DecimalCharacter))
                {
                    builder.Insert(0, Constants.ZeroCharacter);
                }

                if (result.EndsWith(Constants.ZeroCharacter))
                {
                    builder.Remove(builder.Length - 1, 1);
                }
            }
            else
            {
                // trim zero character from beginning of string
                builder = new StringBuilder(result.TrimStart(Constants.ZeroCharacter));

                if (builder.Length == 0)
                {
                    builder.Append(Constants.ZeroCharacter);
                }
            }

            if (negationPresent)
            {
                builder.Insert(0, Constants.NegationCharacter);
            }

            return builder.ToString();
        }

        private static bool IsValid(char character)
        {
            return Constants.AcceptableChars.Contains(character);
        }

        private static Operand ParseOperand(string input)
        {
            var result = new Operand();
            input = GetValidCharacters(input);

            result.IsNegative = CheckNegative(input);
            result.HasDecimal = CheckDecimal(input);
            result.Integers = GetIntegerString(input);
            result.Decimals = GetDecimalString(input);

            return result;
        }
    }
}
