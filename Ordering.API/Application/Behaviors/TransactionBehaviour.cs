﻿using MediatR;
using Microsoft.Extensions.Logging;
using Ordering.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Ordering.API.Application.Behaviors
{
    public class TransactionBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {

        private readonly ILogger<TransactionBehaviour<TRequest, TResponse>> _logger;
        private readonly OrderingContext OrderingContext;


        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            throw new NotImplementedException();
        }
    }
}
