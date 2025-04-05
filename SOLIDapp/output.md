```mermaid
classDiagram

class Class

class Account
Account : +Deposit() Void
Account : +Withdraw() Void
Account : +GetBalance() Double

class RegularAccount
RegularAccount : +Withdraw() Void
RegularAccount : +Deposit() Void
RegularAccount : +GetBalance() Double

class FixedTermDepositAccount
FixedTermDepositAccount : +Withdraw() Void
FixedTermDepositAccount : +Deposit() Void
FixedTermDepositAccount : +GetBalance() Double

class BankAccount
BankAccount : +Int AccountNumber
BankAccount : +Double Balance
BankAccount : +Deposit() Void
BankAccount : +Withdraw() Void

class StatementPrinter
StatementPrinter : +Print() String

class ICreateDocument
ICreateDocument : +CreateDocument() Void

class IReadDocument
IReadDocument : +ReadDocument() String

class IUpdateDocument
IUpdateDocument : +UpdateDocument() Void

class IDeleteDocument
IDeleteDocument : +DeleteDocument() Void

class ReadOnlyUser
ReadOnlyUser : +ReadDocument() String

class AdminUser
AdminUser : +CreateDocument() Void
AdminUser : +ReadDocument() String
AdminUser : +UpdateDocument() Void
AdminUser : +DeleteDocument() Void

class Invoice
Invoice : +GetInvoiceDiscount() Double

class FinalInvoice
FinalInvoice : +GetInvoiceDiscount() Double

class ProposedInvoice
ProposedInvoice : +GetInvoiceDiscount() Double

class RecurringInvoice
RecurringInvoice : +GetInvoiceDiscount() Double

class IPaymentMethod
IPaymentMethod : +ProcessPayment() String

class CreditCard
CreditCard : +ProcessPayment() String

class PayPal
PayPal : +ProcessPayment() String

class PaymentProcessor
PaymentProcessor : +ExecutePayment() String

class IDocumentManagement
IDocumentManagement : +CreateDocument() Void
IDocumentManagement : +ReadDocument() String
IDocumentManagement : +UpdateDocument() Void
IDocumentManagement : +DeleteDocument() Void


Account <|-- RegularAccount
Account <|-- FixedTermDepositAccount
IReadDocument <|.. ReadOnlyUser
ICreateDocument <|.. AdminUser
IReadDocument <|.. AdminUser
IUpdateDocument <|.. AdminUser
IDeleteDocument <|.. AdminUser
Invoice <|-- FinalInvoice
Invoice <|-- ProposedInvoice
Invoice <|-- RecurringInvoice
IPaymentMethod <|.. CreditCard
IPaymentMethod <|.. PayPal

```
