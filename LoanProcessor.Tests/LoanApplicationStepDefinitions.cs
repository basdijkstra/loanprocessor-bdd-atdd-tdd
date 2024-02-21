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
        private LoanApplication loanApplication;
        private string loanApplicationResult = string.Empty;

        [Given("John is applying for a loan")]
        public void GivenJohnIsApplyingForALoan(DataTable dataTable)
        {
            loanApplication = dataTable.CreateInstance<LoanApplication>();
        }

        [When("the loan application is submitted")]
        public void WhenTheLoanApplicationIsSubmitted()
        {
            var webAppFactory = new WebApplicationFactory<Program>();
            var httpClient = webAppFactory.CreateDefaultClient();

            loanApplicationResult = (string)Given(httpClient)
                .Body(loanApplication)
                .When()
                .Post("http://localhost:5118/loanapplication")
                .Then()
                .StatusCode(200)
                .Extract()
                .Body("$.result");
        }

        [Then(@"^the loan application will be (approved|denied)$")]
        public void ThenTheLoanApplicationWillBeGranted(string expectedResult)
        {
            Assert.That(loanApplicationResult, Is.EqualTo(expectedResult));
        }
    }
}
