namespace CustomerBank.Model
{
    public class AccountModel
    {
        public string AccountNumber { get; set; }
        public int CustomerId { get; set; }
        public string AccountType { get; set; }
        public string SubAccountType { get; set; }
        public int RateOfInterest { get; set; }
        public string CardNumber { get; set; }
        public string CurrencyType { get; set; }
        public string Branch { get; set; }
        public string IFSCCode { get; set; }
        public bool IsActive { get; set; }

    }
}
