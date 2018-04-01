using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ResvCo.Db;
using ResvCo.Repository;
using ResvCo.Services;


namespace ResvCo
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
            services.AddMvc();
            var connectionString = Configuration["DbContextSettings:ConnectionString"];  
            services.AddDbContext<ApplicationContext>(opts => opts.UseNpgsql(connectionString));  
            
            //noverio comment : Add repository to service scope
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            //noverio comment end.

            //noverio comment : Add service to mvc razor factory
            services.AddTransient<IUserMgmtService, Services.ServiceImpl.UserMgmtService>();
            //noverio comment end
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

             //Create database on startup  
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())  
            {  
                serviceScope.ServiceProvider.GetService<ApplicationContext>().Database.Migrate();  
            }  
        }
    }
}
