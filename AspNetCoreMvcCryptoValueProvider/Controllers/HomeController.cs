using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreMvcCryptoValueProvider.Models;

namespace AspNetCoreMvcCryptoValueProvider.Controllers
{
    public class HomeController : Controller
    {
        CryptoParamsProtector _protector;

        public HomeController(CryptoParamsProtector protector)
        {
            _protector = protector;
        }

        public IActionResult Index()
        {
            #region Example 1 - All Parameters
            var paramDictionary = new Dictionary<string, string>();
            paramDictionary.Add("param1", 1234.ToString());
            paramDictionary.Add("param2", "Hello World!");
            ViewBag.encryptedRouteParam1 = _protector.EncryptParamDictionary(paramDictionary);
            #endregion

            #region Example 2 - Crypto values combined with visible values
            var person = new Person()
            {
                PersonId = 1234,
                FirstName = "Nandip",
                LastName = "Makwana"
            };

            paramDictionary = new Dictionary<string, string>();
            paramDictionary.Add("secretPersonId", person.PersonId.ToString());
            paramDictionary.Add("secretParam2", 5678.ToString());
            ViewBag.encryptedRouteParam2 = _protector.EncryptParamDictionary(paramDictionary);            
            #endregion

            return View(person);
        }
    }
}
