using System;
using NUnit.Framework;
using ECommerceApp.Core;

namespace ECommerceApp.Tests.UnitTests;

[TestFixture]
public class UnitTests
{
    private Product _testProduct;
    private Cart _testCart;
    private OrderService _orderService;

    [SetUp]
    public void Setup()
    {
        _testProduct = new Product { Id = 1, Name = "Laptop", Price = 1000m, Stock = 5 };
        _testCart = new Cart();
        _orderService = new OrderService();
    }

    [Test]
    [Category("White Box")]
    public void Cart_CalculateTotal_ShippingFee_Validation()
    {
        _testCart.AddProduct(new Product { Id = 2, Name = "Mouse", Price = 200m, Stock = 10 });
        
        decimal total = _testCart.CalculateTotal();
        
        Assert.That(total, Is.EqualTo(205.0m));
    }

    [Test]
    [Category("White Box")]
    public void OrderService_PlaceOrder_Status_Check()
    {
        _testCart.AddProduct(_testProduct);

        _orderService.PlaceOrder(_testCart, 2000m);

        Assert.That(_testCart.Status, Is.EqualTo("Completed"));
    }

    [Test]
    [Category("White Box")]
    public void Cart_RemoveProduct_VerifyCount()
    {
         _testCart.AddProduct(_testProduct);
         
         _testCart.RemoveProduct(_testProduct);

         Assert.That(_testCart.Items.Count, Is.EqualTo(0));
    }

    [Test]
    [Category("Black Box")]
    public void Cart_AddProduct_VerifyCount()
    {
        _testCart.AddProduct(_testProduct);

        Assert.That(_testCart.Items.Count, Is.EqualTo(1));
    }

    [Test]
    [Category("Black Box")]
    public void Product_DecreaseStock_VerifyValue()
    {
        _testProduct.DecreaseStock(3);

        Assert.That(_testProduct.Stock, Is.EqualTo(2));
    }

    [Test]
    [Category("Black Box")]
    public void Product_Stock_Boundary_Check()
    {
        var product = new Product { Id = 3, Name = "Keyboard", Price = 100m, Stock = 1 };

        Assert.Throws<InvalidOperationException>(() => product.DecreaseStock(1));
    }

    [Test]
    [Category("Gray Box")]
    public void OrderService_ValidOrder_Status_Verify()
    {
         _testCart.AddProduct(new Product { Id = 4, Name = "Cable", Price = 50m, Stock = 10 });

         var order = _orderService.PlaceOrder(_testCart, 100m);

         Assert.That(order.IsSuccessful, Is.True);
         Assert.That(_testCart.Status, Is.EqualTo("Completed"));
    }

    [Test]
    [Category("Gray Box")]
    public void OrderService_Payment_Boundary_Check()
    {
        _testCart.AddProduct(new Product { Id = 5, Name = "Desk", Price = 500m, Stock = 5 });
        decimal exactTotal = _testCart.CalculateTotal();

        Assert.Throws<ArgumentException>(() => _orderService.PlaceOrder(_testCart, exactTotal));
    }
}
