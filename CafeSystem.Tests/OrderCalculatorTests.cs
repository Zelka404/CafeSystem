namespace CafeSystem.Tests;
using NUnit.Framework;
using CafeSystem;

[TestFixture]
public class OrderCalculatorTests
{
    [Test]
    public void CalculateItemTotal_ValidPriceAndQuantity_ReturnsTotal()
    {
        var calculator = new OrderCalculator();
        decimal price = 150.0m;
        int quantity = 2;

        decimal result = calculator.CalculateItemTotal(price, quantity);

        Assert.That(result, Is.EqualTo(300.0m));
    }

    [Test]
    public void CalculateOrderTotal_MultipleItems_ReturnsSum()
    {
        var calculator = new OrderCalculator();
        decimal[] itemTotals = { 300.0m, 150.0m, 200.0m };

        decimal result = calculator.CalculateOrderTotal(itemTotals);

        Assert.That(result, Is.EqualTo(650.0m));
    }

    [Test]
    public void ApplyDiscount_TenPercentCard_ReturnsDiscountedTotal()
    {
        var calculator = new OrderCalculator();
        decimal total = 1000.0m;
        decimal discountPercent = 10.0m;

        decimal result = calculator.ApplyDiscount(total, discountPercent);

        Assert.That(result, Is.EqualTo(900.0m));
    }

    [Test]
    public void CheckAvailability_DishNotAvailable_ThrowsInvalidOperationException()
    {
        var calculator = new OrderCalculator();
        bool isAvailable = false;

        Assert.Throws<InvalidOperationException>(() => calculator.CheckAvailability(isAvailable));
    }

    [Test]
    public void ApplyDiscount_InvalidPercent_ThrowsArgumentException()
    {
        var calculator = new OrderCalculator();

        Assert.Throws<ArgumentException>(() => calculator.ApplyDiscount(1000.0m, 150.0m));
        Assert.Throws<ArgumentException>(() => calculator.ApplyDiscount(1000.0m, -10.0m));
    }
}