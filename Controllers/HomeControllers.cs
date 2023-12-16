using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using _932101.Nasution.Rafly.lab12.Models;

namespace _932101.Nasution.Rafly.lab12.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Manual()
    {
        if (Request.Method == "POST")
        {
            try
            {
                var calculatorModel = new Model
                {
                    num1 = Int32.Parse(HttpContext.Request.Form["num1"]),
                    operation = HttpContext.Request.Form["operation"],
                    num2 = Int32.Parse(HttpContext.Request.Form["num2"])
                };

                ViewData["Result"] = calculatorModel.Evaluate();
            }
            catch
            {
                ViewData["Result"] = "Invalid input";
            }

            return View("Result");
        }
        return View("Calc");
    }

    [HttpGet]
    [ActionName("ManualSeparate")]
    public IActionResult ManualWithSeparateHandlersGet()
    {
        return View("Calc");
    }

    [HttpPost]
    [ActionName("ManualSeparate")]
    public IActionResult ManualWithSeparateHandlersPost()
    {
        try
        {
            var calculatorModel = new Model
            {
                num1 = Int32.Parse(HttpContext.Request.Form["num1"]),
                operation = HttpContext.Request.Form["operation"],
                num2 = Int32.Parse(HttpContext.Request.Form["num2"])
            };

            ViewData["Result"] = calculatorModel.Evaluate();
        }
        catch
        {
            ViewData["Result"] = "Invalid input";
        }

        return View("Result");
    }

    [HttpGet]
    [ActionName("ModelParams")]
    public IActionResult ModelBindingInParametersGet()
    {
        return View("Calc");
    }

    [HttpPost]
    [ActionName("ModelParams")]
    public IActionResult ModelBindingInParametersPost(int num1, string operation, int num2)
    {
        if (ModelState.IsValid)
        {
            var calculatorModel = new Model
            {
                num1 = num1,
                num2 = num2,
                operation = operation
            };

            ViewData["Result"] = calculatorModel.Evaluate();
        }
        else
        {
            ViewData["Result"] = "Invalid input";
        }

        return View("Result");
    }

    [HttpGet]
    [ActionName("ModelSeparate")]
    public IActionResult ModelBindingInSeparateModelGet()
    {
        return View("Calc");
    }

    [HttpPost]
    [ActionName("ModelSeparate")]
    public IActionResult ModelBindingInSeparateModelPost(Model model)
    {
        if (ModelState.IsValid)
        {
            ViewData["Result"] = model.Evaluate();
        }
        else
        {
            ViewData["Result"] = "Invalid input";
        }

        return View("Result");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}