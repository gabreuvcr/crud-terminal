using System;

namespace Laboratory.Services
{
    public static class ValidInput
    {
        public static int Int(string text, int? limit = null)
        {
            int value;
            Console.Write($"{text} ");
            try
            {
                value = Int32.Parse(Console.ReadLine().Trim());
                if (value <= 0 || (limit != null && value > limit)) 
                    return -1; 
                return value;
            }
            catch
            {
                return -1;
            }
        }

        public static double Decimal(string text)
        {
            double value;
            Console.Write($"{text} ");
            try
            {
                value = Double.Parse(Console.ReadLine().Trim());
                if (value < 0)
                    return -1;
                return value;
            }
            catch
            {
                return -1;
            }
        }

        public static string String(string text)
        {
            string value;
            Console.Write($"{text} ");
            try 
            {
                value = Console.ReadLine().Trim();
                if (value.Equals("") || value.Equals("\n"))
                    return "";
                return value;
            }
            catch 
            {
                return "";
            }
        }
    }
}
