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
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;

using backend_dotnetcore.models;
using backend_dotnetcore.services;

namespace backend_dotnetcore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers().AddJsonOptions(options => {
                                      options.JsonSerializerOptions.IgnoreNullValues = true;
            });

            services.AddTransient<ICrudService<Produto>, ProdutoService>();
            services.AddTransient<ICrudService<Pessoa>, PessoaService>();
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "backend_dotnetcore", Version = "v1" });
            });


            services.AddEntityFrameworkNpgsql()
             .AddDbContext<ProdutoContext>(options => options.UseNpgsql(Configuration.GetConnectionString("vendasDB")))
             .AddDbContext<PessoaContext>(options => options.UseNpgsql(Configuration.GetConnectionString("vendasDB")));
        
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "backend_dotnetcore v1"));
            }

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
