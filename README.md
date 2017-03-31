# Bank-Kata
Example implementation of the Bank Kata using Outside in TDD

## The brief


Implement a basic bank account with three operations:

- Deposit an amount

- Withdraw an amount

- Print a statement
 
The statement should list all transactions, with the most recent first. For each transaction, the statement should show when it occurred, the amount, and the account balance after the transaction.

## Hints


- Think about what your first test should be. 

- Think about the domain concepts in the spec. Should any of them influence the public interface of the system under test?

- Think about the boundaries of the system under test: what do you have control over, and what lies outside?

- Think about how you will test the date/time of the transactions.

- Think about how you will test what is sent to the printer.

- No edge cases are mentioned in the spec. For example, we don't know whether the account can go overdrawn.
