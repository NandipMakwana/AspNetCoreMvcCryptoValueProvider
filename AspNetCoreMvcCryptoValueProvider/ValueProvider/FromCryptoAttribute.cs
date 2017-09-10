using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreMvcCryptoValueProvider
{
    [AttributeUsage(AttributeTargets.Parameter)]
    public class FromCryptoAttribute : Attribute, IBindingSourceMetadata
    {
        public BindingSource BindingSource => CryptoBindingSource.Crypto;
    }
}
