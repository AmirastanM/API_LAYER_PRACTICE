﻿using Microsoft.Extensions.DependencyInjection;
using Repository.Repositories;
using Repository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepositoryLayer(this IServiceCollection services)
        {

            services.AddScoped(typeof(IBaseRepository<>), typeof(IBaseRepository<>));
            //services.AddScoped<ICountryRepository, CountryRepository>();
            

          
            return services;
        }
    }
}
