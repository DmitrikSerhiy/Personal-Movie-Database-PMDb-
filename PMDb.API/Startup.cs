﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using PMDb.DependencyResolver.IoC;
using PMDb.Services.Mappers;

namespace PMDb.API
{
    
    public class Startup
    {
        private IoCBuilder IoCBuilder;
        private MovieMapper movieMapper;
        public Startup()
        {
            
        }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            IoCBuilder = new IoCBuilder(services);
            movieMapper = new MovieMapper();
            return IoCBuilder.GetContainer();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

        }
    }
}