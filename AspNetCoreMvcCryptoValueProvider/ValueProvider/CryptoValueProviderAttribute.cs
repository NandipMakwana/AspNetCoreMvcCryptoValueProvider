using Microsoft.AspNetCore.Mvc.Filters;
using System;

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
