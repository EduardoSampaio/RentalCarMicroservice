
using Microsoft.AspNetCore.Hosting;

namespace Identity.Server;

public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    private static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webbuilder =>
        {
            webbuilder.UseStartup<Startup>();
        });
}
