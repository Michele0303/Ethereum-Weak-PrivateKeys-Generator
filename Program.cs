using System;
using System.Threading.Tasks;

namespace Ethereum_Weak_Keys_Generator
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            /* setup */
            Utils.Banner();
            var start = Utils.GetStartIndex();

            Console.WriteLine("\nPress any to start...");
            Console.ReadKey();

            /* start checking */
            while (true)
            {
                var hex = start++.ToString("X64");
                var privateKey = Ethereum.Generator.GetPrivateKey(hex);
                var publicAddress = Ethereum.Generator.GetPublicAddress(privateKey);
                var balance = await Ethereum.Checker.GetBalanceAsync(publicAddress);

                if (double.Parse(balance) > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("[*] FOUND - Saved in hits.txt [*]");
                    Utils.SaveHits(hex, privateKey, publicAddress, balance);
                }
                Console.WriteLine($"HEX: {hex}\nPRIVKEY: {privateKey}\nADDRESS: {publicAddress}\nBalance: {balance}\n\n");

                Console.ResetColor();
            }
        }
    }
}
