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

        public void addMoney(int value)
        {
            balance = balance + value;
        }

        public void removeMoney(int value)
        {
            balance = balance - value;
        }
    }
}



//    //Arv är när en klass kan ärva olika attributer, och metoder ifrån en annan klass.
//    public class Building
//    {
//        //Olika attributer som klassen har
//        public string Colour;
//        public int Size;
//        public string typeOfBuilding;

//        //En metod som klassen har och kan använda
//        public void UnlockDoor()
//        {
//            Console.WriteLine("Dörren till din/ditt " + typeOfBuilding + " är upplåst!");
//        }

//        public void Leave()
//        {
//            Console.WriteLine("Du lämnade din/ditt " + typeOfBuilding + ", låste dörren och gick.");
//        }
//    }

//    // Apartment ärver ifrån Building klassen.
//    public class Apartment : Building
//    {
//        public string Stairway;

//        public void Leave()
//        {
//            Console.WriteLine("Du lämnade din " + typeOfBuilding + ", låste dörren och hälsade på dina grannar.");
//        }
//    }








////Här är private attributer som vi döljer
//private string patientName;
////Här är en konstruktor som sätter datan på ett säkert sätt
//public Patient(string patientName)
//{
//    Name = patientName;
//}

//public string Name
//{
//    get { return patientName; }
//    set { patientName = value; }
//}

////För att kunna nå vår data så kallar vi på en publik funktion
//public string getPatientName()
//{
//    return patientName;
//}