using Xunit;
using Moq;
using FluentAssertions;
using static Org.Xpdojo.Bank.Account;
using static Org.Xpdojo.Bank.Money;

namespace Org.Xpdojo.Bank
{
    public class WithAnAccountWeCan
    {

        private Mock<StatementWriter> statementWriterMock;


        public WithAnAccountWeCan()
        {
            statementWriterMock = new Mock<StatementWriter>();
            var mockStreamWriter = new Mock<StreamWriter>(new MemoryStream());
            statementWriterMock.Object.SetFileWriter(mockStreamWriter.Object);

        }

        [Fact]
        public void CompareTwoAccountsHaveTheSameBalance()
        {
            var account = AnAccountWith(AnAmountOf(10.0));
            account.Balance().Should().Be(AnAccountWith(AnAmountOf(10.0)).Balance());

        }

        [Fact]
        public void DepositAnAmountToIncreaseTheBalance()
        {
            var account = AnEmptyAccount();
            account.Deposit(AnAmountOf(10.0));
            account.Balance().Should().BeEquivalentTo(AnAccountWith(AnAmountOf(10.0)).Balance());
        }

        [Fact]
        public void WithdrawAnAmountToDecreaseTheBalance()
        {
            var account = AnAccountWith(AnAmountOf(20.0));
            account.Withdraw(AnAmountOf(10.0));
            account.Balance().Should().BeEquivalentTo(AnAccountWith(AnAmountOf(10.0)).Balance());
        }

        [Fact]
        public void ThrowsExceptionIfYouTryToWithdrawMoreThanTheBalance()
        {
            var account = AnAccountWith(AnAmountOf(20.0));
            Assert.Throws<InvalidOperationException>(() => account.Withdraw(AnAmountOf(30.0)));
        }

        [Fact]
        public void TransferMoneyFromOneAccountToAnother()
        {
            var destinationAccount = AnEmptyAccount();
            var sourceAccount = AnAccountWith(AnAmountOf(50.0));

            sourceAccount.TransferTo(destinationAccount, AnAmountOf(20.0));

            sourceAccount.Balance().Should().BeEquivalentTo(AnAccountWith(AnAmountOf(30.0)).Balance());
            destinationAccount.Balance().Should().BeEquivalentTo(AnAccountWith(AnAmountOf(20.0)).Balance());
        }

        [Fact]
        public void ThrowsExceptionIfYouTryToTransferMoreThanTheBalance()
        {
            var sourceAccount = AnAccountWith(AnAmountOf(20.0));
            Assert.Throws<InvalidOperationException>(() => sourceAccount.TransferTo(AnEmptyAccount(), AnAmountOf(30.0)));
        }

        [Fact]
        public void HasTheRightBalanceAfterANumberOfTransactions()
        {
            var account = AnEmptyAccount();
            account.Deposit(AnAmountOf(10.0));
            account.Deposit(AnAmountOf(80.0));
            account.Deposit(AnAmountOf(5.0));
            account.Withdraw(AnAmountOf(15.0));
            account.Withdraw(AnAmountOf(10.0));
            account.Balance().Should().BeEquivalentTo(AnAccountWith(AnAmountOf(70.0)).Balance());
        }

        [Fact]
        public void PrintOutAnAccountBalance()
        {
            var account = AnAccountWith(AnAmountOf(30.0));
            account.SetStatementWriter(statementWriterMock.Object);
            account.PrintBalanceStatement();
            statementWriterMock.Verify(sw => sw.PrintBalanceOf(It.IsAny<Money>()));
        }

        [Fact]
        public void PrintOutAFullStatement()
        {
            var account = AnEmptyAccount();
            account.SetStatementWriter(statementWriterMock.Object);
            account.PrintFullStatement();
          //  statementWriterMock.Verify(writer => writer.PrintFullStatementWith(It.IsAny<List<Transaction>>()));
            statementWriterMock.Verify(writer => writer.PrintFullStatementWith(It.IsAny<List<Transaction>>()), Times.Once);

        }
    }
}
