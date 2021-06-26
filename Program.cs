using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

namespace testmvc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.Console()
                //.WriteTo.SQLite(sqliteDbPath: Environment.CurrentDirectory + @"/Logs/log.db")
                .WriteTo.MSSqlServer("Server=localhost;Database=TestMVC_DB;Trusted_Connection=True;", tableName: "LogTable")
                .WriteTo.File("Logs/logs.txt", rollingInterval:RollingInterval.Month)
                .CreateLogger();
                //.ReadFrom.Configuration(configuration)
                //.CreateLogger();

            try 
            {
                Log.Information("Starting Web Host");
                CreateHostBuilder(args).Build().Run();
            }
            catch(Exception ex)
            {
                Log.Fatal(ex, "Host Terminated Unexpedtedly");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
