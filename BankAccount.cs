using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ7
{
    enum BankAccountType
    {
        Savings,
        Checking,
        Deposit
    }

    internal class BankAccount
    {
        private static int accountNumberCounter = 1;
        private int accountNumber;
        private decimal balance;
        private BankAccountType accountType;

        public BankAccount(decimal initialBalance, BankAccountType type)
        {
            GenerateAccountNumber();
            balance = initialBalance;
            accountType = type;
        }

        public int AccountNumber
        {
            get { return accountNumber; }
        }

        public decimal Balance
        {
            get { return balance; }
        }

        public BankAccountType AccountType
        {
            get { return accountType; }
        }

        public void Withdraw(decimal amount)
        {
            if (balance >= amount)
            {
                balance -= amount;
                Console.WriteLine("Успешно сняли ${0} со счета номер {1}.", amount, accountNumber);
            }
            else
            {
                Console.WriteLine("Недостаточно средств на счете номер {0}.", accountNumber);
            }
        }

        public void Deposit(decimal amount)
        {
            balance += amount;
            Console.WriteLine("Успешно внесли ${0} на счет номер {1}.", amount, accountNumber);
        }

        public void Transfer(BankAccount toAccount, decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Сумма перевода должна быть положительной.");
                return;
            }

            if (balance >= amount)
            {
                Withdraw(amount);
                toAccount.Deposit(amount);
                Console.WriteLine("Успешно перевели ${0} со счета номер {1} на счет номер {2}.", amount, accountNumber, toAccount.AccountNumber);
            }
            else
            {
                Console.WriteLine("Недостаточно средств для перевода со счета номер {0}.", accountNumber);
            }
        }

        private void GenerateAccountNumber()
        {
            accountNumber = accountNumberCounter++;
        }
    }
}
