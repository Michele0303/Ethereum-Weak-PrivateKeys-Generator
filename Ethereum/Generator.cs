using Nethereum.Hex.HexConvertors.Extensions;
using Nethereum.Signer;

namespace Ethereum_Weak_Keys_Generator.Ethereum
{
    class Generator
    {
        public static string GetPublicAddress(string privateKey)
        {
            var key = new EthECKey(privateKey.HexToByteArray(), true);
            return key.GetPublicAddress();
        }

        public static string GetPrivateKey(string hex)
        {
            var key = new EthECKey(hex.HexToByteArray(), true);
            return key.GetPrivateKey();
        }
    }
}
