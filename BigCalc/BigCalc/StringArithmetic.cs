using System;
using System.Collections.Generic;
using System.Text;

namespace BigCalc
{
    public static class StringArithmetic
    {
        private const char IdentityChar = '0';
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
            '-',
            '+'
        };

        public static string Addition(this string lhs, string rhs)
        {
            lhs = ParseOperand(lhs);
            rhs = ParseOperand(rhs);

            var result = new StringBuilder();
            var carry = 0;
            var inputLength = PadToEqualLength(ref lhs, ref rhs);

            var index = inputLength - 1;

            while (index >= 0)
            {
                var newDigit = (lhs[index] - '0') + (rhs[index] - '0') +
                               carry;

                if (newDigit >= Base)
                {
                    carry = 1;
                    newDigit -= Base;
                }
                else
                {
                    carry = 0;
                }

                result.Insert(0, newDigit.ToString());
                index--;
            }

            if (carry > 0)
            {
                result.Insert(0, carry.ToString());
            }

            return result.ToString();
        }

        private static bool IsValid(char character)
        {
            return AcceptableChars.Contains(character);
        }

        private static bool IsZero(char character)
        {
            return character.Equals(IdentityChar);
        }

        private static int PadToEqualLength(ref string lhs, ref string rhs)
        {
            var maxLength = Math.Max(lhs.Length, rhs.Length);

            if (lhs.Length < maxLength)
            {
                lhs = lhs.PadLeft(maxLength, IdentityChar);
            }
            if (rhs.Length < maxLength)
            {
                rhs = rhs.PadLeft(maxLength, IdentityChar);
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

                if (!IsZero(character))
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
                builder.Append(IdentityChar);
            }

            return builder.ToString();
        }
    }
}
