using HtmlAgilityPack;


var web = new HtmlWeb();

var user = "BacelarVitor";
var doc = web.Load($"https://github.com/{user}");
Console.WriteLine(doc.Text);