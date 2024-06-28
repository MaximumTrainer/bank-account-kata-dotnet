using FluentAssertions;
using Xunit;
using static Org.Xpdojo.Bank.Account;
using static Org.Xpdojo.Bank.Money;

namespace Org.Xpdojo.Bank
{
    public class WithMoneyWeCan
    {
        [Fact]
        public void AddTwoAmountsOfMoneyTogether()
        {
            var result = Money.AnAmountOf(7.0d).Add(Money.AnAmountOf(4.0d));
            result.Should().Be(Money.AnAmountOf(11.0d));
        }

        [Fact]
        public void SubtractAnAmountOfMoneyFromAnother()
        {
            var result = Money.AnAmountOf(23.0d).Less(Money.AnAmountOf(12.0d));
            result.Should().Be(Money.AnAmountOf(11.0d));
        }

        [Fact]
        public void CompareIfOneAmountIsLessThanAnotherAmount()
        {
            Money.AnAmountOf(12.0d).IsLessThan(Money.AnAmountOf(13.0d)).Should().BeTrue();
            Money.AnAmountOf(12.0d).IsLessThan(Money.AnAmountOf(12.0d)).Should().BeFalse();
            Money.AnAmountOf(12.0d).IsLessThan(Money.AnAmountOf(11.0d)).Should().BeFalse();
        }

        [Fact]
        public void CompareIfTwoAmountsAreTheSame()
        {
            Money.AnAmountOf(12.0d).Equals(Money.AnAmountOf(13.0d)).Should().BeFalse();
            Money.AnAmountOf(12.0d).Equals(Money.AnAmountOf(12.0d)).Should().BeTrue();
            Money.AnAmountOf(12.0d).Equals(Money.AnAmountOf(11.0d)).Should().BeFalse();
        }
    }
}
