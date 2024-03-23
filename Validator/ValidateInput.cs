

namespace Homework.Validator
{
    static public class ValidateInput
    {
        public static int Result { get; set; }

        public static int ValidateNumber()
        {
            Console.WriteLine("Enter a number between 1-1000:");
            while (true)
            {
                var input = Console.ReadLine();
                if (int.TryParse(input, out var value))
                {
                    if (value > 0 && value < 1000)
                    {
                        Result = value;
                        Console.Clear();
                        return Result;
                    }
                    else
                    {
                        Console.WriteLine("Input is out of range");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input");
                }
            }
        }

        public static int ValidateTask()
        {
            Console.WriteLine("Enter a number between 1-100:");
            while (true)
            {
                var input = Console.ReadLine();
                if (int.TryParse(input, out var value))
                {
                    if (value > 0 && value < 100)
                    {
                        Result = value;
                        return Result;
                    }
                    else
                    {
                        Console.WriteLine("Input is out of range");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input");
                }
            }
        }
    }
}
