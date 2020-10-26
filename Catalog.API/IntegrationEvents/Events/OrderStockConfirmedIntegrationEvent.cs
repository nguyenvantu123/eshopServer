﻿
using EventBus.Event;

namespace Microsoft.eShopOnContainers.Services.Catalog.API.IntegrationEvents.Events
{

    public class OrderStockConfirmedIntegrationEvent : IntegrationEvent
    {
        public int OrderId { get; }

        public OrderStockConfirmedIntegrationEvent(int orderId) => OrderId = orderId;


    }
}