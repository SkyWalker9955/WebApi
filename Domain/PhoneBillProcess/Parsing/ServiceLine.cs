using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using Domain.Types;

namespace Domain.PhoneBillProcess.Parsing;

public record ServiceLine
{
    public string PhoneNumberPrefix { get; }
    public string PhoneNumberSuffix { get; }
    public Money PlanAmount { get; }
    public Money EquipmentAmount { get; }
    public Money ServiceAmount { get; }
    public Money OneTimeChangeAmount { get; }
    public Money TotalAmount => PlanAmount + EquipmentAmount + ServiceAmount + OneTimeChangeAmount;

    public ServiceLine(string phoneNumberPrefix, string phoneNumberSuffix, Money planAmount, Money equipmentAmount, Money serviceAmount, Money oneTimeChangeAmount)
    {
        if (string.IsNullOrWhiteSpace(phoneNumberPrefix)) throw new ArgumentException("Phone number prefix cannot be empty", nameof(phoneNumberPrefix));
        if (string.IsNullOrWhiteSpace(phoneNumberSuffix)) throw new ArgumentException("Phone number suffix cannot be empty", nameof(phoneNumberSuffix));

        PhoneNumberPrefix = phoneNumberPrefix;
        PhoneNumberSuffix = phoneNumberSuffix;
        PlanAmount = planAmount;
        EquipmentAmount = equipmentAmount;
        ServiceAmount = serviceAmount;
        OneTimeChangeAmount = oneTimeChangeAmount;
    }
}