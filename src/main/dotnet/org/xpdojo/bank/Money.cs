namespace org.xpdojo.bank
{

    /**
    * Immutable class to represent Money as a concept.
    * This class should have no accessor methods.
    */
    public class Money
    {
        public int Amount { get; }

        public Money(int amount)
        {
            Amount = amount;
        }

        public Money Add(Money other)
        {
            return new Money(this.Amount + other.Amount);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Money other = (Money)obj;
            return Amount == other.Amount;
        }

        public override int GetHashCode()
        {
            return Amount.GetHashCode();
        }
    }

}