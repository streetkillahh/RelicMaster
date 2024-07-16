using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RelicMaster.DAL;
using System;
using System.Windows;

namespace RelicMaster
{
    public partial class App : Application
    {
        private readonly IHost host;

        public App()
        {
            host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddDbContext<ApplicationDbContext>(options =>
                        options.UseSqlServer(@"Server=DESKTOP-QR4OGUK\SQLEXPRESS;Database=RelicMaster;Trusted_Connection=True;TrustServerCertificate=True"));
                    services.AddSingleton<MainWindow>();
                })
                .Build();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            host.Start();
            var mainWindow = host.Services.GetRequiredService<MainWindow>();
            mainWindow.Show();
            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            await host.StopAsync(TimeSpan.FromSeconds(5));
            host.Dispose();
            base.OnExit(e);
        }
    }
}
