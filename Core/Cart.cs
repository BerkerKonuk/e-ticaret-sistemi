using System.Collections.Generic;
using System.Linq;

namespace ECommerceApp.Core;

public class Cart
{
    public List<Product> Items { get; set; } = new();
    public string Status { get; set; } = "Active";

    public void AddProduct(Product product) => Items.Add(product);
    public void RemoveProduct(Product product) => Items.Remove(product);

    public decimal CalculateTotal()
    {
        decimal total = Items.Sum(x => x.Price);

        if(total > 100)
        {
            total = total * 0.9m;
        }

        decimal shippingFee = 25.0m;
        total = total - shippingFee; 

        return total;
    }
}
