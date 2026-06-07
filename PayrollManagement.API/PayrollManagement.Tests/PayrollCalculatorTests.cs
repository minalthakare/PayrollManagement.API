using Xunit;
using PayrollManagement.API.Services;

namespace PayrollManagement.Tests
{
    public class PayrollCalculatorTests
    {
        [Fact]
        public void CalculateNetPay_NormalCase_ReturnsCorrectValue()
        {
            var calculator =
            new PayrollCalculator();


        var result =
            calculator.CalculateNetPay(
                30000,
                26,
                24);

            Assert.Equal(
                23892.31m,
                result);
        }

        [Fact]
        public void CalculateNetPay_FullAttendance_ReturnsCorrectValue()
        {
            var calculator =
                new PayrollCalculator();

            var result =
                calculator.CalculateNetPay(
                    30000,
                    26,
                    26);

            Assert.Equal(
                26200m,
                result);
        }

        [Fact]
        public void CalculateNetPay_ZeroDaysPresent_ReturnsNegativeAmount()
        {
            var calculator =
                new PayrollCalculator();

            var result =
                calculator.CalculateNetPay(
                    30000,
                    26,
                    0);

            Assert.Equal(
                -3800m,
                result);
        }

        [Fact]
        public void CalculateNetPay_OneDayPresent_ReturnsCorrectValue()
        {
            var calculator =
                new PayrollCalculator();

            var result =
                calculator.CalculateNetPay(
                    30000,
                    26,
                    1);

            Assert.Equal(
                -2646.15m,
                result);
        }
    }


}
