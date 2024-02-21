using LoanProcessor.Models;
using NUnit.Framework;

namespace LoanProcessor.Tests
{
    public class LoanProcessorTests
    {
        [TestCase(0, TestName = "Loan amount cannot be 0")]
        [TestCase(-100, TestName = "Loan amount cannot be negative")]
        public void LoanAmountShouldBeAPositiveInteger(int loanAmount)
        {
            LoanApplication loanApplication = new LoanApplication
            {
                LoanAmount = loanAmount
            };

            Assert.Throws<ArgumentException>(() => Program.ProcessLoanApplication(loanApplication));
        }

        [TestCase(0, TestName = "Down payment cannot be 0")]
        [TestCase(-100, TestName = "Down payment cannot be negative")]
        public void DownPaymentShouldBeAPositiveInteger(int downPayment)
        {
            LoanApplication loanApplication = new LoanApplication
            {
                DownPayment = downPayment
            };

            Assert.Throws<ArgumentException>(() => Program.ProcessLoanApplication(loanApplication));
        }
    }
}
