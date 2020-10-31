using MediatR;
using Ordering.Domain.AggregatesModel.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ordering.Domain.Events
{
    public class OrderStatusChangedToAwaitingValidationDomainEvent : INotification
    {

        public int OrderId { get; }

        public IEnumerable<OrderItem> OrderItems { get; }

        public OrderStatusChangedToAwaitingValidationDomainEvent(int orderid, IEnumerable<OrderItem> orderItems)
        {
            OrderId = orderid;
            OrderItems = orderItems;
        }
    }
}
