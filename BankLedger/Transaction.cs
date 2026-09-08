namespace BankLedger
{
    class Transaction
    {
        private int id;
        private string kind;
        private double amount;
        public int Id
        {
            get
            {
                return id;
            }
        }

        public string Kind
        {
            get
            {
                return kind;
            }
        }
        public double Amount
        {
            get
            {
                return amount;
            }
        }


        public Transaction(int id, string kind, double amount)
        {
            this.id = id;
            this.kind = kind;
            this.amount = amount;
        }
        public bool IsDeposit()
        {
            return kind.Equals("Deposit");
        }
        public string Describe()
        {
            return string.Format("{0,4}  {1,-12} ${2,10:N2}", id, kind, amount);
        }
    }
}