using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace DoubleEscapeOdata.Controllers
{
    public class FooController: ODataController
    {
        const string ExpectedKey = "key%3A";

        [EnableQuery]
        public IActionResult Get() => Ok(new[] { new Foo(){
            Id = ExpectedKey
        } });

        public IActionResult Get(string key)
        {
            if (key == ExpectedKey)
                return Ok(new Foo()
                {
                    Id = ExpectedKey
                });
            else
                return NotFound();
        }

        [HttpGet]
        public IActionResult MyFunction(string fileName)
        {
            return Ok(fileName);
        }
    }
}
