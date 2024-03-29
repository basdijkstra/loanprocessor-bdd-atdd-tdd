using LoanProcessor.Models;

namespace LoanProcessor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.MapPost("/loanapplication", (LoanApplication loanApplication) =>
            {
                var response = new LoanApplicationResponse
                {
                    Result = ProcessLoanApplication(loanApplication)
                };

                return Results.Ok(response);
            })
            .WithName("PostLoanApplication")
            .WithOpenApi();

            app.Run();
        }

        internal static string ProcessLoanApplication(LoanApplication loanApplication)
        {
            if (loanApplication.LoanAmount <= 0)
            {
                throw new ArgumentException("Loan amount should be a positive non-null integer");
            }

            if (loanApplication.DownPayment <= 0)
            {
                throw new ArgumentException("Down payment should be a positive non-null integer");
            }

            if (loanApplication.LoanAmount <= 1000)
            {
                return "approved";
            }

            if (loanApplication.LoanAmount > 1000000)
            {
                return "denied";
            }

            if (loanApplication.DownPayment * 10 < loanApplication.LoanAmount)
            {
                return "denied";
            }

            return loanApplication.CreditStatusOk ? "approved" : "denied";
        }
    }
}
