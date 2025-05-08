using System.Globalization;

namespace Domain.Types;

/// <summary>
/// Non-nullable value type representing a monetary amount.
/// </summary>
public readonly record struct Money : IComparable<Money>, IFormattable
{
    // ────────────────────────────────  State  ────────────────────────────────
    public decimal Value { get; }

    private Money(decimal value)
    {
        if (value < 0)
            throw new ArgumentOutOfRangeException(nameof(value), "Amount must be non‑negative");

        // keep at 2‑decimal precision, away‑from‑zero rounding (typical for cash)
        Value = decimal.Round(value, 2, MidpointRounding.AwayFromZero);
    }

    // ───────────────────────────────  Factory  ───────────────────────────────
    public static Money Create(int amount) => new(amount);
    public static Money Create(decimal amount) => new(amount);
    public static Money Create(string amount)
    {
        if (string.IsNullOrWhiteSpace(amount))
            throw new ArgumentNullException(nameof(amount), "Value cannot be empty");

        if (!decimal.TryParse(
                amount, 
                NumberStyles.Number, 
                CultureInfo.InvariantCulture,   // avoid 1 000,00 vs 1,000.00 issues
                out var parsed))
            throw new ArgumentOutOfRangeException(nameof(amount), "Value is not a valid number");

        return new Money(parsed);
    }

    // ──────────────────────────────  Operators  ──────────────────────────────
    public static Money operator +(Money a, Money b) => new(a.Value + b.Value);
    public static Money operator -(Money a, Money b) => new(a.Value - b.Value);

    // ──────────────────────── Implicit Conversions ────────────────────────
    public static implicit operator Money(decimal value) => new(value);
    public static implicit operator Money(int value) => new(value);

    // ───────────────────────  Equality & Ordering  ──────────────────────────
    public int CompareTo(Money other) => Value.CompareTo(other.Value);
    public override string ToString() => Value.ToString("0.##");
    public string ToString(string? fmt, IFormatProvider? provider) => Value.ToString(fmt, provider);
}