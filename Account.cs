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
        //Vi returnerar Konto nummret
        public string getAccountNum()
        {
            return accountNum;
        }
        //Vi lägger till pengar
        public void addMoney(int value)
        {
            balance = balance + value;
        }
        //Vi tar bort pengar
        public void removeMoney(int value)
        {
            balance = balance - value;
        }
    }
}