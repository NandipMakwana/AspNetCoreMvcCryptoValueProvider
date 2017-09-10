using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreMvcCryptoValueProvider
{
    public class CryptoValueProvider : BindingSourceValueProvider
    {
        public CryptoValueProvider(BindingSource bindingSource) : base(bindingSource)
        {

        }

        public override bool ContainsPrefix(string prefix)
        {
            throw new NotImplementedException();
        }

        public override ValueProviderResult GetValue(string key)
        {
            throw new NotImplementedException();
        }
    }
}
