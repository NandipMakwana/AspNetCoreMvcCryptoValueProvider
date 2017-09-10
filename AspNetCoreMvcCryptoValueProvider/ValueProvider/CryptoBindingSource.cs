using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace AspNetCoreMvcCryptoValueProvider
{
    public class CryptoBindingSource
    {
        public static readonly BindingSource Crypto = new BindingSource(
                  "Crypto",
                  "BindingSource_Crypto",
                  isGreedy: false,
                  isFromRequest: true);
    }
}
