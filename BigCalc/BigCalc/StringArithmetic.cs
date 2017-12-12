using System;
using System.Collections.Generic;
using System.Text;

namespace BigCalc
{
    public static class StringArithmetic
    {
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

        private const char IdentityChar = '0';

        public static string Addition(this string lhs, string rhs)
        {
            ParseString(ref lhs);
            ParseString(ref rhs);

            var result = new StringBuilder();
            var carry = 0;
            var inputLength = PadToEqualLength(ref lhs, ref rhs);

            if (inputLength == 0)
            {
                result.Append(IdentityChar);
                return result.ToString();
            }

            while (inputLength > 0)
            {
                var newDigit = (lhs[inputLength - 1] - '0') + (rhs[inputLength - 1] - '0') +
                               carry;

                if (newDigit > 9)
                {
                    carry = 1;
                    newDigit -= 10;
                }
                else
                {
                    carry = 0;
                }

                result.Insert(0, newDigit.ToString());
                inputLength--;
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

        private static void ParseString(ref string str)
        {
            var builder = new StringBuilder();
            var leadingZeros = true;

            foreach (var character in str)
            {
                if (!IsValid(character)) continue;

                if (!IsZero(character))
                {
                    leadingZeros = false;
                }

                if (!leadingZeros)
                {
                    builder.Append(character);
                }
            }

            str = builder.ToString();
        }
    }
}
