using LoanProcessor.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using NUnit.Framework;
using Reqnroll;

using static RestAssured.Dsl;

namespace LoanProcessor.Tests
{
    [Binding]
    public class LoanApplicationStepDefinitions
    {
        [Given("John is applying for a loan")]
        public void GivenJohnIsApplyingForALoan(DataTable dataTable)
        {
            throw new PendingStepException();
        }

        [When("the loan application is submitted")]
        public void WhenTheLoanApplicationIsSubmitted()
        {
            throw new PendingStepException();
        }

        [Then(@"^the loan application will be (approved|denied)$")]
        public void ThenTheLoanApplicationWillBeGranted(string expectedResult)
        {
            throw new PendingStepException();
        }
    }
}
