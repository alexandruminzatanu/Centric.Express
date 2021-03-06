﻿using CentricExpress.Business.Domain;
using CentricExpress.Business.Repositories;
using CentricExpress.DataAccess.Repositories;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CentricExpress.DataAccess.Configurations.IoC
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDataAccess(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IRepository<Customer>, Repository<Customer>>();
            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IRepository<Picture>, Repository<Picture>>();

            services.AddScoped<ICustomerOrdersRepository, CustomerOrdersRepository>();
        }
    }
}