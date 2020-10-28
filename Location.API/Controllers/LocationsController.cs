﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Locations.API.Infrastructure.Services;
using Locations.API.Model;
using Locations.API.ViewModel;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Locations.API.Controllers
{
    [Route("api/v1/[controller]")]
    [Authorize]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly ILocationsService _locationsService;
        private readonly IIdentityService _identityService;

        public LocationsController(ILocationsService locationsService, IIdentityService identityService)
        {
            _locationsService = locationsService ?? throw new ArgumentNullException(nameof(locationsService));
            _identityService = identityService ?? throw new ArgumentNullException(nameof(identityService));
        }

        //GET api/v1/[controller]/user/1
        [Route("user/{userId:guid}")]
        [HttpGet]
        [ProducesResponseType(typeof(UserLocation), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UserLocation>> GetUserLocationAsync(Guid userId)
        {
            return await _locationsService.GetUserLocationAsync(userId.ToString());
        }

        //GET api/v1/[controller]/
        [Route("")]
        [HttpGet]
        [ProducesResponseType(typeof(List<Location>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<Location>>> GetAllLocationsAsync()
        {
            return await _locationsService.GetAllLocationAsync();
        }

        //GET api/v1/[controller]/1
        [Route("{locationId}")]
        [HttpGet]
        [ProducesResponseType(typeof(Location), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Location>> GetLocationAsync(int locationId)
        {
            return await _locationsService.GetLocationAsync(locationId);
        }
         
        //POST api/v1/[controller]/
        [Route("")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> CreateOrUpdateUserLocationAsync([FromBody]LocationRequest newLocReq)
        {
            var userId = _identityService.GetUserIdentity();
            var result = await _locationsService.AddOrUpdateUserLocationAsync(userId, newLocReq);

            if (!result)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
