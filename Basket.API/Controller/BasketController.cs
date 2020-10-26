using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Basket.API.Controller
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class BasketController : ControllerBase
    {
        //private readonly IBasketRepository _repository;
        //private readonly IIdentityService _identityService;
        //private readonly IEventBus _eventBus;
        //private readonly ILogger<BasketController> _logger;
    }
}