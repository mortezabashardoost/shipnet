using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Shipnet.Filters;

namespace Shipnet
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
            services.AddControllers(options => {
                
                // adding customized Exception Serilizer Filter
                options.Filters.Add<JsonExceptionFilter>();

                // adding filter to prevent user to access using http
                options.Filters.Add<RequireHttpsOrCloseAttribute>();
            
            }).AddNewtonsoftJson(options => {
                    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            });

            // Adding CORS policies
            services.AddCors(options => {
                
                // CORS policy for Dev environment
                options.AddPolicy("DevelopmentCors", policy => {
                    policy.AllowAnyOrigin();
                });

                // CORS policy for Production environment
                options.AddPolicy("ProductionCors", policy => {
                    policy.WithOrigins("www.production.com");
                });
            });

            services.AddRouting(options => options.LowercaseUrls = true);
            
            // Adding Swagger document and configure it
            services.AddSwaggerDocument(config =>
            {
                config.PostProcess = document =>
                {
                    document.Info.Version = "v1";
                    document.Info.Title = "Shipnet API";
                    document.Info.Description = "A brief explanation on Shipnet API";
                    document.Info.TermsOfService = "None";
                    document.Info.Contact = new NSwag.OpenApiContact
                    {
                        Name = "Morteza Bashardoost",
                        Email = "morteza.bashardoost@gmail.com",
                        Url = "https://github.com/mortezabashardoost"
                    };
                    document.Info.License = new NSwag.OpenApiLicense
                    {
                        Name = "Use under LICX",
                        Url = "https://example.com/license"
                    };
                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                
                // Use Swager in development mode only
                app.UseOpenApi();
                app.UseSwaggerUi3();

                // Enable CORS for Development
                app.UseCors("DevelopmentCors");
            }
            else
            {
                app.UseHsts();

                // Enable CORS for Production
                app.UseCors("ProductionCors");
            }

            // Disabled below line due to using RequireHttpsOrCloseAttribute Filter
            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
