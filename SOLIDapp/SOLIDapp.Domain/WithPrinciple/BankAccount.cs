namespace SOLIDapp.Domain.WithPrinciple;
public class BankAccount
{
    public int AccountNumber { get; private set; }
    public double Balance { get; private set; }
    public List<string> Transactions = new List<string>();
    public BankAccount(int accountNumber)
    {
        AccountNumber = accountNumber;
    }
    public void Deposit(double amount)
    {
        Balance += amount;
        Transactions.Add($"Deposited ${amount}. New Balance: ${Balance}");
    }
    public void Withdraw(double amount)
    {
        Balance -= amount;
        Transactions.Add($"Withdrew ${amount}. New Balance: ${Balance}");
    }
}
public class StatementPrinter //clase  que me da  el estao tanto el deposito  como el retiro con este  podeos ver el estado de la  cuenta 
{
    public string Print(BankAccount account)
    {
        string report = string.Empty;
        report += "Statement for Account: " + account.AccountNumber.ToString();
        foreach (var transaction in account.Transactions)
            report += transaction;
        return report;
    }        
}