using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Ethereum_Weak_Keys_Generator
{
    class Utils
    {
        public static void Banner()
        {
            Console.Title = "Ethereum Weak Keys Generator";
            Console.Clear();

            Console.WriteLine(@"
███████╗████████╗██╗░░██╗  ░██╗░░░░░░░██╗███████╗░█████╗░██╗░░██╗  ██╗░░██╗███████╗██╗░░░██╗░██████╗
██╔════╝╚══██╔══╝██║░░██║  ░██║░░██╗░░██║██╔════╝██╔══██╗██║░██╔╝  ██║░██╔╝██╔════╝╚██╗░██╔╝██╔════╝
█████╗░░░░░██║░░░███████║  ░╚██╗████╗██╔╝█████╗░░███████║█████═╝░  █████═╝░█████╗░░░╚████╔╝░╚█████╗░
██╔══╝░░░░░██║░░░██╔══██║  ░░████╔═████║░██╔══╝░░██╔══██║██╔═██╗░  ██╔═██╗░██╔══╝░░░░╚██╔╝░░░╚═══██╗
███████╗░░░██║░░░██║░░██║  ░░╚██╔╝░╚██╔╝░███████╗██║░░██║██║░╚██╗  ██║░╚██╗███████╗░░░██║░░░██████╔╝
╚══════╝░░░╚═╝░░░╚═╝░░╚═╝  ░░░╚═╝░░░╚═╝░░╚══════╝╚═╝░░╚═╝╚═╝░░╚═╝  ╚═╝░░╚═╝╚══════╝░░░╚═╝░░░╚═════╝░");
            Console.WriteLine("\n");
        }

        public static long GetStartIndex()
        {
            Console.Write("Generation starts at [default: 1]? ");

            var input = Console.ReadLine();
            if (!Regex.IsMatch(input, @"^\d+$", RegexOptions.Compiled) || string.IsNullOrEmpty(input) || string.IsNullOrWhiteSpace(input))
                return 1;

            return Convert.ToInt32(input);
        }

        public static void SaveHits(string hex, string privateKey, string address, string balance)
        {
            using var sw = new StreamWriter("hits.txt", append: true);
            sw.WriteLine($"HEX: {hex}\nPRIVKEY: {privateKey}\nADDRESS: {address}\nBalance: {balance}\n\n");
        }
    }
}
