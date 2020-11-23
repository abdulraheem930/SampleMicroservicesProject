using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FinanceHouse.CCS.BusinessLayer.Concrete;
using FinanceHouse.CCS.BusinessLayer.Interface;
using FinanceHouse.CCS.Model;
using FinanceHouse.CCS.ServiceLayer.Concrete;
using FinanceHouse.CCS.ServiceLayer.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Xavor.SD.Repository.Contracts.UnitOfWork;
using Xavor.SD.Repository.UnitOfWork;

namespace FinanceHouse.CCS.CustomerWebAPI
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
            //in memory cache
            services.AddMemoryCache();
            // adding automapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            //Database instace injecting
            services.AddDbContext<CustomerContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Default")));

            //Unit of Work
            services.AddScoped<IUnitOfWork, UnitOfWork<CustomerContext>>();

            services.AddCors();

            //Injecting Business layer
            services.AddScoped<ICustomerBusinessLayer, CustomerBusinessLayer>();
            services.AddScoped<ICustomerHistoryBusinessLayer, CustomerHistoryBusinessLayer>();
            services.AddScoped<IAuditBusinessLayer, AuditBusinessLayer>();

            //injecting Service layer

            services.AddScoped<ICustomerServiceLayer, CustomerServiceLayer>();
            services.AddControllers();
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

           

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
