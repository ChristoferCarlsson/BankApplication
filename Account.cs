using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BankApplication
{
    internal class Account
    {
        //Vi skapar alla variablar
        private string accountName;
        private string accountNum;
        private int balance = 0;

        private string firstTransaction = null;
        private string lastTransaction = null;

        //Vi sätter informationen använder get på ett säkert sätt
        public Account(string accountName)
        {
            Name = accountName;
        }
        public string Name
        {
            get { return accountName; }
            set { accountName = value; }
        }

        //Vi skapar kontot
        public void createAccount()
        {
            Random rnd = new Random();
            accountNum = rnd.Next(100, 999).ToString();
        }

        //Vi returnerar namnet på användaren
        public string getName()
        {
            return accountName;
        }
        //Vi returnerar konto balansen
        public int getBalance()
        {
            return balance;
        }
        //Vi returnerar transaktionerna
        public string getTransactions()
        {
            if (firstTransaction == null)
            {
                return $"Du har inga transaktioner";
            } else
            {
                return $"Första transaktionen var att du {firstTransaction} och sista var att du {lastTransaction}";
            }
        }
        //Vi returnerar Konto nummret
        public string getAccountNum()
        {
            return accountNum;
        }
        //Vi lägger till pengar
        public void addMoney(int value)
        {
            balance = balance + value;

            if (firstTransaction == null)
            {
                firstTransaction = $"lagt till {balance}";
            }
                lastTransaction = $"lagt till {balance}";
        }
        //Vi tar bort pengar
        public void removeMoney(int value)
        {
            balance = balance - value;

            if (firstTransaction == null)
            {
                firstTransaction = $"tagit bort {balance}";
            }
                lastTransaction = $"tagit bort {value}";

        }
        //Vi sparar vår transaktion
        public void saveTransfer(int balance, string option)
        {

            if (option == "sent")
            {
                if (firstTransaction == null)
                {
                    firstTransaction = $"skickade {balance} till ett konto";
                }
                lastTransaction = $"skickade {balance} till ett konto";
            }
            else if (option == "recieved")
            {
                if (firstTransaction == null)
                {
                    firstTransaction = $"tog emot {balance} ifrån ett konto";
                }
                lastTransaction = $"tog emot {balance} ifrån ett konto";
            }

        }
    }
}