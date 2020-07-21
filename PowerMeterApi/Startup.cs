using System;
using DbUp;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PowerMeterApi.Models;
using PowerMeterApi.Services;

namespace PowerMeterApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string connectionString = "Server=localhost;Database=meter_db;User Id=sa;Password=Pass1234";
            services.AddDbContext<MeterDbContext>(opts =>
                opts.UseSqlServer(connectionString));
            services.AddScoped<IMeterService, MeterService>();
            services.AddControllers();
            this.DbUp(connectionString);
        }

        public void DbUp(string connectionString)
        {
            EnsureDatabase.For.SqlDatabase(connectionString);

            var dbUpgradeEngineBuilder = DeployChanges.To
                .SqlDatabase(connectionString)
                .WithScriptsFromFileSystem("Scripts")
                .WithTransaction()
                .LogToConsole();

            var dbUpgradeEngine = dbUpgradeEngineBuilder.Build();
            if (dbUpgradeEngine.IsUpgradeRequired())
            {
                Console.WriteLine("Upgrades have been detected. Upgrading database now...");
                var operation = dbUpgradeEngine.PerformUpgrade();
                if (operation.Successful)
                {
                    Console.WriteLine("Upgrade completed successfully");
                }

                Console.WriteLine("Error happened in the upgrade. Please check the logs");
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
