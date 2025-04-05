using SOLIDapp.Domain.WithPrinciple;

namespace SOLIDapp.Tests;

[TestClass]
public class WithPrinciples
{
       
    [TestMethod]
    public void GivenOpenClosedPrincipleExample_ExecuteWithPrinciple_ResultSuccess()
    {
        Invoice FInvoice = new FinalInvoice();
        double FInvoiceAmount = FInvoice.GetInvoiceDiscount(10000);
        Assert.IsTrue( FInvoiceAmount == 9940);

        Invoice PInvoice = new ProposedInvoice();
        double PInvoiceAmount = PInvoice.GetInvoiceDiscount(10000);
        Assert.IsTrue( PInvoiceAmount == 9950);

        Invoice RInvoice = new RecurringInvoice();
        double RInvoiceAmount = RInvoice.GetInvoiceDiscount(10000);
        Assert.IsTrue( RInvoiceAmount == 9960);
    }
        [TestMethod]
    public void GivenLiskovSustitutionPrincipleExample_ExecuteWithPrinciple_ResultSuccess()
    {
        Account RegularBankAccount = new RegularAccount();
        RegularBankAccount.Deposit(1000);
        RegularBankAccount.Deposit(500);
        RegularBankAccount.Withdraw(900);
        RegularBankAccount.Withdraw(800);
        Assert.IsTrue( RegularBankAccount.GetBalance() == 600);
        Assert.IsTrue( RegularBankAccount.Transactions.Any(p => p.Contains("Insufficient Funds")));

        Account FixedTermDepositBankAccount = new FixedTermDepositAccount();
        FixedTermDepositBankAccount.Deposit(1000);
        FixedTermDepositBankAccount.Withdraw(500);
        Assert.IsTrue( FixedTermDepositBankAccount.GetBalance() == 1000);
    }

        [TestMethod]
    public void GivenInterfaceSegregationPrincipleExample_ExecuteWithPrinciple_ResultSuccess()
    {
        AdminUser adminUser = new AdminUser();
        adminUser.CreateDocument("Text Document");
        adminUser.ReadDocument(1);
        adminUser.UpdateDocument(1, "Updating the Content");
        adminUser.DeleteDocument(1);
        
        ReadOnlyUser readOnlyUser = new ReadOnlyUser();
        readOnlyUser.ReadDocument(1);
        //readOnlyUser.CreateDocument(); //Compile Time Error
        //readOnlyUser.UpdateDocument();  //Compile Time Error
        //readOnlyUser.DeleteDocument();  //Compile Time Error
    }

        [TestMethod]
    public void GivenDependencyInversionPrincipleExample_ExecuteWithPrinciple_ResultSuccess()
    {
        var creditCardPayment = new CreditCard();
        var paymentProcessor1 = new PaymentProcessor(creditCardPayment);
        var voucher = paymentProcessor1.ExecutePayment(100m);
        Assert.IsTrue(voucher.Contains("100"));
        var paypalPayment = new PayPal();
        var paymentProcessor2 = new PaymentProcessor(paypalPayment);
        voucher = paymentProcessor2.ExecutePayment(100m);
        Assert.IsTrue(voucher.Contains("100"));
    }



}
 




