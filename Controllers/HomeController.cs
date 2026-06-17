using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EscapeRoom_1.Models;

namespace EscapeRoom_1.Controllers;

public class HomeController : Controller
{
    private static readonly string[] Room1SpaceWords =
    {
        "komet",
        "planet",
        "raket",
        "satellit",
        "meteor",
        "galax",
        "nebulosa",
        "astronaut",
        "stjarna",
        "solstorm"
    };

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Room1()
    {
        ViewBag.HintCount = 0;
        ViewBag.RevealedLetters = "";
        ViewBag.SecretWord = GetRandomRoom1Word();
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Room1(string playerAnswer, int hintCount, string actionType, string revealedLetters, string secretWord)
    {
        ViewBag.PlayerAnswer = playerAnswer;
        ViewBag.HintCount = Math.Min(Math.Max(hintCount, 0), 2);
        ViewBag.RevealedLetters = revealedLetters ?? "";
        ViewBag.SecretWord = string.IsNullOrWhiteSpace(secretWord) ? GetRandomRoom1Word() : secretWord;

        if (actionType == "hint")
        {
            ViewBag.HintCount = Math.Min(hintCount + 1, 2);
            return View();
        }

        if (NormalizeAnswer(playerAnswer).Equals(NormalizeAnswer(ViewBag.SecretWord), StringComparison.OrdinalIgnoreCase))
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

    private static string GetRandomRoom1Word()
    {
        return Room1SpaceWords[Random.Shared.Next(Room1SpaceWords.Length)];
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
