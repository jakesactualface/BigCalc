using System;
using System.Collections.Generic;
using System.Text;

namespace BigCalc
{
    public static class StringArithmetic
    {
        // TODO remove this after testing
        private const char DebugChar = '$';

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
            lhs = ParseOperand(lhs);
            rhs = ParseOperand(rhs);

            var usesAddLogic = CheckAddition(lhs, rhs);
            var result = new StringBuilder();
            var carry = false;
            var inputLength = PadToEqualLength(ref lhs, ref rhs);

            var index = inputLength - 1;
            var stopIndex = usesAddLogic ? 0 : 1;

            while (index >= stopIndex)
            {
                var leftDigit = lhs[index] - ZeroChar;
                var rightDigit = rhs[index] - ZeroChar;
                int nextDigit;

                nextDigit = usesAddLogic
                    ? ProcessAdd(leftDigit, rightDigit, carry)
                    : ProcessSubtract(leftDigit, rightDigit, carry);

                if (nextDigit != leftDigit + rightDigit)
                {
                    carry = true;
                }

                result.Insert(0, nextDigit.ToString());
                index--;
            }

            var finalChar = CreateFinalChar(usesAddLogic, carry);

            if (carry)
            {
                result.Insert(0, finalChar);
            }

            return result.ToString();
        }

        // TODO better name after figuring out how I want this to work
        private static bool CheckAddition(string lhs, string rhs)
        {
            // addition logic is only needed when individual numbers are added
            // this occurs when neither operand is negative, or when both are negative
            return CheckNegative(lhs) == CheckNegative(rhs);
        }

        private static bool CheckNegative(string str)
        {
            var result = str[0].Equals(NegationChar);

            return result;
        }

        private static char CreateFinalChar(bool additionLogic, bool carry)
        {
            var result = DebugChar;

            if (additionLogic)
            {
                result = '1';
            }
            else if (carry)
            {
                result = '-';
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

        private static string ParseOperand(string str)
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
