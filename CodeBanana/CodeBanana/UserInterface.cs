using CodeBanana;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BananaCode
{
    public static class UserInterface
    {
        public static void Wait(double deciseconds)
        {
            for (double i = 0; i < deciseconds - 1; i += 1)
            {
                Task.Delay(100).Wait();
            }
            Task.Delay(100).Wait();
        }

        public static void Wait(double deciseconds, bool dots)
        {
            for (double i = 0; i < deciseconds - 1; i += 1)
            {
                Task.Delay(100).Wait();
                if (i == 9 || i == 19 || i == 29 || i == 39 || i == 49 || i == 59 || i == 69 || i == 79 || i == 89 || i == 99) Console.Write(".");
            }
            Console.WriteLine();
            Task.Delay(100).Wait();
        }

        public static void WaitRandom(double deciseconds)
        {
            Random r = new Random();
            int random = r.Next(-5, 5);
            for (double i = 0; i < (deciseconds + random) - 1; i += 1)
            {
                Task.Delay(100).Wait();
            }
            Task.Delay(100).Wait();
        }

        public static void WaitForEnter()
        {
            bool enterPressed = false;
            while (!enterPressed)
            {
                try
                {
                    Console.Write("\n\n**Press <Enter> to continue**\n");
                    ConsoleKeyInfo cki = Console.ReadKey();
                    if (cki.Key == ConsoleKey.Enter) enterPressed = true;
                }
                catch (ArgumentException e)
                {
                    Console.Write("That input is invalid.");
                }
            }
        }

        public static bool BooleanInput()
        {
            bool answer = false;
            bool awaitResponse = true;
            string input = "";

            while (awaitResponse)
            {
                try
                {
                    Console.WriteLine();
                    input = Console.ReadLine().ToLower();
                    answer = UserInterface.CheckAnswer(input);
                    awaitResponse = false;
                }
                catch (ArgumentException e)
                {
                    Console.Write("You must give me a valid response to move forward");
                }
            }
            Console.WriteLine();
            return answer;
        }

        public static bool CheckAnswer(string i)
        {
            if (i == "true" || i == "yes" || i == "1" || i == "y")
            {
                return true;
            }
            else if (i == "false" || i == "no" || i == "0" || i == "n")
            {
                return false;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public static string NameInput()
        {
            string input = "";
            bool awaitResponse = true;
            string name = "";
            while (awaitResponse)
            {
                try
                {
                    Console.WriteLine();
                    UserInterface.Wait(10);
                    input = Console.ReadLine();
                    name = UserInterface.CheckName(input);
                    awaitResponse = false;
                }
                catch (ArgumentException e)
                {
                    Console.Write("Tell me your frickin name.");
                }
            }
            Console.WriteLine();
            return name;
        }

        public static string CheckName(string i)
        {
            if (i.Length >= 2 && i.All(char.IsLetter))
            {
                i = string.Concat(i[0].ToString().ToUpper(), i.ToLower().AsSpan(1));
                return i;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public static async Task<string> CodeInput()
        {
            Program.TakeCodeInput = false;
            string input = "";
            bool awaitResponse = true;
            while (awaitResponse)
            {
                try
                {
                    //Console.WriteLine();
                    input = await GetInputAsync();
                    await ProcessCode(input);
                    awaitResponse = false;
                }
                catch (ArgumentException e)
                {
                    Console.Write("That input is invalid.");
                }
            }
            Program.TakeCodeInput = true;
            return input;
        }

        private static async Task<string> GetInputAsync()
        {
            string input = await Task.Run(() => Console.ReadLine());
            return input;
        }

        public static async Task ProcessCode(string input)
        {
            if (input.Equals("banana += 1;") || input.Equals("banana++;"))
            {
                Bananaverse.Bananas++;
                Console.WriteLine($"You have added 1 banana. There are now {Bananaverse.Bananas.ToString("#")} bananas remaining.");
            }
            else if (input.Equals("banana += 10;"))
            {
                Bananaverse.Bananas += 10;
                Console.WriteLine($"You have added 10 bananas. There are now {Bananaverse.Bananas.ToString("#")} bananas remaining.");
            }
            else if (input.Equals("Bananaverse.AddBananaTree();"))
            {
                Bananaverse.AddBananaTree();
            }
            else
            {
                Console.WriteLine("Your code is invalid. Try again.");
            }
            Program.TakeCodeInput = true;
        }
    }
}