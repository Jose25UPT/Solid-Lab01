namespace SOLIDapp.Domain.WithPrinciple
{
//Interface for Payment
    public interface IPaymentMethod
    {
        string ProcessPayment(decimal amount);
    }
    
    //Concrete Implementations
    public class CreditCard : IPaymentMethod
    {
        public string ProcessPayment(decimal amount)
        {
            return $"Processing credit card payment of {amount}";
        }
    }
    public class PayPal : IPaymentMethod
    {
        public string ProcessPayment(decimal amount)
        {
            return $"Processing PayPal payment of {amount}";
        }
    }
    //Our PaymentProcessor class will now depend on the abstraction
    public class PaymentProcessor
    {
        private readonly IPaymentMethod _paymentMethod;
        public PaymentProcessor(IPaymentMethod paymentMethod)
        {
            _paymentMethod = paymentMethod;
        }
        public string ExecutePayment(decimal amount)
        {
            return _paymentMethod.ProcessPayment(amount);
        }
    }
}