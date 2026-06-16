using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EscapeRoom_1.Models;

namespace EscapeRoom_1.Controllers;

public class HomeController : Controller
{
    // Byt svaret har om ni andrar pusslets losning.
    private const string Room1CorrectAnswer = "komet";

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Room1()
    {
        ViewBag.HintCount = 0;
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Room1(string playerAnswer, int hintCount, string actionType)
    {
        ViewBag.PlayerAnswer = playerAnswer;
        ViewBag.HintCount = hintCount;

        if (actionType == "hint")
        {
            ViewBag.HintCount = Math.Min(hintCount + 1, 4);
            return View();
        }

        if (NormalizeAnswer(playerAnswer).Equals(NormalizeAnswer(Room1CorrectAnswer), StringComparison.OrdinalIgnoreCase))
        {
            ViewBag.IsSolved = true;
            return View();
        }

        ViewBag.ErrorMessage = "Fel kod. Luftslussen \u00E4r fortfarande l\u00E5st.";
        return View();
    }

    private static string NormalizeAnswer(string? answer)
    {
        return string.Join(" ", (answer ?? "").Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries));
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
