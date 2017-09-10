using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreMvcCryptoValueProvider
{
    [AttributeUsage(AttributeTargets.Method)]
    public class CryptoValueProviderAttribute : Attribute, IResourceFilter
    {
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            context.ValueProviderFactories.Clear();
            context.ValueProviderFactories.Add(new CryptoValueProviderFactory());
        }
    }
}
