using System;

namespace ECommerceApp.Core;

public class OrderService
{
    public class Order
    {
        public bool IsSuccessful { get; set; }
        public string Message { get; set; } = string.Empty;
    }

    public Order PlaceOrder(Cart cart, decimal paymentAmount)
    {
        decimal total = cart.CalculateTotal();

        if (paymentAmount > total) 
        {
            throw new ArgumentException("Payment error!");
        }

        foreach (var item in cart.Items)
        {
            item.DecreaseStock(1);
        }

        cart.Status = "Completed";

        return new Order { IsSuccessful = true, Message = "Success" };
    }
}
