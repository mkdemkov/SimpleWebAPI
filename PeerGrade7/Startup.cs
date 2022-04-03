using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.IO;

namespace PeerGrade7
{
    /// <summary>
    /// Служебный класс.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Конструктор, принимающий объект типа IConfiguration и инициализирующий соответствующее свойство.
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Конфигурация.
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Этот метод вызывается средой выполнения. Используйте этот метод для добавления служб в контейнер.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PeerGrade7", Version = "v1" });
                var filePath = Path.Combine(AppContext.BaseDirectory, "XmlDocumentation.xml");               
                c.IncludeXmlComments(filePath);
            });
        }

        /// <summary>
        /// Этот метод вызывается средой выполнения. Используйте этот метод для настройки конвейера HTTP-запросов.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PeerGrade7 v1"));
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
