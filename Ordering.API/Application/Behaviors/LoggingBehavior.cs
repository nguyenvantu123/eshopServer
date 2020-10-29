using EventBus.Extension;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Ordering.API.Application.Behaviors
{
    public class LoggingBehavior<TResponse, TRequest> : IPipelineBehavior<TResponse, TRequest>
    {

        private readonly ILogger<LoggingBehavior<TResponse, TRequest>> _logger;

        public LoggingBehavior(ILogger<LoggingBehavior<TResponse, TRequest>> logger) => _logger = logger;


        public async Task<TRequest> Handle(TResponse request, CancellationToken cancellationToken, RequestHandlerDelegate<TRequest> next)
        {
            _logger.LogInformation("----- Handling command {CommandName} ({@Command})", request.GetGenericTypeName(), request);

            var response = await next();

            _logger.LogInformation("----- Command {CommandName} handled - response: {@Response}", request.GetGenericTypeName(), response);

            return response;
        }
    }
}
