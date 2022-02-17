using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

using CommandAPI.Data;
namespace CommandAPI
{
    public class Startup
    {

        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        //The above configuation is for adding the connection string

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=39890  
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            //Read the connectionstring from appsettings.json
            services.AddDbContext<CommandContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("DbConnection")));

            //Applying Dependency Injection
            services.AddScoped<ICommandAPIRepo, MockCommandAPIRepo>();

            services.AddScoped<ICommandAPIRepo, SqlCommandAPIRepo>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                // endpoints.MapGet("/", async context =>
                // {
                //     await context.Response.WriteAsync("Hello World!");
                // });

                endpoints.MapControllers();
            });
        }
    }
}
