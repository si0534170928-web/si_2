using System.Text.RegularExpressions;
async Task<string> Load(string url)
{
    HttpClient client = new HttpClient();
    var response = await client.GetAsync(url);
    Console.WriteLine(response);
    var html = await response.Content.ReadAsStringAsync();
    return html;
}
var html = await Load("https://learn.malkabruk.co.il/practicode/projects/pract-2/#_2");
var cleanHtml =new Regex("\\s").Replace(html," ");
var htmlLines=new Regex("<(.*?)>").Split(cleanHtml).Where(s=>s.Length>0);
var htmlElement = "<div id=\"my-id\" class=\"my-class-1 my-class-2\" width=\"100%\">text</div>";
var attributes = new Regex(@"(\w+)=""(.*?)""").Matches(htmlElement);

foreach (Match match in attributes)
{
    Console.WriteLine($"Attribute: {match.Groups[1].Value}, Value: {match.Groups[2].Value}");
}


