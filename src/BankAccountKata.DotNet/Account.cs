
using System;
using System.Collections.Generic;
using System.Linq;
using static Org.Xpdojo.Bank.Money;
using static Org.Xpdojo.Bank.Transaction;

namespace Org.Xpdojo.Bank
{
    public class Account
    {
        private StatementWriter statementWriter;
        private readonly List<Transaction> transactions = new List<Transaction>();

        public static Account AnEmptyAccount()
        {
            return new Account(AnAmountOf(0.0));
        }

        public static Account AnAccountWith(Money amount)
        {
            return new Account(amount);
        }

        private Account(Money anAmount)
        {
            transactions.Add(AnOpeningBalanceOf(anAmount, DateTime.Now));
        }

        public Money Balance()
        {
            return transactions.Select(transaction => transaction.BalanceImpact()).Aggregate((balance1, balance2) => balance1.Add(balance2));

        }

        public void Deposit(Money anAmount)
        {
            transactions.Add(ADepositOf(anAmount, DateTime.Now));
        }

        public void Withdraw(Money anAmount)
        {
            if (Balance().IsLessThan(anAmount))
            {
                throw new System.InvalidOperationException("You cannot withdraw more than the balance");

            }
            transactions.Add(AWithdrawalOf(anAmount, DateTime.Now));
        }

        public void TransferTo(Account destinationAccount,Money money)
        {
            destinationAccount.Deposit(money);
            this.Withdraw(money);
        }

        public void PrintBalanceStatement()
        {
            statementWriter.PrintBalanceOf(Balance());
        }

        public void PrintFullStatement()
        {
            statementWriter.PrintFullStatementWith(transactions);
        }

        public void SetStatementWriter(StatementWriter statementWriter)
        {
            this.statementWriter = statementWriter;
        }

    }
}
