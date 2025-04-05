namespace SOLIDapp.Domain.WithOutPrinciple;
/// <summary>
/// Clase de dominio que representa una cuenta Bancaria
/// </summary>
public class BankAccount
{
    public int AccountNumber { get; private set; }
    /// <summary>
    /// Propiedad que representa el saldo de una cuenta
    /// </summary>
    /// <value>Tipo double</value>
    public double Balance { get; private set; }
    private List<string> Transactions = new List<string>();
    public BankAccount(int accountNumber)
    {
        AccountNumber = accountNumber;
    }
    /// <summary>
    /// Metodo que solo ejecuta un deposito en la cuenta para un determinado monto
    /// </summary>
    /// <param name="amount">Representa el monto que sera depositado</param>
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
    public string PrintStatement()
    {
        string report = string.Empty;
        report += "Statement for Account: " + AccountNumber.ToString();
        foreach (var transaction in Transactions)
            report += transaction;
        return report;
    }
}