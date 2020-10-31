using MediatR;
using Ordering.Domain.AggregatesModel.BuyerAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ordering.Domain.Events
{
    public class BuyerAndPaymentMethodVerifiedDomainEvent : INotification
    {
        public PaymentMethod PaymentMethod { get; private set; }

        public int OrderId { get; private set; }

        public Buyer Buyer { get; private set; }

        public BuyerAndPaymentMethodVerifiedDomainEvent(Buyer buyer, PaymentMethod paymentMethod, int orderId)
        {
            PaymentMethod = paymentMethod;
            OrderId = orderId;
            Buyer = buyer;
        }
    }
}
