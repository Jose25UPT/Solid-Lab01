namespace SOLIDapp.Domain.WithPrinciple;
/// <summary>
/// Clase de dominio que representa una cuenta Bancaria
/// </summary>
public abstract class Account
{
    protected double balance;
    public List<string> Transactions = new List<string>();

    public virtual void Deposit(double amount)
    {
        balance += amount;
        Transactions.Add($"Deposit: {amount}, Total Amount: {balance}");
    }
    public abstract void Withdraw(double amount);
    public double GetBalance()
    {
        return balance;
    }
}
public class RegularAccount : Account
{
    public override void Withdraw(double amount)
    {
        if (balance >= amount)
        {
            balance -= amount;
            Transactions.Add($"Withdraw: {amount}, Balance: {balance}");
        }
        else
        {
            Transactions.Add($"Trying to Withdraw: {amount}, Insufficient Funds, Available Funds: {balance}");
        }
    }
}
public class FixedTermDepositAccount : Account
{
    private bool termEnded = false; // simplification for the example
    public override void Withdraw(double amount)
    {
        if (!termEnded)
        {
            Transactions.Add("Cannot withdraw from a fixed term deposit account until term ends");
        }
        else if (balance >= amount)
        {
            balance -= amount;
            Transactions.Add($"Withdraw: {amount}, Balance: {balance}");
        }
        else
        {
            Console.WriteLine($"Trying to Withdraw: {amount}, Insufficient Funds, Available Funds: {balance}");
        }
    }
}