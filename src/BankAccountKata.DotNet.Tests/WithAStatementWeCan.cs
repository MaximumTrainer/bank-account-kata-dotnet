using System;
using System.Collections.Generic;
using Xunit;
using Moq;
using FluentAssertions;
using static Org.Xpdojo.Bank.Money;
using static Org.Xpdojo.Bank.Transaction;

namespace Org.Xpdojo.Bank
{
    public class WithAStatementWeCan
    {


        [Fact]
        public void PrintAStatementBalance()
        {
            // Arrange
            var mockStreamWriter = new Mock<StreamWriter>(new MemoryStream());
            var statement = new StatementWriter();
            statement.SetFileWriter(mockStreamWriter.Object);

            // Act
            statement.PrintBalanceOf(AnAmountOf(10.0));

            // Assert
            mockStreamWriter.Verify(ps => ps.WriteLine(It.IsAny<string>()), Times.Exactly(5));
        }

        [Fact]
        public void PrintAFullStatement()
        {
            // Arrange
            var statement = new StatementWriter();
            var mockStreamWriter = new Mock<StreamWriter>(new MemoryStream());

            statement.SetFileWriter(mockStreamWriter.Object);
            var transactions = new List<Transaction>
            {
                AnOpeningBalanceOf(AnAmountOf(10.0), DateTime.Now),
                ADepositOf(AnAmountOf(100.0), DateTime.Now),
                AWithdrawalOf(AnAmountOf(10.0), DateTime.Now),
                AWithdrawalOf(AnAmountOf(10.0), DateTime.Now)
            };

            // Act
            statement.PrintFullStatementWith(transactions);

            // Assert
            mockStreamWriter.Verify(ps => ps.WriteLine(It.IsAny<string>()), Times.Exactly(8));
        }
    }

}
