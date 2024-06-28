using System;
using static Org.Xpdojo.Bank.Direction;

namespace Org.Xpdojo.Bank
{
    public class Transaction
    {
        private readonly Money amount;
        private readonly Direction direction;
        private readonly DateTime date;

        private Transaction(Money amount, Direction direction, DateTime date)
        {
            this.amount = amount;
            this.direction = direction;
            this.date = date;
        }

        public static Transaction AnOpeningBalanceOf(Money amount, DateTime date)
        {
            return new Transaction(amount, Credit, date);
        }

        public static Transaction ADepositOf(Money amount, DateTime date)
        {
            return new Transaction(amount, Credit, date);
        }

        public static Transaction AWithdrawalOf(Money amount, DateTime date)
        {
            return new Transaction(amount, Debit, date);
        }

        public Money GetAmount()
        {
            return amount;
        }

        public Direction GetDirection()
        {
            return direction;
        }

        public DateTime GetDate()
        {
            return date;
        }

        public Money BalanceImpact()
        {
            if (direction == Debit)
                return amount.Negative();
            else
                return amount;
        }
    }

    public enum Direction
    {
        Debit,
        Credit
    }
}
