using BankingDictionary;

var transactions = new List<Transaction>
{
    new(1, 100.00m),
    new(2, 50.00m),
    new(1, -30.00m),
    new(3, 200.00m),
    new(2, -70.00m),
};

var transactions2 = new List<Transaction>
{
    new(1, 100.00m),
    new(1, -100.00m),
};

var balances = BankService.GetBalances(transactions2);
foreach (var item in balances)
{
    Console.Write($" {item.Key} : {item.Value},");
}

public record Transaction(int AccountId, decimal Amount);
