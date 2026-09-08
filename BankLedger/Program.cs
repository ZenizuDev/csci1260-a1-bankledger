
namespace BankLedger;

class Program
{
    public static void Main()
    {
        Account account = new Account("Ada Lovelace", 500);
        Ledger mainLedger = new(account);
        Console.WriteLine($"""
        Opening account: {account.Owner}
        
        Recording five requests...
        """);
        string[] kindArray = new string[5] { "Deposit", "Withdrawal", "Withdrawal", "Deposit", "Deposit" };
        double[] amountArray = new double[] { 250.00, 125.50, 10000.00, -40.00, 75.25 };
        for (int i = 0; i < amountArray.Length; i++)
        {
            bool status = mainLedger.Record(kindArray[i], amountArray[i]);
            if (!status)
            {
                Console.WriteLine($"Rejected: {kindArray[i]} of ${amountArray[i]:N2}");
            }
        }
        Console.WriteLine();
        Console.WriteLine($"Transactions accepted: {mainLedger.Count}");
        mainLedger.PrintStatement();
    }
}