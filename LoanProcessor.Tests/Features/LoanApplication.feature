Feature: LoanApplication
Loan application should be granted only when the
loan amount, down payment and credit status are within acceptable limits

Rule: Loan applications up to and including dollars should always be approved

Scenario Outline: Loan applications up to and including 1000 are always approved
  Given John is applying for a loan
    | LoanAmount   | DownPayment   | CreditStatusOk   |
    | <loanAmount> | <downPayment> | <creditStatusOk> |
  When the loan application is submitted
  Then the loan application will be approved
  Examples: 
    | loanAmount | downPayment | creditStatusOk |
    | 1          | 1           | true           |
    | 500        | 10          | false          |
    | 1000       | 88          | false          |

Rule: Loan applications over 1000000 dollars should always be denied

Scenario Outline: Loan applications over 1000000 are always denied
  Given John is applying for a loan
    | LoanAmount   | DownPayment   | CreditStatusOk   |
    | <loanAmount> | <downPayment> | <creditStatusOk> |
  When the loan application is submitted
  Then the loan application will be denied
  Examples: 
    | loanAmount | downPayment | creditStatusOk |
    | 1000001    | 100         | true           |
    | 9999999    | 1000000     | false          |

Rule: Loan applications from 1001-1000000 are granted when the down payment is at least 10% and the credit status is OK

Scenario Outline: Down payment should be at least 10%
  Given John is applying for a loan
    | LoanAmount   | DownPayment   | CreditStatusOk   |
    | <loanAmount> | <downPayment> | <creditStatusOk> |
  When the loan application is submitted
  Then the loan application will be <result>
  Examples: 
    | loanAmount | downPayment | creditStatusOk | result   |
    | 1001       | 100         | true           | denied   |
    | 1001       | 101         | true           | approved |
    | 1000000    | 99999       | true           | denied   |
    | 1000000    | 100000      | true           | approved |

Scenario Outline: Credit status should be OK
  Given John is applying for a loan
    | LoanAmount   | DownPayment   | CreditStatusOk   |
    | <loanAmount> | <downPayment> | <creditStatusOk> |
  When the loan application is submitted
  Then the loan application will be <result>
  Examples: 
    | loanAmount | downPayment | creditStatusOk | result   |
    | 1001       | 101         | false          | denied   |
    | 1001       | 101         | true           | approved |
    | 1000000    | 100000      | false          | denied   |
    | 1000000    | 100000      | true           | approved |