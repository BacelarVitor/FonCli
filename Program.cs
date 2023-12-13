using HtmlAgilityPack;
using System;

var web = new HtmlWeb();

var users = new string[2] { "BacelarVitor", "omatheusribeiro" };
var score = new Dictionary<string, int>();
foreach (var user in users)
{
    var flin = (GetNumberOfCommits(web, user));
    score.Add(flin.Key, flin.Value);
}

ShowScore(score);

static void ShowScore(Dictionary<string, int> score)
{
    Console.WriteLine($"|  ------------------------------------  |");
    Console.WriteLine($"|                Score board             |");
    Console.WriteLine($"|  ------------------------------------  |");
    Console.WriteLine($"|  User  | Days Committed |  Days Left   |");
    Console.WriteLine($"|  ------------------------------------  |");
    foreach (var item in score)
    {
        Console.WriteLine($"|   {item.Key} |    {item.Value}    | {100 - item.Value} |");
    }
    Console.WriteLine($"|  ------------------------------------  |");
    Console.WriteLine($"| Winning: {score.OrderByDescending(x => x.Value).First().Key} with {score.OrderByDescending(x => x.Value).First().Value} days committed! |");
}

static KeyValuePair<string, int> GetNumberOfCommits(HtmlWeb web, string user)
{
    var doc = web.Load($"https://github.com/{user}");
    var fon = doc.DocumentNode.QuerySelectorAll("td.ContributionCalendar-day[data-date]");
    var challengeBeginningDate = new DateTime(2023, 9, 7);
    var flin = fon.ToList().Where(x =>
    {
        var rawDate = x.Attributes["data-date"].Value.Split('-');
        int.TryParse(x.Attributes["data-level"].Value, out var level);
        var date = new DateTime(int.Parse(rawDate[0]), int.Parse(rawDate[1]), int.Parse(rawDate[2]));
        return DateTime.Compare(date, challengeBeginningDate) >= 0 && level > 0;
    }).Count();
    return new KeyValuePair<string, int>(user, flin);
}