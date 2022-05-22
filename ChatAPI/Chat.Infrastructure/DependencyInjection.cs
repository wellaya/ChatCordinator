using Chat.Application.Common.Interfaces;
using Chat.Infrastructure.Services;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMassTransit(x =>
            {
                x.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(config =>
                {
                    config.Host(new Uri(configuration["RabbitMQHost:Url"]), h =>
                    {
                        h.Username(configuration["RabbitMQHost:Un"]);
                        h.Password(configuration["RabbitMQHost:Pw"]);
                    });
                }));
            });

            //services.AddMassTransitHostedService();
            
            services.AddScoped<IChatEventService, ChatEventService>();

            

            return services;
        }
    }
}
