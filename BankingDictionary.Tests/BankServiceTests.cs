using System;

namespace BankingDictionary.Tests;

public class BankServiceTests
{
    [Fact]
    public void GetBalances_WithSampleData_ReturnsCorrectBalances()
    {
        // Arrange
        var transactions = new List<Transaction>
        {
            new(1, 100.00m),
            new(2, 50.00m),
            new(1, -30.00m),
            new(3, 200.00m),
            new(2, -70.00m),
        };

        var expectedBalance = new Dictionary<int, decimal>
        {
            { 1, 70.00m},
            { 2, -20.00m},
            { 3, 200.00m},
        };

        // Act
        var currentBalances = BankService.GetBalances(transactions);

        // Assert
        Assert.Equal(expectedBalance, currentBalances);
    }

    [Fact]
    public void GetBalances_WithEmptyList_ReturnsEmptyDictionary()
    {
        // Arrange
        var transactions = new List<Transaction>();

        // Act
        var currentBalances = BankService.GetBalances(transactions);

        // Assert
        Assert.Empty(currentBalances);
    }

    [Fact]
    public void GetBalances_WithEqualAmountOfDepositAndWithdrawal_ReturnsZeroBalance()
    {
        // Arrange
        var transactions = new List<Transaction>
        {
            new(1, 100.00m),
            new(1, -100.00m),
        };

        var expected = new Dictionary<int, decimal>
        {
            { 1, 0.00m},
        };

        // Act
        var actual = BankService.GetBalances(transactions);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void GetBalances_SmallDecimalAmounts_ReturnsExactSum()
    {
        // Arrange
        var transactions = new List<Transaction>
        {
            new(1, 0.10m),
            new(1, 0.20m),
        };

        // Act
        var actual = BankService.GetBalances(transactions);

        // Assert
        Assert.Equal(0.30m, actual[1]);
    }
}