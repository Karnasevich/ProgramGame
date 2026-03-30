using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

string RenderComment(string userInput)
{
    string html = $"<div class='comment'>{userInput}</div>";
    return html;
}

app.MapGet("/", (HttpContext context) =>
{
    string userInput = context.Request.Query["comment"];

    string commentHtml = "";

    if (!string.IsNullOrEmpty(userInput))
    {
        commentHtml = RenderComment(userInput);
    }

    string page = $@"
    <html>
    <body>
        <h2>Comments</h2>

        <form>
            <input name='comment' placeholder='Write comment'>
            <button type='submit'>Send</button>
        </form>

        <h3>Last comment:</h3>
        {commentHtml}

    </body>
    </html>";

    return Results.Content(page, "text/html");
});

app.Run();