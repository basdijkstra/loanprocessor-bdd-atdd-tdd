namespace LoanProcessor.Models
{
    public class LoanApplication
    {
        public int LoanAmount { get; set; }
        public int DownPayment {  get; set; }
        public bool CreditStatusOk { get; set; }
    }
}
