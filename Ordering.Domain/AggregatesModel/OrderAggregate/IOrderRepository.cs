

using Ordering.Domain.SeedWork;

namespace Ordering.Domain.AggregatesModel.OrderAggregate
{
    public interface IOrderRepository
    {
        IUnitOfWork UnitOfWork { get; }
        Order Add(Order order);
        void Update(Order order);
        Task<Order> GetAsync(int orderId);
    }
}
