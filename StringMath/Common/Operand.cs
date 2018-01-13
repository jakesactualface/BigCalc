using System.Text;

namespace StringMath.Common
{
    public class Operand
    {
        public string Digits => Integers + Decimals;
        public string Integers { get; set; }
        public string Decimals { get; set; }
        public bool IsNegative { get; set; }
        public bool HasDecimal { get; set; }

        public string ToNumericString()
        {
            var builder = new StringBuilder();

            Integers = Integers.TrimStart(Constants.ZeroCharacter);
            Decimals = Decimals.TrimEnd(Constants.ZeroCharacter);

            if (Digits.Length > 0)
            {
                if (IsNegative)
                {
                    builder.Append(Constants.NegationCharacter);
                }

                builder.Append(Integers);

                if (HasDecimal)
                {
                    builder.Append(Constants.DecimalCharacter);
                    builder.Append(Decimals);
                }
            }
            else
            {
                builder.Append(Constants.ZeroCharacter);
            }

            return builder.ToString();
        }
    }
}