using Book_Show_BLL.Services;
using Book_Show_DAL;
using Book_Show_DAL.Repost;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace MovieAppCoreApi
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
            string connectionStr = Configuration.GetConnectionString("sqlConnection");
            services.AddDbContext<Book_show_db>(options => options.UseSqlServer(connectionStr));
            services.AddTransient<MovieServices, MovieServices>();
            services.AddTransient<IMovieRepository,MovieRepost>();
            services.AddTransient<TheaterServices, TheaterServices>();
            services.AddTransient<ITheaterRepost, TheaterRepost>();
            services.AddTransient<ShowTimingServices, ShowTimingServices>();
            services.AddTransient<IShowTimingsRepost, ShowTimingsRepost>();
            services.AddTransient<UserServices, UserServices>();
            services.AddTransient<IUserRepost, UserRepost>();
            services.AddTransient<LocationServices, LocationServices>();
            services.AddTransient<ILocationRepost, LocationRepost>();
            services.AddTransient<BookShowServices, BookShowServices>();
            services.AddTransient<IBookShowRepost, BookShowRepost>();
            services.AddControllers();
            services.AddSwaggerGen();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Movie API",
                    Description = "Movie Management System API",
                });
            });
           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();//default middleware function strt with .use
            }

            app.UseRouting();//it will check the url
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "Movie API"));

            app.UseAuthorization();//it will check 

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
