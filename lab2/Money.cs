namespace lab2;

public class Money
{
    private uint rubles { get; set; }
    private byte kopeks { get; set; }

    public Money()
    {
        rubles = 0;
        kopeks = 0;
    }

    public Money(uint rubles, byte kopeks)
    {
        this.rubles = rubles;
        this.kopeks = kopeks;
    }

    public Money(Money other)
    {
        rubles = other.rubles;
        kopeks = other.kopeks;
    }

    public Money Subtraction(uint amount)
    {
        var total = (int)(rubles * 100 + kopeks);
    
        if (total < (int)amount)
            throw new InvalidOperationException("Недостаточно средств для вычитания");

        total -= (int)amount;
    
        rubles = (uint)(total / 100);
        kopeks = (byte)(total % 100);

        return this;
    }
    
    public override string ToString()
    {
        return $"{rubles} рублей {kopeks} копеек";
    }

    public static Money operator ++(Money money)
    {
        var total = (int)(money.rubles * 100 + money.kopeks);
        total += 1;
        
        return new Money((uint)(total / 100), (byte)(total % 100));
    }

    public static Money operator --(Money money)
    {
        var total = (int)(money.rubles * 100 + money.kopeks);
        
        if (total == 0)
            throw new InvalidOperationException("Недостаточно средств для вычитания");
        
        total -= 1;
        
        return new Money((uint)(total / 100), (byte)(total % 100));
    }

    public static explicit operator uint(Money money)
    {
        return money.rubles;
    }

    public static implicit operator bool(Money money)
    {
        return money.rubles * 100 + money.kopeks > 0;
    }

    public static Money operator -(Money m, byte kopeks)
    {
        var total = (int)(m.rubles * 100 + m.kopeks);
        
        if (total < kopeks)
            throw new InvalidOperationException("Недостаточно средств для вычитания");
        
        total -= kopeks;
        
        return new Money((uint)(total / 100), (byte)(total % 100));
    }

    public static Money operator -(Money m1, Money m2)
    {
        var total1 = (int)(m1.rubles * 100 + m1.kopeks);
        var total2 = (int)(m2.rubles * 100 + m2.kopeks);
        
        if (total1 < total2)
            throw new InvalidOperationException("Недостаточно средств для вычитания");
        
        total1 -= total2;
        
        return new Money((uint)(total1 / 100), (byte)(total1 % 100));
    }
}