using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace AuthorizationAndAuthentication
{
    // public class Program
    // {
    //     public static void Main(string[] args)
    //     {
    //         BuildWebHost(args).Run();
    //     }

    //     public static IWebHost BuildWebHost(string[] args) =>
    //         WebHost.CreateDefaultBuilder(args)
            
    //             .UseStartup<Startup>()
    //             //.UseKestrel()
    //             // .ConfigureAppConfiguration((hostingContext, config) =>
    //             //     {
    //             //         var env = hostingContext.HostingEnvironment;
    //             //         config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    //             //             .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);
    //             //         config.AddEnvironmentVariables();
    //             //     })
    //             // .ConfigureLogging((hostingContext, logging) =>
    //             // {
    //             //     logging.AddConsole();
    //             //     logging.AddDebug();
    //             // })
    //             .Build();
    // }

    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>() .UseStartup<Startup>().UseKestrel(option =>
                {
                        option.ListenAnyIP(6001);

                });
    }
    
}
