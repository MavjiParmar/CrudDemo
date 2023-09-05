using Contrado.Service.Employee;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Contrado.Service
{
    public static class ServiceCollectionExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {

            services.AddScoped<IEmployeeService, EmployeeService>();

        }
    }
}
