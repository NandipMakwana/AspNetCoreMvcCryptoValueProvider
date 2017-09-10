using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Threading.Tasks;

namespace AspNetCoreMvcCryptoValueProvider
{
    public class CryptoValueProviderFactory : IValueProviderFactory
    {
        public Task CreateValueProviderAsync(ValueProviderFactoryContext context)
        {
            var paramsProtector = (CryptoParamsProtector)context.ActionContext.HttpContext
                .RequestServices.GetService(typeof(CryptoParamsProtector));

            context.ValueProviders.Add(new CryptoValueProvider(CryptoBindingSource.Crypto
                , paramsProtector
                , context.ActionContext.RouteData.Values["id"]?.ToString()));

            return Task.CompletedTask;
        }
    }
}
