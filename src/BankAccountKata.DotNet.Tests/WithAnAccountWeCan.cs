using FluentAssertions;

namespace BankAccountKata.Dotnet.Tests;

public class WithAnAccountWeCan 
{

    [Fact(Skip="ignore")]
    public void DepositAnAmountToIncreaseTheBalance() 
    {
        var result = "an implemented test";

        result.Should().Be("no implementation you need to write the test first");
   }
}
