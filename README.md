# MY.AspNetCore.Mvc.ModelBinding

Extending FromQuery to support comma separated query parameters for Model Binding in ASP.NET Core.

## Usage

* Add Reference MY.AspNetCore.Mvc.ModelBinding package

``` json
PM > Install-Package MY.AspNetCore.Mvc.ModelBinding
```

* Add MY.AspNetCore.Mvc.ModelBinding to Mvc or MvcCore

``` c#
using MY.AspNetCore.Mvc.ModelBinding.Extensions;

services
    .AddMvcCore(options =>
    {
        options.ModelBinderProviders.AddFromQueryAsArrayBinding();
    });
```

* In Controller

``` c#

using MY.AspNetCore.Mvc.ModelBinding;

[HttpGet]
public async Task<IActionResult> GetAsync([FromQueryAsArray] string[] includes)
{
    return Ok();
}
```
