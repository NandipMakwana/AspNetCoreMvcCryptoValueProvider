# ASP.NET Core MVC CryptoValueProvider
Custom Crypto Value Provider in ASP.NET Core MVC to support encrypted query string or route parameter. [More detail on implementation here](http://www.dotnetexpertguide.com/2017/09/aspnet-core-mvc-value-provider-for.html?utm_source=github&utm_medium=referral).

### Example usage:

1. Create action method and mark it with `CryptoValueProvider` attribute or mark some of the parameter with `FromCrypto` attribute

```C#
[CryptoValueProvider]
public IActionResult Example1(int param1, string param2)
{
}
/*OR*/
public IActionResult Example2([FromCrypto]int param1, string param2, [FromCrypto]string param3)
{
}
```
2. Create parameter dictionary and encrypt it with `CryptoParamsProtector`
```C#
public class HomeController : Controller
{
    CryptoParamsProtector _protector;
 
    public HomeController(CryptoParamsProtector protector)
    {
        _protector = protector;
    }
 
    public IActionResult Index()
    {
        var paramDictionary = new Dictionary();
        paramDictionary.Add("param1", 1234.ToString());
        paramDictionary.Add("param2", "Hello World!");
        ViewBag.encryptedRouteParam1 = _protector.EncryptParamDictionary(paramDictionary);
 
        return View();
    }
}
```
3. Use encrypted string as route parameter to generate link
```HTML
<a asp-controller="demo" asp-action="example1" asp-route-id="@ViewBag.encryptedRouteParam1"><h4>Example 1 Demo</h4></a>
```

[Other Examples](https://www.nandipmakwana.com/AspNetCoreMvcCryptoValueProvider/?utm_source=github&utm_medium=referral)
