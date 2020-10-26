using Basket.API.Model;
using Grpc.Core;
using GrpcBasket;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Basket.API.Grpc
{
    public class BasketService : GrpcBasket.Basket.BasketBase
    {

        private readonly IBasketRepository _repository;
        private readonly ILogger<BasketService> _logger;

        public BasketService(IBasketRepository repository, ILogger<BasketService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [AllowAnonymous]
        public override async Task<CustomerBasketResponse> GetBasketById(BasketRequest request, ServerCallContext context)
        {
            _logger.LogInformation("Begin grpc call from method {Method} for basket id {Id}", context.Method, request.Id);

            var data = await _repository.GetBasketAsync(request.Id);

            if (data != null)
            {
                context.Status = new Status(StatusCode.OK, $"Basket with id {request.Id} do exist");

                return MapToCustomerBasketResponse(data);
            }
            else
            {
                context.Status = new Status(StatusCode.NotFound, $"Basket with id {request.Id} do not exist");
            }

            return new CustomerBasketResponse();
        }

        private CustomerBasketResponse MapToCustomerBasketResponse(CustomerBasket customerBasket)
        {
            var response = new CustomerBasketResponse
            {
                Buyerid = customerBasket.BuyerId
            };

            customerBasket.Items.ForEach(item => response.Items.Add(new BasketItemResponse
            {
                Id = item.Id,
                Oldunitprice = (double)item.OldUnitPrice,
                Pictureurl = item.PictureUrl,
                Productid = item.ProductId,
                Productname = item.ProductName,
                Quantity = item.Quantity,
                Unitprice = (double)item.UnitPrice
            }));

            return response;
        }

    }
}
