using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;

namespace PracticalAspNetCore
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                context.Response.Headers.Add("content-type", "text/html");

                await context.Response.WriteAsync("<html><body>");
                await context.Response.WriteAsync("<h1>All query string</h1>");
                await context.Response.WriteAsync(@"<a href=""?message=hello&message=world&message=again&isTrue=1&morning=good"">click this link to add query string</a><br/><br/>");
                await context.Response.WriteAsync("<ul>");
                foreach (var v in context.Request.Query)
                {
                    string str = v.Value; //implicit conversion from StringValues to String
                    await context.Response.WriteAsync($"<li>{v.Key} - {str}</li>");
                }
                await context.Response.WriteAsync("</ul>");
                await context.Response.WriteAsync("</body></html>");
            });
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                    webBuilder.UseStartup<Startup>()
                );
    }
}