using FluentValidation;
using Ordering.API.Application.DTOs;
using Ordering.API.Application.Models;


namespace Ordering.API.Application.Validations
{
    public class CreateOrderCommandValidator : AbstractValidator<OrderDTO>
    {
        public CreateOrderCommandValidator()
        {
            RuleFor(command => command.City).NotEmpty();
            RuleFor(command => command.Street).NotEmpty();
            RuleFor(command => command.Country).NotEmpty();
            RuleFor(command => command.ZipCode).NotEmpty();
            RuleFor(command => command.Buyer).Empty();
            RuleFor(command => command.BuyerId).Empty();
            RuleFor(command => command.Items).Must(ContainOrderItems).WithMessage("No order items found");

        }
        private bool ContainOrderItems(IEnumerable<BasketItem> orderItems)
        {
            return orderItems.Any();
        }
    }
}
