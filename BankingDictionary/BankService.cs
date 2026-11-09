using System;

namespace BankingDictionary;

public class BankService
{
    public static Dictionary<int, decimal> GetBalances(IEnumerable<Transaction> transactions)
    {
        var balances = new Dictionary<int, decimal>();
        foreach (var transaction in transactions)
        {
            balances.TryGetValue(transaction.AccountId, out var currentBalance);
            balances[transaction.AccountId] = currentBalance + transaction.Amount;
        }

        return balances;
    }
}
