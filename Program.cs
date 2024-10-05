using System.Security.Principal;

namespace BankApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Vi skapar alla variablar som vi behöver
            bool running = true;
            string input;

            bool personalCreated = false;
            bool savingsCreated = false;
            bool InvestmentCreated = false;

            Account personalAccount = null;
            Account savingsAccount = null;
            Account investmentAccount = null;

            Console.WriteLine("Välkommen!");
            Console.WriteLine("Vad är ditt namn?");

            string userName = Console.ReadLine();

            while (running)
            {
                Console.Clear();
                Console.WriteLine("Var vänlig att välj ett av följande val.");
                Console.WriteLine("1: Kontohantering.");
                Console.WriteLine("2: Transaktioner.");
                Console.WriteLine("3: Balanskontroll.");
                Console.WriteLine("4: Avsluta.");
                input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        //Vi kör en ny loop och Case för Kontohantering
                        bool accountRunning = true;
                        while (accountRunning)
                        {
                            Console.WriteLine("Vad för konto skulle du vilja skapa?");
                            Console.WriteLine("1: Personkonto");
                            Console.WriteLine("2: Sparkonto");
                            Console.WriteLine("3: Invenstera");
                            Console.WriteLine("4: Tillbaka");
                            input = Console.ReadLine();
                            switch (input)
                            {
                                case "1":
                                    if (personalCreated == false)
                                    {
                                        personalAccount = new Account(userName);
                                        personalAccount.createAccount();
                                        Console.WriteLine($"Grattis! {userName} Ditt kontonummer är: {personalAccount.getAccountNum()} och ditt saldo är: {personalAccount.getBalance()}");
                                        personalCreated = true;
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Du har redan ett konto med kontonummer: {personalAccount.getAccountNum()}");
                                    }
                                    break;

                                case "2":
                                    if (savingsCreated == false)
                                    {
                                        savingsAccount = new Account(userName);
                                        savingsAccount.createAccount();
                                        Console.WriteLine($"Grattis! {userName} Ditt kontonummer är: {savingsAccount.getAccountNum()} och ditt saldo är: {savingsAccount.getBalance()}");
                                        savingsCreated = true;
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Du har redan ett konto med kontonummer: {savingsAccount.getAccountNum()}");
                                    }
                                    break;

                                case "3":
                                    if (InvestmentCreated == false)
                                    {
                                        investmentAccount = new Account(userName);
                                        investmentAccount.createAccount();
                                        Console.WriteLine($"Grattis! {userName} Ditt kontonummer är: {investmentAccount.getAccountNum()} och ditt saldo är: {investmentAccount.getBalance()}");
                                        InvestmentCreated = true;
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Du har redan ett konto med kontonummer: {investmentAccount.getAccountNum()}");
                                    }
                                    break;

                                case "4":
                                    accountRunning = false;
                                    break;

                                default:
                                    Console.WriteLine("Jag förstår inte, försök igen.");
                                    break;
                            }
                        };
                        break;
                    case "2":
                        //Vi vill inte ha en loop på alla saker, så som här
                        Console.Clear();
                        Console.WriteLine("Vad för konto vill du nå?");
                        Console.WriteLine("1: Personkonto");
                        Console.WriteLine("2: Sparkonto");
                        Console.WriteLine("3: Investeringskonto");
                        input = Console.ReadLine();
                        switch (input)
                        {
                            case "1":
                                /*Vi skickar information i den här ordningen "Bool om konto har blivit skapat, Namn för kontot, Kontot." */
                                /*Först är kontot som vi är inloggad som, sedan kontot som ligger i andra kolumnen, och sedan den tredje. */
                                Transactions(personalCreated, "Personkonto", personalAccount, savingsCreated, "Sparkonto", savingsAccount, InvestmentCreated, "Investeringskonto", investmentAccount);
                                break;

                            case "2":
                                Transactions(savingsCreated, "Sparkonto", savingsAccount, InvestmentCreated, "Investeringskonto", investmentAccount, personalCreated, "Personkonto", personalAccount);
                                break;


                            case "3":
                                Transactions(InvestmentCreated, "Investeringskonto", investmentAccount, personalCreated, "Personkonto", personalAccount, savingsCreated, "Sparkonto", savingsAccount);
                                break;

                            default:
                                Console.WriteLine("Jag förstår inte, försök igen.");
                                break;
                        }
                        break;

                    case "3":

                        //Vi kör en ny loop
                        bool balanceRunning = true;
                        while (balanceRunning)
                        {

                            Console.WriteLine("Vad för konto vill du kolla?");
                            Console.WriteLine("1: Personkonto");
                            Console.WriteLine("2: Sparkonto");
                            Console.WriteLine("3: Investeringskonto");
                            Console.WriteLine("4: Tillbaka");
                            input = Console.ReadLine();
                            switch (input)
                            {

                                case "1":
                                    if (personalCreated == true)
                                    {
                                        GetBalance(personalAccount);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Du har inget sådant konto");
                                    }
                                    break;

                                case "2":
                                    if (savingsCreated == true)
                                    {
                                        GetBalance(savingsAccount);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Du har inget sådant konto");
                                    }
                                    break;

                                case "3":
                                    if (InvestmentCreated == true)
                                    {
                                        GetBalance(investmentAccount);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Du har inget sådant konto");
                                    }
                                    break;


                                case "4":
                                    balanceRunning = false;
                                    break;

                                default:
                                    Console.WriteLine("Jag förstår inte, försök igen.");
                                    break;
                            }
                        }
                        break;
                    case "4":
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Jag förstår inte, försök igen.");
                        break;

                }
            };
        }
        static void GetBalance(Account mainAccount)
        {
            Console.Clear();
            Console.WriteLine("Var vänlig skriv in ditt kontonummer");
            string account = Console.ReadLine();

            if (account == mainAccount.getAccountNum())
            {
                Console.WriteLine($"Du har {mainAccount.getBalance()}");

                //Vi frågar om användaren vill se sina transaktioner.
                Console.WriteLine($"Vill du se dina transaktioner?");
                Console.WriteLine($"1: Ja");
                Console.WriteLine($"2: Nej");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        Console.WriteLine(mainAccount.getTransactions());
                        break;

                    case "2":
                        break;

                    default:
                        break;
                }
            }
            else
            {
                Console.WriteLine("Inget konto hittades");
            }
        }
        static void Transactions(bool mainAccountCreated, string mainAccountName, Account mainAccount, bool secondAccountCreated, string secondAccountName, Account secondAccount, bool thirdAccountCreated, string thirdAccountName, Account thirdAccount)
        {
            //Vi kollar om kontot finns
            if (mainAccountCreated == true)
            {
                Console.WriteLine("Var vänlig skriv in ditt kontonummer");
                string account = Console.ReadLine();

                //om kontot stämmer med numret som vi har skrivit in, så loggas användaren in
                if (account == mainAccount.getAccountNum())
                {
                    bool running = true;
                    while (running)
                    {
                        Console.WriteLine("Vad skulle du vilja göra?");
                        Console.WriteLine("1: Insättning");
                        Console.WriteLine("2: Uttagning");
                        Console.WriteLine("3: Överför");
                        Console.WriteLine("4: Tillbaka");
                        string input = Console.ReadLine();
                        switch (input)
                        {
                            case "1":
                                Console.WriteLine("Hur mycket vill du sätta in?");

                                string addValue = Console.ReadLine();
                                try
                                {
                                    //Vi kollar om det är ett nummer som användaren har skrivit in.
                                    int result = Int32.Parse(addValue);
                                    mainAccount.addMoney(result);

                                    Console.WriteLine($"Du har nu satt in {result} och har {mainAccount.getBalance()} på kontot");
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("Inget nummer, försök igen");
                                }
                                break;

                            case "2":
                                Console.WriteLine("Hur mycket vill du ta ut?");

                                string removeValue = Console.ReadLine();
                                try
                                {
                                    int result = Int32.Parse(removeValue);

                                    //Vi kollar så att det finns tillräckligt med pengar på kontot
                                    if (result <= mainAccount.getBalance())
                                    {
                                        mainAccount.removeMoney(result);
                                        Console.WriteLine($"Du har nu tagit ut {result} och har {mainAccount.getBalance()} på kontot");
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Du har inte tillräckligt på ditt konto");
                                    }

                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("Inget nummer, försök igen");
                                }
                                break;

                            case "3":

                                Console.WriteLine("Vad för konto vill du skicka till?");
                                Console.WriteLine($"1: {secondAccountName}");
                                Console.WriteLine($"2: {thirdAccountName}");
                                Console.WriteLine("3: Tillbaka");
                                input = Console.ReadLine();
                                switch (input)
                                {

                                    case "1":
                                        if (secondAccountCreated == true)
                                        {
                                            Console.WriteLine("Vilket konto nummer vill du skicka till?");
                                            account = Console.ReadLine();

                                            if (account == secondAccount.getAccountNum())
                                            {

                                                Console.WriteLine("Hur mycket vill du skicka?");

                                                string transfer = Console.ReadLine();
                                                try
                                                {
                                                    int result = Int32.Parse(transfer);

                                                    if (result <= mainAccount.getBalance())
                                                    {
                                                        //Vi lägger till och tar bort pengar ifrån konton, så att dom överförs
                                                        secondAccount.addMoney(result);
                                                        mainAccount.removeMoney(result);

                                                        //Vi sparar transaktionen
                                                        secondAccount.saveTransfer(result, "recieved");
                                                        mainAccount.saveTransfer(result, "sent");

                                                        Console.WriteLine($"Du har nu skickat {result} till {account}");
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine($"Du har inte tillräckligt på ditt konto");
                                                    }
                                                }
                                                catch (FormatException)
                                                {
                                                    Console.WriteLine("Inget nummer, försök igen");
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("Inget konto hittades");
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Du har inget sådant konto");
                                        }
                                        break;


                                    case "2":
                                        if (thirdAccountCreated == true)
                                        {
                                            Console.WriteLine("Var vänlig skriv in kontonummret till personen som du vill skicka till");
                                            account = Console.ReadLine();

                                            if (account == thirdAccount.getAccountNum())
                                            {

                                                Console.WriteLine("Hur mycket vill du skicka?");

                                                string transfer = Console.ReadLine();
                                                try
                                                {
                                                    int result = Int32.Parse(transfer);

                                                    if (result <= mainAccount.getBalance())
                                                    {
                                                        thirdAccount.addMoney(result);
                                                        mainAccount.removeMoney(result);

                                                        //Vi sparar transaktionen
                                                        thirdAccount.saveTransfer(result, "recieved");
                                                        mainAccount.saveTransfer(result, "sent");

                                                        Console.WriteLine($"Du har nu skickat {result} till {account}");
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine($"Du har inte tillräckligt på ditt konto");
                                                    }
                                                }
                                                catch (FormatException)
                                                {
                                                    Console.WriteLine("Inget nummer, försök igen");
                                                }

                                            }
                                            else
                                            {
                                                Console.WriteLine("Inget konto hittades");
                                            }

                                        }
                                        else
                                        {
                                            Console.WriteLine("Du har inget sådant konto");
                                        }
                                        break;

                                    case "3":
                                        break;

                                }

                                break;

                            case "4":
                                running = false;
                                break;

                            default:
                                Console.WriteLine("Jag förstår inte");
                                break;
                        }

                    }
                }
                else
                {
                    Console.WriteLine("Inget konto hittades");
                }
            }
            else
            {
                Console.WriteLine("Du har inget sådant konto");
            }
        }
    }
}
