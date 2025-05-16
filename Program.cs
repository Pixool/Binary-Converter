using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_Converter
{
    internal class Program
    {
        static string ReverseString(string String)
        {
            string NewString = string.Empty;
            foreach (char c in String){
                NewString = c + NewString;
            }
            return NewString;
        }

        static string CheckBinary(string BinaryString)
        {
            foreach (char c in BinaryString)
            {
                if (c != '1' && c != '0') BinaryString = BinaryString.Replace(Convert.ToString(c), "");
            }
            return BinaryString;
        }

        static long CheckDinary(string Dinary)
        {
            foreach (char c in Dinary)
            {
                if (!int.TryParse(Convert.ToString(c), out _)) Dinary = Dinary.Replace(Convert.ToString(c), "");
            }
            long DinaryNum;
            if (Dinary == "") DinaryNum = -1;
            else long.TryParse(Dinary, out DinaryNum);
            return DinaryNum;
        } 

        static string ConvertToBinary(long Number)
        {
            string BinaryString = string.Empty;
            while (Number > 0)
            {
                if (Number % 2 == 0) BinaryString += "0";
                else BinaryString += "1";
                Number /= 2;
            }
            return ReverseString(BinaryString);
        }
        static int ConvertToNumber(string BinaryString)
        {
            int Number = 0;
            BinaryString = ReverseString(BinaryString);
            int index = 0;

            foreach (char c in BinaryString)
            {
                if (c == '1') Number += Convert.ToInt32(Math.Pow(2, index));
                index++;
            }

            return Number;
        }
        static void Main(string[] args)
        {
            bool InvalidInput = false;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Binary Converter!");
                Console.WriteLine("-----------------");
                Console.WriteLine("Binary to Dinary (Number) - 1");
                Console.WriteLine("Dinary (Number) to Binary - 2");
                Console.WriteLine("-----------------");
                if (InvalidInput) Console.WriteLine("Invalid input..");
                Console.Write("Which option do you want to do?: ");
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D1:
                        InvalidInput = false;
                        while (true)
                        {
                            Console.Clear();
                            Console.WriteLine("Binary Converter!");
                            Console.WriteLine("-----------------");
                            Console.WriteLine("Convert a binary string to dinary (number)");
                            Console.WriteLine("-----------------");
                            if (InvalidInput) Console.WriteLine("Invalid input..");
                            Console.Write("Enter binary string: ");
                            string BinaryString = CheckBinary(Console.ReadLine());
                            if (BinaryString == "") InvalidInput = true;
                            else
                            {
                                int Number = ConvertToNumber(BinaryString);
                                Console.Clear();
                                Console.WriteLine("Binary Converter!");
                                Console.WriteLine("-----------------");
                                Console.WriteLine($"Your binary string: {BinaryString}");
                                Console.WriteLine($"Your dinary (number): {Number}");
                                Console.WriteLine("");
                                Console.Write("Another binary number (b) or main menu? (m): ");
                                if (Console.ReadKey().Key == ConsoleKey.M) break;
                            }
                        }
                        break;
                    case ConsoleKey.D2:
                        InvalidInput = false;
                        while (true)
                        {
                            Console.Clear();
                            Console.WriteLine("Binary Converter!");
                            Console.WriteLine("-----------------");
                            Console.WriteLine("Convert dinary (number) string to a binary string");
                            Console.WriteLine("-----------------");
                            if (InvalidInput) Console.WriteLine("Invalid input..");
                            Console.Write("Enter dinary (number): ");
                            long DinaryNum = CheckDinary(Console.ReadLine());
                            if (DinaryNum < 0) InvalidInput = true;
                            else
                            {
                                string BinaryString = ConvertToBinary(DinaryNum);
                                Console.Clear();
                                Console.WriteLine("Binary Converter!");
                                Console.WriteLine("-----------------");
                                Console.WriteLine($"Your dinary (number): {DinaryNum}");
                                Console.WriteLine($"Your binary string: {BinaryString}");
                                Console.WriteLine("");
                                Console.Write("Another binary number (b) or main menu? (m): ");
                                if (Console.ReadKey().Key == ConsoleKey.M) break;
                            }
                        }
                        break;
                    default:
                        InvalidInput = true;
                        break;
                }
            }
        }
    }
}