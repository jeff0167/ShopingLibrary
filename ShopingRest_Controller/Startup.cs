using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopingLibrary;
using ShopingRest_Controller.Models;
using Microsoft.EntityFrameworkCore;

namespace ShopingRest_Controller
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
            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                        builder => builder.WithOrigins("http://zealand.dk").
                        AllowAnyMethod().
                        AllowAnyHeader()
                    );

                options.AddPolicy("AllowAny",
                        builder => builder.AllowAnyOrigin().
                        AllowAnyMethod().
                        AllowAnyHeader()
                    );

                options.AddPolicy("AllowOnlyGetPut",
                        builder => builder.AllowAnyOrigin().
                        WithMethods("GET", "PUT").
                        AllowAnyHeader()
                    );
            });
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ShopingRest_Controller", Version = "v1" });
            });
            services.AddDbContext<ItemsContext>(opt =>
          opt.UseSqlServer(MySecrets.path));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ShopingRest_Controller v1"));
            }

            app.UseRouting();

            app.UseCors("AllowAny");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
