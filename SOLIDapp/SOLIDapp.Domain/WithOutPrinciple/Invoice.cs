namespace SOLIDapp.Domain.WithOutPrinciple;

public class Invoice
{        
    public double GetInvoiceDiscount(double amount, InvoiceType invoiceType)
    {
        double finalAmount = 0;
        if (invoiceType == InvoiceType.FinalInvoice)
        {
            finalAmount = amount - 60;
        }
        else if (invoiceType == InvoiceType.ProposedInvoice)
        {
            finalAmount = amount - 50;
        }
        return finalAmount;
    }
}
public enum InvoiceType
{
    FinalInvoice,
    ProposedInvoice
};