using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Hosting;

namespace PracticalAspNetCore
{
    public class SimpleOption
    {
        public string ContentPath { get; set; }
    }

    public class Startup
    {
        IHostEnvironment _env;
        public Startup(IHostEnvironment env)
        {
            _env = env;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<SimpleOption>(option =>
            {
                option.ContentPath = _env.ContentRootPath;
            });
        }

        public void Configure(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                context.Response.ContentType = "text/html";
                var simpleOption = context.RequestServices.GetService<IOptions<SimpleOption>>();

                await context.Response.WriteAsync($"{simpleOption.Value.ContentPath}");
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