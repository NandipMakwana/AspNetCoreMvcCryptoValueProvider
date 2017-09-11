using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreMvcCryptoValueProvider.Models;

namespace AspNetCoreMvcCryptoValueProvider.Controllers
{
    public class DemoController : Controller
    {
        [CryptoValueProvider]
        public IActionResult Example1(int param1, string param2)
        {
            ViewBag.param1 = param1;
            ViewBag.param2 = param2;
            return View();
        }
        
        public IActionResult Example2([FromCrypto]int secretPersonId, [FromCrypto]string secretParam2, Person person)
        {
            person.PersonId = secretPersonId;
            //_repository.UpdatePerson(person);

            ViewBag.secretPersonId = secretPersonId;
            ViewBag.secretParam2 = secretParam2;
            ViewBag.person = person;

            return View();
        }
    }
}