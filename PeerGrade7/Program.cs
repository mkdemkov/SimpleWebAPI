using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace PeerGrade7
{
    /// <summary>
    /// Основной класс программы.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Точка входа в программу.
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// Универсальный узел.
        /// </summary>
        /// <param name="args"></param>
        /// <returns>Объект типа IHostBuilder.</returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
