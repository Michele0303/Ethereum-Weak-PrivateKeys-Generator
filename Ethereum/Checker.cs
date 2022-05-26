using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Ethereum_Weak_Keys_Generator.Ethereum
{
    class Checker
    {
        private static readonly HttpClient _httpClient = new HttpClient()
        {
            BaseAddress = new Uri("https://receipt.emerald.cash"),
        };

        public static async Task<string> GetBalanceAsync(string wallet)
        {
            var sourcePage = await _httpClient.GetStringAsync($"/balance/{wallet}");

            var ethBalance = Regex.Match(sourcePage, "title=\"(.*?)\".*?</div>", RegexOptions.Compiled).Groups[1].Value;
            if (string.IsNullOrEmpty(ethBalance))
                return "0.0";

            return ethBalance;
        }
    }
}
