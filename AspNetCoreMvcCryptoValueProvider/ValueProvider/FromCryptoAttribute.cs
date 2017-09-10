using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;

namespace AspNetCoreMvcCryptoValueProvider
{
    [AttributeUsage(AttributeTargets.Parameter)]
    public class FromCryptoAttribute : Attribute, IBindingSourceMetadata
    {
        public BindingSource BindingSource => CryptoBindingSource.Crypto;
    }
}
