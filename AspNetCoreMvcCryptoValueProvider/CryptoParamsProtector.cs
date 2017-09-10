using Microsoft.AspNetCore.DataProtection;
using System.Collections.Generic;
using System.Linq;

namespace AspNetCoreMvcCryptoValueProvider
{
    public class CryptoParamsProtector
    {
        IDataProtector _protector;

        public CryptoParamsProtector(IDataProtectionProvider dataProtectionProvider)
        {
            _protector = dataProtectionProvider.CreateProtector(GetType().FullName);
        }

        public string EncryptParamDictionary(Dictionary<string, string> parameters)
        {
            var paramsInSingleString = string.Join("+", parameters
                .Select(p => string.Format("{0}={1}", p.Key.ToLower(), p.Value)));
            return _protector.Protect(paramsInSingleString);
        }

        public Dictionary<string, string> DecryptToParamDictionary(string encryptedParameters)
        {
            var paramsInSingleString = string.Empty;
            try
            {
                paramsInSingleString = _protector.Unprotect(encryptedParameters);
            }
            catch
            {
                //return empty dictionary when string encryptedParameters is not protected with _protector
                return new Dictionary<string, string>();
            }
            return paramsInSingleString.Split('+')
                .Select(p => p.Split('='))
                .ToDictionary(p => p[0], p => p[1]);
        }
    }
}
