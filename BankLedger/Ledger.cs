namespace BankLedger
{
    class Ledger
    {
        private Account account;
        private List<Transaction> history;
        private int nextId;
        public int Count
        {
            get
            {
                return history.Count;
            }
        }
        public Ledger(Account account)
        {
            this.account = account;
            history = new();
            nextId = 1;
        }
        public bool Record(string kind, double amount)
        {
            if (kind.Equals("Deposit"))
            {
                bool status = account.Deposit(amount);
                if (status)
                {
                    history.Add(new Transaction(nextId, kind, amount));
                    nextId++;
                    return true;
                }
            }
            else if (kind.Equals("Withdrawal"))
            {
                bool status = account.Withdraw(amount);
                if (status)
                {
                    history.Add(new Transaction(nextId, kind, amount));
                    nextId++;
                    return true;
                }
            }
            return false;
        }
        public double Total(string kind)
        {
            double totalAmount = 0;
            foreach (Transaction transaction in history)
            {
                if (transaction.Kind.Equals(kind))
                {
                    totalAmount += transaction.Amount;
                }
            }
            return totalAmount;
        }
        public void PrintStatement()
        {
            Console.WriteLine($"""
            ========================================
            STATEMENT FOR {account.Owner}
            ========================================
             ID TYPE AMOUNT
            ----------------------------------------
            """);
            foreach (Transaction transaction in history)
            {
                Console.WriteLine(transaction.Describe());
            }
            Console.WriteLine($"""
            ----------------------------------------
            Deposits: {Total("Deposit")}
            Withdrawals: {Total("Withdrawal")}
            Ending balance: {account.Balance}
            ========================================
            """);

        }
    }
}