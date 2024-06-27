
using System;
using System.Collections.Generic;

namespace org.xpdojo.bank
{
    public class Account
    {
        private int _balance = 0;

        public void Deposit(int amount)
        {
            _balance += amount;
        }

        public void Withdraw(int amount)
        {
            _balance -= amount;
        }

        public int GetBalance()
        {
            return _balance;
        }
    }
}