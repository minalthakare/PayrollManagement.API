namespace PayrollManagement.API.Services
{
    public class PayrollCalculator
    {
        public decimal CalculateNetPay(
            decimal basicSalary,
            int workingDays,
            int daysPresent)
        {
            decimal grossPay =
                (basicSalary / workingDays)
                * daysPresent;

            decimal pfDeduction =
                basicSalary * 0.12m;

            decimal professionalTax = 200;

            return Math.Round(
                grossPay -
                pfDeduction -
                professionalTax,
                2);
        }


    }
}