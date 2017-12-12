using System;
using System.Collections.Generic;
using System.Text;

namespace BigCalc
{
    public static class StringArithmetic
    {
        private static readonly List<char> AcceptableChars = new List<char>
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
            ParseStrings(ref lhs, ref rhs);

            var result = new StringBuilder();
            var carry = 0;
            var inputLength = PadToEqualLength(ref lhs, ref rhs);

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

        private static int PadToEqualLength(ref string lhs, ref string rhs)
        {
            var maxLength = Math.Max(lhs.Length, rhs.Length);

            if (lhs.Length < maxLength)
            {
                lhs = lhs.PadLeft(maxLength, '0');
            }
            if (rhs.Length < maxLength)
            {
                rhs = rhs.PadLeft(maxLength, '0');
            }

            return maxLength;
        }

        private static void ParseStrings(ref string lhs, ref string rhs)
        {
            var builder = new StringBuilder();

            // parse lhs
            foreach (var character in lhs)
            {
                if (IsValid(character))
                {
                    builder.Append(character);
                }

                lhs = builder.ToString();
            }

            builder.Clear();

            // parse rhs
            foreach (var character in rhs)
            {
                if (IsValid(character))
                {
                    builder.Append(character);
                }

                rhs = builder.ToString();
            }
        }
    }
}
