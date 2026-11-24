using System;
using System.Collections.Generic;
using System.Text;

namespace CafeSystem;

public class OrderCalculator
{
    private const decimal PERCENT_BASE = 100.0m;

    public decimal CalculateItemTotal(decimal price, int quantity)
    {
        return price * quantity;
    }

    public decimal CalculateOrderTotal(decimal[] itemTotals)
    {
        return itemTotals.Sum();
    }

    public decimal ApplyDiscount(decimal total, decimal discountPercent)
    {
        if (discountPercent < 0 || discountPercent > 100)
        {
            throw new ArgumentException("Процент скидки должен быть от 0 до 100");
        }
        return total - (total * (discountPercent / PERCENT_BASE));
    }

    public void CheckAvailability(bool isAvailable)
    {
        if (!isAvailable)
        {
            throw new InvalidOperationException("Блюдо закончилось");
        }
    }

    public decimal CalculateTax(decimal total)
    {
        return total * 0.2m;
    }
}