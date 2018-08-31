using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace SendGridEmailAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(ConfigConfiguration)
                .UseStartup<Startup>();

        static void ConfigConfiguration(WebHostBuilderContext webHostBuilderContext, IConfigurationBuilder configurationBuilder)
        {
            if (File.Exists("sendgridconfig.json"))
            {
                configurationBuilder.SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("sendgridconfig.json", false, true)
                    .AddEnvironmentVariables();
            }
            else
            {
                configurationBuilder.SetBasePath(Directory.GetCurrentDirectory())
                    .AddEnvironmentVariables();
            }

            var config = configurationBuilder.Build();
        }
    }
}
