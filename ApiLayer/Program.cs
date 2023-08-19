using System.Text;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/test", (HttpRequest req) =>
{
    // response all headers
    var headers = req.Headers;
    var response = new StringBuilder();
    foreach (var header in headers) response.Append($"{header.Key}: {header.Value}\n");

    return response.ToString();
});
app.Run();