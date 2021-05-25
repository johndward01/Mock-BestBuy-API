using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MySql.Data.MySqlClient;
using System.Data;

namespace Mock_BestBuy_API
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
            services.AddControllers();
            services.AddScoped<IDbConnection>(s =>
            {
                IDbConnection conn = new MySqlConnection(Configuration.GetConnectionString("bestbuy"));
                conn.Open();
                return conn;
            });

            services.AddTransient<IProductRepo, ProductRepo>();
            services.AddCors(options =>                         // CORS = Cross Open Resource Sharing   
            {                                                   // Opens up the Api to not just limit the callers to a specific domain or individual URL
                options.AddPolicy("AllowOrigin", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });
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

            app.UseCors("AllowedOrigin");    //Added this in order to open up CORS

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
