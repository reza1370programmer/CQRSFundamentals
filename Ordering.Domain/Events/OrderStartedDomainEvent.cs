

using MediatR;
using Ordering.Domain.AggregatesModel.OrderAggregate;

namespace Ordering.Domain.Events
{
    /// <summary>
    /// we want to add new buyer and send email to him after creating new order
    /// </summary>
    public class OrderStartedDomainEvent : INotification
    {
        public string UserId { get; }
        public string UserName { get; }
        public Order Order { get; }
        public OrderStartedDomainEvent(Order order, string userId, string
        userName)
        {
            Order = order;
            UserId = userId;
            UserName = userName;
        }
    }
}
