using System;

namespace Toy.Robot
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*** TOY ROBOT ***");
            Console.WriteLine("_____________");
            Console.WriteLine();
            var instructions = new Instructions(new Robot());

            while (true)
            {
                Console.WriteLine("Enter Command# (q to exit): ");
                string command = Console.ReadLine();
                if (command.ToUpper() == "q" || command.ToUpper() == "Q")
                {
                    Environment.Exit(0);
                }
                Console.WriteLine(instructions.Execute(command));
            }
        }

    }
}
