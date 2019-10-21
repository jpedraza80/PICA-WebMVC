using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Pica.Taller.Mvc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true)
                .AddJsonFile($"appsettings.{environment}.json", optional: true)
                .Build();

            var webHost = WebHost.CreateDefaultBuilder(args)
                .UseUrls(
                    $"http://localhost:{config.GetValue<int>("Host:HttpPort")}",
                    $"https://localhost:{config.GetValue<int>("Host:HttpsPort")}")
                .UseStartup<Startup>();

            return webHost;
        }
    }
}