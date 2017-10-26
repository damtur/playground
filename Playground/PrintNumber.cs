using System;

namespace Playground
{
    public class Numbers
    {
        private static string[] digits = {"", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", 
            "ten", "eleven", "twelwe", "thirteen", "fourteen", "fiveteen", "sixteen", "seventeen", "eighteen", 
            "nineteen"};

        private static string[] tens = {"","twenty", "thirty", "fourty", "fivty", "sixty", "seventy", "eighty", "ninety"};

        private static string[] tousents = {"","tousents", "millions", "billions"};


        public static void printNumber(int number)
        {
            var currentTousent = 0;
            var finalNumber = "";

            while (number > 0)
            {
                var current = "";
                var tempNumber = number % 1000;

                if (tempNumber > 100)
                {
                    var hundrades = tempNumber / 100;
                    current = current + digits[hundrades] + (hundrades > 1 ? " hundreds " : " hundred ");
                    tempNumber %= 100;
                }

                if (tempNumber > 20)
                {
                    current = current + tens[tempNumber / 10] + " ";
                    tempNumber %= 10;
                    current = current + digits[tempNumber];
                }
                else
                {
                    current = current + digits[tempNumber];
                }

                current = current + " " + tousents[currentTousent] + " ";

                finalNumber = current + finalNumber;
                currentTousent++;
                number /= 1000;
            }
            
            Console.WriteLine(finalNumber); 
        }

        public static void PrintNumber()
        {
            printNumber(1);
            printNumber(10);
            printNumber(4674);
            printNumber(9674);
            printNumber(4614);
            printNumber(1111111);
            printNumber(3244204);
        }
    }
}