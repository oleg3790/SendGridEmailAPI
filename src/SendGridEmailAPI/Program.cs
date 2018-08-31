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
            /* Add a sendgridconfig.json file to this project that contains a key with a name of "APIKey".
             * This should contain the SendGrid API key for your SendGrid account, and will be the key used 
             * to send emails by this service.
             */

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
