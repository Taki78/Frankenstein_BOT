using System;
using System.Collections.Generic;
using System.Text;

namespace Frankenstein_BOT.Utilities
{
    public static class LinkGenerator
    {

        public static StringBuilder GenerateSingleVariableleLink(string Url,int E_to = 1, int E_from = 1, string S_char = "*")
        {

            StringBuilder links = new StringBuilder();

            do
            {
                links.AppendLine(Url.Replace("*", E_from.ToString()));
                E_from++;
            } while (E_from <= E_to);

            return links;
        }

        //public static List<string> GenerateCupleVariableleLink()
        //{

        //}

        public static string FixNumber(int number)
        {
            if (number < 10)
            {
                string str = number.ToString();
                return str.Replace("0", "00")
                    .Replace("1", "01")
                    .Replace("2", "02")
                    .Replace("3", "03")
                    .Replace("4", "04")
                    .Replace("5", "05")
                    .Replace("6", "06")
                    .Replace("7", "07")
                    .Replace("8", "08")
                    .Replace("9", "09");
            }
            return number.ToString();
        }

        public static int GetNumFromStr(this string str)
        {
            string fixStr = string.Empty;
            int val = 1;
            for (int i = 0; i < str.Length; i++)
            {
                if (Char.IsDigit(str[i]))
                {
                    fixStr += str[i];
                }
                if (fixStr.Length > 1)
                    val = int.Parse(fixStr);
            }

            return val;
        }
    }
}
