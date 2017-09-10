using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Primitives;
using System.Collections.Generic;

namespace AspNetCoreMvcCryptoValueProvider
{
    public class CryptoValueProvider : BindingSourceValueProvider
    {
        string _encryptedParameters;
        CryptoParamsProtector _protector;
        Dictionary<string, string> _values;

        public CryptoValueProvider(BindingSource bindingSource, CryptoParamsProtector protector, string encryptedParameters)
            : base(bindingSource)
        {
            _encryptedParameters = encryptedParameters;
            _protector = protector;
        }

        public override bool ContainsPrefix(string prefix)
        {
            if (_values == null)
            {
                if (string.IsNullOrEmpty(_encryptedParameters))
                {
                    _values = new Dictionary<string, string>();
                }
                else
                {
                    _values = _protector.DecryptToParamDictionary(_encryptedParameters);
                }
            }

            return _values.ContainsKey(prefix.ToLower());
        }

        public override ValueProviderResult GetValue(string key)
        {
            if (_values.ContainsKey(key.ToLower()))
            {
                return new ValueProviderResult(new StringValues(_values[key.ToLower()]));
            }
            else
            {
                return ValueProviderResult.None;
            }
        }
    }
}
