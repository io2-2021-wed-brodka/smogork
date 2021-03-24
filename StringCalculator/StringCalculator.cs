using System;

namespace TDD
{
    public class StringCalculator
    {
        private int atoi(string num)
        {
            if (num.Length == 0)
                return 0;

            if (num[0] == '-')
                throw new ArgumentException("Negative numbers are incorrect.");

            int result = 0;

            for (int i = 0; i < num.Length; ++i)
            {
                result = result * 10 + (num[i] - '0');
            }

            if (result > 1000)
                return 0;

            return result;
            
        }

        private char CustomDelimiter(string delimiterString)
        {
            return delimiterString[2];
        }

        public int Add(string numbers)
        {
            int result = 0;

            //Wyszukanie nowych podzialow
            int firstLineEnd = numbers.IndexOf('\n');
            if (firstLineEnd > 0)
            {
                string delimiter = numbers.Substring(0, firstLineEnd);
                if (delimiter[0] == '/')
                {
                    char customDelimiter = CustomDelimiter(delimiter);
                    numbers = numbers.Replace(customDelimiter, ',');
                }
            }

            string[] values = numbers.Split(new char[]{ ',', '\n'});
            foreach (string val in values)
            {
                result += atoi(val);
            }

            return result;
        }
    }
}
