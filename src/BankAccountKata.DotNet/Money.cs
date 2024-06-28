using System;

namespace Org.Xpdojo.Bank
{
    /// <summary>
    /// Immutable class to represent Money as a concept.
    /// This class should have no accessor methods.
    /// </summary>
    public class Money : IComparable<Money>
    {
        private readonly double amount;

        private Money(double anAmount) => this.amount = anAmount;

        public static Money AnAmountOf(double anAmount)
        {
            return new Money(anAmount);
        }

        public Money Add(Money anAmount) => AnAmountOf(this.amount + anAmount.amount);

        public Money Less(Money anAmount) => AnAmountOf(this.amount - anAmount.amount);

        public bool IsLessThan(Money anAmount) => amount < anAmount.amount;

        public Money Negative() => AnAmountOf(amount * -1);

        public int CompareTo(Money otherAmount) => amount.CompareTo(otherAmount.amount);

        public override bool Equals(object obj)
        {
            if (this == obj)
                return true;
            if (obj == null || GetType() != obj.GetType())
                return false;

            Money money = (Money)obj;
            return amount == money.amount;
        }

        public override int GetHashCode()
        {
            return amount.GetHashCode();
        }

        public override string ToString()
        {
            return $"Money{{amount={amount}}}";
        }
    }
}
