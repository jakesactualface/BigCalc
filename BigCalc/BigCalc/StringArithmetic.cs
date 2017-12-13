using System;
using System.Collections.Generic;
using System.Text;

namespace BigCalc
{
    public static class StringArithmetic
    {
        private const char ZeroChar = '0';
        private const char NegationChar = '-';
        private const char DecimalChar = '.';
        private const int Base = 10;

        private static List<char> AcceptableChars { get; } = new List<char>
        {
            '0',
            '1',
            '2',
            '3',
            '4',
            '5',
            '6',
            '7',
            '8',
            '9',
            '.',
            '-'
        };

        public static string Addition(this string lhs, string rhs)
        {
            lhs = ParseNumeric(lhs);
            rhs = ParseNumeric(rhs);

            var leftNegative = CheckNegative(lhs);
            var rightNegative = CheckNegative(rhs);
            var subtractionLogic = leftNegative != rightNegative;
            var result = new StringBuilder();
            var carry = false;
            var inputLength = PadToEqualLength(ref lhs, ref rhs);

            var index = inputLength - 1;
            var stopIndex = leftNegative || rightNegative ? 1 : 0;

            while (index >= stopIndex)
            {
                var leftDigit = lhs[index] - ZeroChar;
                var rightDigit = rhs[index] - ZeroChar;
                int nextDigit;

                nextDigit = subtractionLogic
                    ? ProcessSubtract(leftDigit, rightDigit, carry)
                    : ProcessAdd(leftDigit, rightDigit, carry);

                if (subtractionLogic)
                {
                    carry = carry
                        ? nextDigit != leftDigit - rightDigit - 1
                        : nextDigit != leftDigit - rightDigit;
                }
                else
                {
                    carry = carry 
                        ? nextDigit != leftDigit + rightDigit + 1 
                        : nextDigit != leftDigit + rightDigit;
                }

                result.Insert(0, nextDigit.ToString());
                index--;
            }

            return FinalizeResult(result, leftNegative, rightNegative, carry);
        }

        private static bool CheckNegative(string str)
        {
            var result = str[0].Equals(NegationChar);

            return result;
        }

        private static string CreateFinalChars(bool leftNegative, bool rightNegative, bool carry)
        {
            var result = new StringBuilder();

            if (leftNegative && rightNegative)
            {
                result.Append(NegationChar);
            }
            else if (leftNegative && !carry)
            {
                result.Append(NegationChar);
            }
            else if (rightNegative && carry)
            {
                result.Append(NegationChar);
            }

            if (leftNegative == rightNegative && carry)
            {
                result.Append('1');
            }

            return result.ToString();
        }

        private static string FinalizeResult(StringBuilder builder, bool leftNegative, bool rightNegative, bool carry)
        {
            builder.Insert(0, CreateFinalChars(leftNegative, rightNegative, carry));

            var result = ParseNumeric(builder.ToString());

            if (result.Equals($"{NegationChar}"))
            {
                result = ZeroChar.ToString();
            }

            return result;
        }

        private static bool IsValid(char character)
        {
            return AcceptableChars.Contains(character);
        }

        private static int PadToEqualLength(ref string lhs, ref string rhs)
        {
            var maxLength = Math.Max(lhs.Length, rhs.Length);

            if (lhs.Length < maxLength)
            {
                lhs = lhs.PadLeft(maxLength, ZeroChar);
            }
            if (rhs.Length < maxLength)
            {
                rhs = rhs.PadLeft(maxLength, ZeroChar);
            }

            return maxLength;
        }

        private static string ParseNumeric(string str)
        {
            var builder = new StringBuilder();
            var leadingZeros = true;

            foreach (var character in str)
            {
                if (!IsValid(character)) continue;

                if (character.Equals(NegationChar))
                {
                    builder.Append(character);
                    continue;
                }

                if (!character.Equals(ZeroChar))
                {
                    // occurs on first instance of non-zero number
                    leadingZeros = false;
                }

                if (!leadingZeros)
                {
                    builder.Append(character);
                }
            }

            // catch case when string is empty
            if (builder.Length == 0)
            {
                builder.Append(ZeroChar);
            }

            return builder.ToString();
        }

        private static int ProcessAdd(int lhs, int rhs, bool carry)
        {
            // add 1 when a carry occurred
            var newDigit = carry ? lhs + rhs + 1 : lhs + rhs;

            // new digit is modulo arithmetic base
            if (newDigit >= Base)
            {
                newDigit -= Base;
            }

            return newDigit;
        }

        private static int ProcessSubtract(int lhs, int rhs, bool carry)
        {
            // subtract 1 when a carry occurred
            var newDigit = carry ? lhs - rhs - 1 : lhs - rhs;

            // new digit is always positive
            if (newDigit < 0)
            {
                newDigit = Math.Abs(newDigit);
            }

            return newDigit;
        }
    }
}
