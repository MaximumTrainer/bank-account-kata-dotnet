
using Xunit;
using FluentAssertions;


namespace org.xpdojo.bank
{

    //[Fact(DisplayName = "With Money we can ... ")]
    public class WithMoneyWeCan
    {
        [Fact]
        public void TestAddition()
        {
            var money1 = new Money(10);
            var money2 = new Money(20);
            var result = money1.Add(money2);

            result.Should().Be(new Money(30));
        }

        [Fact]
        public void TestEquality()
        {
            var money1 = new Money(10);
            var money2 = new Money(10);

            money1.Should().Be(money2);
        }
    }
}
