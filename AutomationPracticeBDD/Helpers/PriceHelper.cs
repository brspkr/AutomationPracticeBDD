using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationPracticeBDD.Helpers
{
    public class PriceHelper
    {

        public double numberExtractor(string text)
        {
            string innerText = string.Empty;
            double number = 0;

            for (int i = 0; i < text.Length; i++)
            {
                if (Char.IsDigit(text[i]))
                    innerText += text[i];
            }

            if (innerText.Length > 0)
            {
                number = double.Parse(innerText);

            }
            return number;

        }

        public double priceExtractor(string Text)
        {
            string subText;

            subText = Text.Substring(1, Text.Length - 1);


            if (subText == null)
            {
                return 0;
            }
            else
            {
                double OutVal;
                double.TryParse(subText, out OutVal);

                if (double.IsNaN(OutVal) || double.IsInfinity(OutVal))
                {
                    return 0;
                }
                return Math.Round(OutVal, 2);
            }
        }

    }
}
