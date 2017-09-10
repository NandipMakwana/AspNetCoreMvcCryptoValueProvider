using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreMvcCryptoValueProvider
{
    public class CryptoValueProviderFactory : IValueProviderFactory
    {
        public Task CreateValueProviderAsync(ValueProviderFactoryContext context)
        {
            context.ValueProviders.Add(new CryptoValueProvider(CryptoBindingSource.Crypto));
            return Task.CompletedTask;
        }
    }
}
