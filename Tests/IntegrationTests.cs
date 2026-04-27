using System;
using NUnit.Framework;
using ECommerceApp.Core;

namespace ECommerceApp.Tests.IntegrationTests;

[TestFixture]
public class IntegrationTests
{
    [Test]
    [Category("Integration Test")]
    public void AddProductToCart_And_PlaceOrderSuccessfully()
    {
        var product = new Product { Id = 10, Name = "Monitor", Price = 50m, Stock = 2 };
        var cart = new Cart();
        var service = new OrderService();

        cart.AddProduct(product);
        var orderInfo = service.PlaceOrder(cart, 100m);

        Assert.That(orderInfo.IsSuccessful, Is.True);
        Assert.That(cart.Status, Is.EqualTo("Completed"));
        Assert.That(product.Stock, Is.EqualTo(1));
    }

    [Test]
    [Category("Integration Test")]
    public void MultipleProducts_CalculationAndPayment_WithShippingBug()
    {
        var p1 = new Product { Id = 1, Name = "Item A", Price = 60m, Stock = 5 };
        var p2 = new Product { Id = 2, Name = "Item B", Price = 60m, Stock = 5 }; 
        var cart = new Cart();
        cart.AddProduct(p1);
        cart.AddProduct(p2);
        
        var service = new OrderService();
        
        decimal expectedTotal = 133.0m;
        
        decimal actualTotal = cart.CalculateTotal();
        
        Assert.That(actualTotal, Is.EqualTo(expectedTotal), "Total should be 133 (108 + 25 shipping)");
        
        var result = service.PlaceOrder(cart, actualTotal);
        Assert.That(result.IsSuccessful, Is.True);
    }
}
