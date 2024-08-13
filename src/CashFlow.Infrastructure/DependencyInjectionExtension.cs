using CashFlow.Domain.Repositories;
using CashFlow.Domain.Repositories.Expenses;
using CashFlow.Infrastructure.DataAccess;
using CashFlow.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CashFlow.Infrastructure {
    public static class DependencyInjectionExtension {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration) {
            addDbContext(services, configuration);
            addRepositories(services);
        }

        private static void addRepositories(this IServiceCollection services) {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IExpensesReadOnlyRepository, ExpensesRepository>();
            services.AddScoped<IExpensesWriteOnlyRepository, ExpensesRepository>();
            services.AddScoped<IExpensesUpdateOnlyRepository, ExpensesRepository>();

        }

        private static void addDbContext(this IServiceCollection services, IConfiguration configuration) {

            var connectionString = configuration.GetConnectionString("Connection");
            ;

            var serverVersion = new MySqlServerVersion(new Version(8, 0, 35));          

            services.AddDbContext<CashFlowDbContext>(config => config.UseMySql(connectionString, serverVersion));
        }


    }
}
