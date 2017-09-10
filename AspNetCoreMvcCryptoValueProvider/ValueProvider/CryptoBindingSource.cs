using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
