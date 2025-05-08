using Domain.Types;

namespace Domain.Test.Types;

public class MoneyTest
{
    #region Creation
    [Fact]
    public void CreateWithInt()
    {
        var amount = Money.Create(50);
        Assert.Equal(50.0m, amount.Value);
    }
    
    [Fact]
    public void CreateWithString()
    {
        var amount = Money.Create("50.45");
        Assert.Equal(50.45M, amount.Value);
    }

    [Fact]
    public void CreateWithDecimal()
    {
        var amount = Money.Create(50.45m);
        Assert.Equal(50.45m, amount.Value);
    }

    [Fact]
    public void CreateWithLong()
    {
        var amount = Money.Create(50450);
        Assert.Equal(50450.00M, amount.Value);
    }
    #endregion

    //Invalid values
    [Fact]
    public void NegativeAmount()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => Money.Create(-10));
    }
    [Fact]
    public void EmptyAmount()
    {
        Assert.Throws<ArgumentNullException>(() => Money.Create(string.Empty));
    }
    
    //Equality
    [Fact]
    public void Equality()
    {
        var amount1 = Money.Create(50);
        var amount2 = Money.Create("50");
        Assert.Equal(amount1.Value, amount2.Value);
    }
    
    //Ops
    [Fact]
    public void Addition()
    {
        var amount1 = Money.Create(50);
        var amount2 = Money.Create("50.1");
        Assert.Equal(100.1M, amount1 + amount2);
    }

    [Fact]
    public void Subtraction()
    {
        var amount1 = Money.Create(50);
        var amount2 = Money.Create("49.50");
        Assert.Equal(0.5M, amount1 - amount2);
    }
}