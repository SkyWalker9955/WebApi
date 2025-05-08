using Domain.PhoneBillProcess.Parsing;
using Domain.Types;

namespace Domain.Test.PhoneBillProcess;

public class ServiceLineTest
{
    //what is the behavior of a ServiceLine?
    //ServiceLine does not have a behavior, but it has invariants
    
    [Fact]
    public void TestIfBuildingWithEmptyStringsThrowsException()
    {
        const string phoneNumberPrefix = "";
        const string phoneNumberSuffix = "";
        var planAmount = Money.Create(50.5m);
        var equipmentAmount = Money.Create(50.5m);
        var serviceAmount = Money.Create(50.5m);
        var oneTimeChangeAmount = Money.Create(50.5m);

        Assert.Throws<ArgumentException>(() => 
            new ServiceLine(phoneNumberPrefix,
                phoneNumberSuffix,
                planAmount,
                equipmentAmount,
                serviceAmount,
                oneTimeChangeAmount));
    }

    [Fact]
    public void TestIfTotalIsCorrect()
    {
        const string phoneNumberPrefix = "123";
        const string phoneNumberSuffix = "123";
        var planAmount = Money.Create(5m);
        var equipmentAmount = Money.Create(5m);
        var serviceAmount = Money.Create(5.5m);
        var oneTimeChangeAmount = Money.Create(4.5m);
        var serviceLine = new ServiceLine(phoneNumberPrefix,
            phoneNumberSuffix,
            planAmount,
            equipmentAmount,
            serviceAmount,
            oneTimeChangeAmount);
        Assert.Equal(Money.Create(20m), serviceLine.TotalAmount);
    }
}
