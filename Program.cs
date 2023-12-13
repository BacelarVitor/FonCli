using HtmlAgilityPack;
using System;

var web = new HtmlWeb();

var user = "BacelarVitor";
var doc = web.Load($"https://github.com/{user}");
var fon = doc.DocumentNode.QuerySelectorAll("td.ContributionCalendar-day[data-date]");
var challengeBeginningDate = new DateTime(2023, 9, 7);
var flin = fon.ToList().Where(x => {
    var rawDate = x.Attributes["data-date"].Value.Split('-');
    int.TryParse(x.Attributes["data-level"].Value, out var level);
    var date = new DateTime(int.Parse(rawDate[0]), int.Parse(rawDate[1]), int.Parse(rawDate[2]));
    return DateTime.Compare(date, challengeBeginningDate) >= 0 && level > 0;
}).Count();

Console.WriteLine($"|                Score board             |");
Console.WriteLine($"|  ------------------------------------  |");
Console.WriteLine($"|  User  | Days Committed |  Days Left   |");
Console.WriteLine($"|  ------------------------------------  |");
Console.WriteLine($"|   {user} |    {flin}    | {100-flin} |");
Console.WriteLine($"|  ------------------------------------  |");
// Console.WriteLine($"|  ------------------------------------  |");
// Console.WriteLine($"|                 Winning                |");
// Console.WriteLine($"|  ------------------------------------  |");
// Console.WriteLine($"|  {getWinner()}   |");
