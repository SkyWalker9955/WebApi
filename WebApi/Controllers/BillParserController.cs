using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

public class BillParserController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}