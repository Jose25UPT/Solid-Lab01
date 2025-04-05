namespace SOLIDapp.Domain.WithOutPrinciple
{
    public class CreditCard
    {
        public string ProcessPayment(decimal amount)
        {
            return $"Processing credit card payment of {amount}";
        }
    }
    public class PaymentProcessor
    {
        public string ExecutePayment(decimal amount)
        {
            var creditCard = new CreditCard();
            return creditCard.ProcessPayment(amount);
        }
    }
}