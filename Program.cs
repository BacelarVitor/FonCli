using HtmlAgilityPack;


var web = new HtmlWeb();

var user = "BacelarVitor";
var doc = web.Load($"https://github.com/{user}");
var fon = doc.DocumentNode.QuerySelectorAll("td.ContributionCalendar-day[data-date]");
fon.ToList().ForEach(x => Console.WriteLine(x.OuterHtml));