[![Review Assignment Due Date](https://classroom.github.com/assets/deadline-readme-button-22041afd0340ce965d47ae6ef1cefeee28c7c493a6346c4f15d667ab976d596c.svg)](https://classroom.github.com/a/wdl2-AB_)
[![Open in Codespaces](https://classroom.github.com/assets/launch-codespace-2972f46106e565e64193e422d61a12cf1da4916b45550586e14ef0a7c637dd04.svg)](https://classroom.github.com/open-in-codespaces?assignment_repo_id=18918510)
# SESION DE LABORATORIO N° 01: Principios de Diseño - SOLID

### Nombre:

## OBJETIVOS
  * Comprender los principios de diseño más importantes para el desarrollo de software.

## REQUERIMIENTOS
  * Conocimientos: 
    - Conocimientos básicos de bash, terminal o powershell.
    - Conocimientos básicos de programaciòn en C#.
  * Hardware:
    - Virtualization activada en el BIOS.
    - CPU SLAT-capable feature.
    - Al menos 4GB de RAM.
  * Software:
    - Docker Desktop 
    - Powershell versión 7.x
    - .Net 8 o superior

## CONSIDERACIONES INICIALES
  * Clonar el repositorio mediante git para tener los recursos necesarios.
  
## DESARROLLO

1. Iniciar la aplicación Powershell o Windows Terminal en modo administrador. Ubicarse en una ruta que no sea del sistema.
2. En el Terminal, ejecutar los siguientes comandos:.
```Powershell
dotnet new sln -o SOLIDapp
cd SOLIDapp
dotnet new classlib -o SOLIDapp.Domain
dotnet new mstest -o SOLIDapp.Tests
dotnet sln add SOLIDapp.Domain
dotnet sln add SOLIDapp.Tests
dotnet add SOLIDapp.Tests reference SOLIDapp.Domain
```
3. Iniciar Visual Studio Code apntando a la carpeta recien creada, o desde el terminal ejecutar el comando `code .` para iniciarlo.
4. En Visual Studio Code, en el proyecto SOLIDapp.Domain, crear 2 carpetas: WithOutPrinciple y WithPrinciple

### PRINCIPIO DE RESPONSABILIDAD UNICA

5. En Visual Studio Code, en el proyecto SOLIDapp.Domain en la carpeta WithOutPrinciple, crear el archivo BankAccount.cs con el siguiente contenido:
```C#
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
```
6. En Visual Studio Code, en el proyecto SOLIDapp.Tests, crear el archivo WithOutPrinciples.cs con el siguiente contenido:
```C#
using SOLIDapp.Domain.WithOutPrinciple;

namespace SOLIDapp.Tests;

[TestClass]
public class WithOutPrinciples
{
    [TestMethod]
    public void GivenSimpleResponsabilityPrincipleExample_ExecuteWithOutPrinciple_ResultSuccess()
    {
            BankAccount johnsAccount = new BankAccount(123456);
            johnsAccount.Deposit(500);
            johnsAccount.Withdraw(100);
            johnsAccount.PrintStatement();
            string report = johnsAccount.PrintStatement();
            Assert.IsTrue(report.Contains("123456"));
            Assert.IsTrue(report.Contains("500"));
            Assert.IsTrue(report.Contains("100"));
    }
}
```
7. En el Terminal, ejecutar el siguiente comando.
```Powershell
dotnet test
```

8. En Visual Studio Code, en el proyecto SOLIDapp.Domain en la carpeta WithPrinciple, crear el archivo BankAccount.cs con el siguiente contenido:
```C#
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
public class StatementPrinter
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
```

9. En Visual Studio Code, en el proyecto SOLIDapp.Tests, crear el archivo WithPrinciples.cs con el siguiente contenido:
```C#
using SOLIDapp.Domain.WithPrinciple;

namespace SOLIDapp.Tests;
[TestClass]
public class WithPrinciples
{
    [TestMethod]
    public void GivenSimpleResponsabilityPrincipleExample_ExecuteWithPrinciple_ResultSuccess()
    {
            BankAccount johnsAccount = new BankAccount(123456);
            johnsAccount.Deposit(500);
            johnsAccount.Withdraw(100);
            StatementPrinter printer = new StatementPrinter();
            string report = printer.Print(johnsAccount);
            Assert.IsTrue(report.Contains("123456"));
            Assert.IsTrue(report.Contains("500"));
            Assert.IsTrue(report.Contains("100"));
    }
}
```
10. En el Terminal, ejecutar el siguiente comando.
```Powershell
dotnet test
```

### PRINCIPIO DE ABIERTO CERRADO

11. En Visual Studio Code, en el proyecto SOLIDapp.Domain en la carpeta WithOutPrinciple, crear el archivo Invoice.cs con el siguiente contenido:
```C#
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
```
12. En Visual Studio Code, en el proyecto SOLIDapp.Tests, en el archivo WithOutPrinciples.cs adicionar el siguiente contenido:
```C#
    [TestMethod]
    public void GivenOpenClosedPrincipleExample_ExecuteWithOutPrinciple_ResultSuccess()
    {
        Invoice FInvoice = new Invoice();
        double FInvoiceAmount = FInvoice.GetInvoiceDiscount(10000, InvoiceType.FinalInvoice);
        Assert.IsTrue( FInvoiceAmount == 9940);

        Invoice PInvoice = new Invoice();
        double PInvoiceAmount = PInvoice.GetInvoiceDiscount(10000, InvoiceType.ProposedInvoice);
        Assert.IsTrue( PInvoiceAmount == 9950);
    }
```
13. En el Terminal, ejecutar el siguiente comando.
```Powershell
dotnet test
```

14. En Visual Studio Code, en el proyecto SOLIDapp.Domain en la carpeta WithPrinciple, crear el archivo Invoice.cs con el siguiente contenido:
```C#
namespace SOLIDapp.Domain.WithPrinciple;
public class Invoice
{
    public virtual double GetInvoiceDiscount(double amount)
    {
        return amount - 10;
    }
}

public class FinalInvoice : Invoice
{
    public override double GetInvoiceDiscount(double amount)
    {
        return base.GetInvoiceDiscount(amount) - 50;
    }
}
public class ProposedInvoice : Invoice
{
    public override double GetInvoiceDiscount(double amount)
    {
        return base.GetInvoiceDiscount(amount) - 40;
    }
}
public class RecurringInvoice : Invoice
{
    public override double GetInvoiceDiscount(double amount)
    {
        return base.GetInvoiceDiscount(amount) - 30;
    }
}
```

15. En Visual Studio Code, en el proyecto SOLIDapp.Tests, en el archivo WithPrinciples.cs adicionar el siguiente contenido:
```C#
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
```
16. En el Terminal, ejecutar el siguiente comando.
```Powershell
dotnet test
```

### PRINCIPIO DE SUSTITUCION DE LISKOV

17. En Visual Studio Code, en el proyecto SOLIDapp.Domain en la carpeta WithOutPrinciple, crear el archivo Account.cs con el siguiente contenido:
```C#
﻿namespace SOLIDapp.Domain.WithOutPrinciple;
/// <summary>
/// Clase de dominio que representa una cuenta Bancaria
/// </summary>
public class Account
{
    protected double balance;
    public virtual void Deposit(double amount)
    {
        balance += amount;
    }
    public virtual void Withdraw(double amount)
    {
        if (balance >= amount)
        {
            balance -= amount;
        }
        else
        {
            throw new InvalidOperationException("Insufficient funds");
        }
    }
    public double GetBalance()
    {
        return balance;
    }
}
public class FixedTermDepositAccount : Account
{
    public override void Withdraw(double amount)
    {
        throw new InvalidOperationException("Cannot withdraw from a fixed term deposit account until term ends");
    }
}
```
18. En Visual Studio Code, en el proyecto SOLIDapp.Tests, en el archivo WithOutPrinciples.cs adicionar el siguiente contenido:
```C#
    [TestMethod]
    public void GivenLiskovSustitutionPrincipleExample_ExecuteWithOutPrinciple_ResultSuccess()
    {
        Account RegularBankAccount = new Account();
        RegularBankAccount.Deposit(1000);
        RegularBankAccount.Deposit(500);
        RegularBankAccount.Withdraw(900);
        var ex = Assert.ThrowsException<InvalidOperationException>(() => RegularBankAccount.Withdraw(800));
        Assert.AreEqual("Insufficient funds", ex.Message);;

        Account FixedTermDepositBankAccount = new FixedTermDepositAccount();
        FixedTermDepositBankAccount.Deposit(1000);
        ex = Assert.ThrowsException<InvalidOperationException>(() => FixedTermDepositBankAccount.Withdraw(500));
        Assert.AreEqual("Cannot withdraw from a fixed term deposit account until term ends", ex.Message);;
    }
```
19. En el Terminal, ejecutar el siguiente comando.
```Powershell
dotnet test
```

20. En Visual Studio Code, en el proyecto SOLIDapp.Domain en la carpeta WithPrinciple, crear el archivo Account.cs con el siguiente contenido:
```C#
﻿namespace SOLIDapp.Domain.WithPrinciple;
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
```

21. En Visual Studio Code, en el proyecto SOLIDapp.Tests, en el archivo WithPrinciples.cs adicionar el siguiente contenido:
```C#
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
```
22. En el Terminal, ejecutar el siguiente comando.
```Powershell
dotnet test
```

### PRINCIPIO DE SEGREGACIÓN DE INTERFACES

23. En Visual Studio Code, en el proyecto SOLIDapp.Domain en la carpeta WithOutPrinciple, crear el archivo DocumentManagement.cs con el siguiente contenido:
```C#
namespace SOLIDapp.Domain.WithOutPrinciple
{
    public interface IDocumentManagement
    {
        void CreateDocument(string content);
        string ReadDocument(int id);
        void UpdateDocument(int id, string content);
        void DeleteDocument(int id);
    }
    public class ReadOnlyUser : IDocumentManagement
    {
        public void CreateDocument(string content)
        {
            throw new NotImplementedException("Read-only users cannot create documents.");
        }
        public string ReadDocument(int id)
        {
            // Implementation to read the document.
            return "Sample document content.";
        }
        public void UpdateDocument(int id, string content)
        {
            throw new NotImplementedException("Read-only users cannot update documents.");
        }
        public void DeleteDocument(int id)
        {
            throw new NotImplementedException("Read-only users cannot delete documents.");
        }
    }
}
```
24. En Visual Studio Code, en el proyecto SOLIDapp.Tests, en el archivo WithOutPrinciples.cs adicionar el siguiente contenido:
```C#
    [TestMethod]
    public void GivenInterfaceSegregationPrincipleExample_ExecuteWithOutPrinciple_ResultSuccess()
    {
        ReadOnlyUser readOnlyUser = new ReadOnlyUser();
        readOnlyUser.CreateDocument("document"); //Compile Time Error
        readOnlyUser.ReadDocument(1);
        readOnlyUser.UpdateDocument(1, "document");  //Compile Time Error
        readOnlyUser.DeleteDocument(1);  //Compile Time Error
    }
```
25. En el Terminal, ejecutar el siguiente comando.
```Powershell
dotnet test
```
> El comando anterior arrojara como resultado un error, reescriba el test para manejar las excepciones.

26. En Visual Studio Code, en el proyecto SOLIDapp.Domain en la carpeta WithPrinciple, crear el archivo DocumentManagement.cs con el siguiente contenido:
```C#
namespace SOLIDapp.Domain.WithPrinciple;

public interface ICreateDocument
{
    void CreateDocument(string content);
}
public interface IReadDocument
{
    string ReadDocument(int id);
}
public interface IUpdateDocument
{
    void UpdateDocument(int id, string content);
}
public interface IDeleteDocument
{
    void DeleteDocument(int id);
}
// For read-only users:
public class ReadOnlyUser : IReadDocument
{
    public string ReadDocument(int id)
    {
        // Implementation to read the document.
        return "Sample Document Content.";
    }
}
// For admin users who have all privileges:
public class AdminUser : ICreateDocument, IReadDocument, IUpdateDocument, IDeleteDocument
{
    string[] documents = new string[2] ;
    public void CreateDocument(string content)
    {
        documents[1] = content;
    }
    public string ReadDocument(int id)
    {
        // Implementation to read the document.
        return documents[id];
    }
    public void UpdateDocument(int id, string content)
    {
        documents[id] = content;
    }
    public void DeleteDocument(int id)
    {
        documents[id] = string.Empty;        
    }
}
```

27. En Visual Studio Code, en el proyecto SOLIDapp.Tests, en el archivo WithPrinciples.cs adicionar el siguiente contenido:
```C#
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
```
28. En el Terminal, ejecutar el siguiente comando.
```Powershell
dotnet test
```

### PRINCIPIO DE INVERSION DE DEPENDENCIAS

29. En Visual Studio Code, en el proyecto SOLIDapp.Domain en la carpeta WithOutPrinciple, crear el archivo PaymentProcessor.cs con el siguiente contenido:
```C#
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
```
30. En Visual Studio Code, en el proyecto SOLIDapp.Tests, en el archivo WithOutPrinciples.cs adicionar el siguiente contenido:
```C#
    [TestMethod]
    public void GivenDependencyInversionPrincipleExample_ExecuteWithOutPrinciple_ResultSuccess()
    {
        // var creditCardPayment = new CreditCard();
        var paymentProcessor1 = new PaymentProcessor();
        var voucher = paymentProcessor1.ExecutePayment(100m);
        Assert.IsTrue(voucher.Contains("100"));
        // var paypalPayment = new PayPal();
        // var paymentProcessor2 = new PaymentProcessor(paypalPayment);
        // voucher = paymentProcessor2.ExecutePayment(100m);
        // Assert.IsTrue(voucher.Contains("100"));
    }
```
31. En el Terminal, ejecutar el siguiente comando.
```Powershell
dotnet test
```

32. En Visual Studio Code, en el proyecto SOLIDapp.Domain en la carpeta WithPrinciple, crear el archivo Invoice.cs con el siguiente contenido:
```C#
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
```

33. En Visual Studio Code, en el proyecto SOLIDapp.Tests, en el archivo WithPrinciples.cs adicionar el siguiente contenido:
```C#
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
```
34. En el Terminal, ejecutar el siguiente comando.
```Powershell
dotnet test
```

### BONUS: DIAGRAMAS Y DOCUMENTACIÓN
35. En el Terminal, ejecutar el siguiente comando.
```Powershell
dotnet tool install -g docfx
docfx init -y
```
36. En el Visual Studio Code, editar el archivo toc.yml con el siguiente contenido.
```Yaml
Items:
- name: Docs
  href: docs/toc.yml
- name: API
  href: api/toc.yml
```
36. En el Visual Studio Code, editar el archivo docfx.json y cambiar solo la siguiente linea.
```Json
  "src": ".",
```
          
36. En el Terminal, ejecutar el siguiente comando.
```Powershell
docfx metadata docfx.json
docfx build
docfx pdf
```
> revisar el archivo toc.pdf

37. En el Terminal, ejecutar el siguiente comando.
```Powershell
dotnet tool install --global dll2mmd
dll2mmd -f SOLIDapp.Domain/bin/Debug/net7.0/SOLIDapp.Domain.dll
```
> revisar el archivo output.md
---
## Actividades Encargadas
1. Arreglar el test de prueba que genera error
2. Completar la documentación de todas las clases y subir el archivo de documentación con el nombre solid.pdf
3. Generar una automatización de nombre .github/workflows/package_nuget.yml (Github Workflow) que contruya un archivo .nuget a partir del proyecto SOLIDApp.Domain y lo publique como un Paquete de Github
4. Generar una automatización de nombre .github/workflows/release_version.yml (Github Workflow) que contruya la version del paquete y publique en Github Releases
