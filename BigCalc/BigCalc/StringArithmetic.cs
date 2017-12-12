using System;

namespace BigCalc
{
    public static class StringArithmetic
    {
        public static string Addition(this string lhs, string rhs)
        {
            // TODO handle parsing

            var result = new System.Text.StringBuilder();
            var inputLength = 0;
            var carry = 0;

            inputLength = System.Math.Max(lhs.Length, rhs.Length);

            if (lhs.Length > rhs.Length)
            {
                rhs = rhs.PadLeft(inputLength, '0');
            }
            else
            {
                lhs = lhs.PadLeft(inputLength, '0');
            }

            while (inputLength > 0)
            {
                var newDigit = ((int) lhs[inputLength - 1] - (int) '0') + ((int) rhs[inputLength - 1] - (int) '0') +
                               carry;

                if (newDigit > 9)
                {
                    carry = newDigit / 10;
                    newDigit %= 10;
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
    }
}
