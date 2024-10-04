using System.Security.Principal;

namespace BankApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {

            bool running = true;
            bool transactionRunning = false;
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
                                        Console.Clear();
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
                                        Console.Clear();
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
                                        Console.Clear();
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
                                    Console.Clear();
                                    accountRunning = false;
                                    break;

                                default:
                                    Console.WriteLine("Jag förstår inte, försök igen.");
                                    break;
                            }
                        };
                        break;
                    case "2":


                        Console.WriteLine("Vad för konto vill du nå?");
                        Console.WriteLine("1: Personkonto");
                        Console.WriteLine("2: Sparkonto");
                        Console.WriteLine("3: Invenstera");
                        input = Console.ReadLine();
                        switch (input)
                        {
                            case "1":

                                if (personalCreated == true)
                                {
                                    Console.WriteLine("Var vänlig skriv in ditt kontonummer");
                                    string account = Console.ReadLine();

                                    if (account == personalAccount.getAccountNum())
                                    {
                                        while (transactionRunning)
                                        {
                                            Console.WriteLine("Vad för konto skulle nå?");
                                            Console.WriteLine("1: Insättning");
                                            Console.WriteLine("2: Uttagning");
                                            Console.WriteLine("3: Överför");
                                            Console.WriteLine("4: Tillbaka");
                                            input = Console.ReadLine();
                                            switch (input)
                                            {
                                                case "1":
                                                    Console.WriteLine("Hur mycket vill du sätta in?");

                                                    string addValue = Console.ReadLine();
                                                    try
                                                    {
                                                        int result = Int32.Parse(addValue);
                                                        personalAccount.addMoney(result);

                                                        Console.WriteLine($"Du har nu satt in {result} och har {personalAccount.getBalance()} på kontot");
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
                                                      

                                                        if (result >= personalAccount.getBalance())
                                                        {
                                                            personalAccount.removeMoney(result);
                                                            Console.WriteLine($"Du har nu tagit ut {result} och har {personalAccount.getBalance()} på kontot");

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
                                                    Console.WriteLine("1: Sparkonto");
                                                    Console.WriteLine("2: Invenstera");
                                                    Console.WriteLine("2: Tillbaka");
                                                    input = Console.ReadLine();
                                                    switch (input)
                                                    {

                                                        case "1":
                                                            if (savingsCreated == true)
                                                            {
                                                                Console.WriteLine("Var vänlig skriv in ditt kontonummer");
                                                                account = Console.ReadLine();

                                                                if (account == savingsAccount.getAccountNum())
                                                                {

                                                                    Console.WriteLine("Hur mycket vill du ta ut?");

                                                                    string transfer = Console.ReadLine();
                                                                    try
                                                                    {
                                                                        int result = Int32.Parse(transfer);

                                                                        if (result >= personalAccount.getBalance())
                                                                        {
                                                                            savingsAccount.addMoney(result);
                                                                            personalAccount.removeMoney(result);

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
                                                                Console.WriteLine("Inget sådant konto finns just nu");
                                                            }
                                                            break;


                                                        case "2":
                                                            if (InvestmentCreated == true)
                                                            {
                                                                Console.WriteLine("Var vänlig skriv in kontonummret till personen som du vill skicka till");
                                                                account = Console.ReadLine();

                                                                if (account == investmentAccount.getAccountNum())
                                                                {

                                                                    Console.WriteLine("Hur mycket vill du ta ut?");

                                                                    string transfer = Console.ReadLine();
                                                                    try
                                                                    {
                                                                        int result = Int32.Parse(transfer);

                                                                        if (result >= personalAccount.getBalance())
                                                                        {
                                                                            investmentAccount.addMoney(result);
                                                                            personalAccount.removeMoney(result);

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
                                                                Console.WriteLine("Inget sådant konto finns just nu");
                                                            }
                                                        break;

                                                        case "3":
                                                         break;

                                                    }

                                                    break;

                                                case "4":
                                                    transactionRunning = false;
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
                                    Console.WriteLine("Inget sådant konto finns just nu");
                                }
                                break;




                            case "2":

                                if (savingsCreated == true)
                                {
                                    Console.WriteLine("Var vänlig skriv in ditt kontonummer");
                                    string account = Console.ReadLine();

                                    if (account == savingsAccount.getAccountNum())
                                    {
                                        while (transactionRunning)
                                        {
                                            Console.WriteLine("Vad för konto skulle nå?");
                                            Console.WriteLine("1: Insättning");
                                            Console.WriteLine("2: Uttagning");
                                            Console.WriteLine("3: Överför");
                                            Console.WriteLine("4: Tillbaka");
                                            input = Console.ReadLine();
                                            switch (input)
                                            {
                                                case "1":
                                                    Console.WriteLine("Hur mycket vill du sätta in?");

                                                    string addValue = Console.ReadLine();
                                                    try
                                                    {
                                                        int result = Int32.Parse(addValue);
                                                        savingsAccount.addMoney(result);

                                                        Console.WriteLine($"Du har nu satt in {result} och har {savingsAccount.getBalance()} på kontot");
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
                                              

                                                        if (result >= savingsAccount.getBalance())
                                                        {
                                                            savingsAccount.removeMoney(result);
                                                            Console.WriteLine($"Du har nu tagit ut {result} och har {savingsAccount.getBalance()} på kontot");

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
                                                    Console.WriteLine("1: Personkonto");
                                                    Console.WriteLine("2: Invenstera");
                                                    Console.WriteLine("2: Tillbaka");
                                                    input = Console.ReadLine();
                                                    switch (input)
                                                    {

                                                        case "1":
                                                            if (personalCreated == true)
                                                            {
                                                                Console.WriteLine("Var vänlig skriv in ditt kontonummer");
                                                                account = Console.ReadLine();

                                                                if (account == personalAccount.getAccountNum())
                                                                {

                                                                    Console.WriteLine("Hur mycket vill du ta ut?");

                                                                    string transfer = Console.ReadLine();
                                                                    try
                                                                    {
                                                                        int result = Int32.Parse(transfer);

                                                                        if (result >= savingsAccount.getBalance())
                                                                        {
                                                                            savingsAccount.addMoney(result);
                                                                            personalAccount.removeMoney(result);

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
                                                                Console.WriteLine("Inget sådant konto finns just nu");
                                                            }
                                                            break;


                                                        case "2":
                                                            if (InvestmentCreated == true)
                                                            {
                                                                Console.WriteLine("Var vänlig skriv in kontonummret till personen som du vill skicka till");
                                                                account = Console.ReadLine();

                                                                if (account == investmentAccount.getAccountNum())
                                                                {

                                                                    Console.WriteLine("Hur mycket vill du ta ut?");

                                                                    string transfer = Console.ReadLine();
                                                                    try
                                                                    {
                                                                        int result = Int32.Parse(transfer);

                                                                        if (result >= savingsAccount.getBalance())
                                                                        {
                                                                            investmentAccount.addMoney(result);
                                                                            savingsAccount.removeMoney(result);

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
                                                                Console.WriteLine("Inget sådant konto finns just nu");
                                                            }
                                                            break;

                                                        case "3":
                                                            break;

                                                    }

                                                    break;

                                                case "4":
                                                    transactionRunning = false;
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
                                    Console.WriteLine("Inget sådant konto finns just nu");
                                }
                                break;




                            case "3":

                                if (InvestmentCreated == true)
                                {
                                    Console.WriteLine("Var vänlig skriv in ditt kontonummer");
                                    string account = Console.ReadLine();

                                    if (account == investmentAccount.getAccountNum())
                                    {
                                        while (transactionRunning)
                                        {
                                            Console.WriteLine("Vad för konto skulle nå?");
                                            Console.WriteLine("1: Insättning");
                                            Console.WriteLine("2: Uttagning");
                                            Console.WriteLine("3: Överför");
                                            Console.WriteLine("4: Tillbaka");
                                            input = Console.ReadLine();
                                            switch (input)
                                            {
                                                case "1":
                                                    Console.WriteLine("Hur mycket vill du sätta in?");

                                                    string addValue = Console.ReadLine();
                                                    try
                                                    {
                                                        int result = Int32.Parse(addValue);
                                                        investmentAccount.addMoney(result);

                                                        Console.WriteLine($"Du har nu satt in {result} och har {investmentAccount.getBalance()} på kontot");
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
                

                                                        if (result >= investmentAccount.getBalance())
                                                        {
                                                            investmentAccount.removeMoney(result);
                                                            Console.WriteLine($"Du har nu tagit ut {result} och har {investmentAccount.getBalance()} på kontot");

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
                                                    Console.WriteLine("1: Personkonto");
                                                    Console.WriteLine("2: Sparkonto");
                                                    Console.WriteLine("2: Tillbaka");
                                                    input = Console.ReadLine();
                                                    switch (input)
                                                    {

                                                        case "1":
                                                            if (personalCreated == true)
                                                            {
                                                                Console.WriteLine("Var vänlig skriv in ditt kontonummer");
                                                                account = Console.ReadLine();

                                                                if (account == personalAccount.getAccountNum())
                                                                {

                                                                    Console.WriteLine("Hur mycket vill du ta ut?");

                                                                    string transfer = Console.ReadLine();
                                                                    try
                                                                    {
                                                                        int result = Int32.Parse(transfer);

                                                                        if (result >= investmentAccount.getBalance())
                                                                        {
                                                                            personalAccount.addMoney(result);
                                                                            investmentAccount.removeMoney(result);

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
                                                                Console.WriteLine("Inget sådant konto finns just nu");
                                                            }
                                                            break;


                                                        case "2":
                                                            if (savingsCreated == true)
                                                            {
                                                                Console.WriteLine("Var vänlig skriv in kontonummret till personen som du vill skicka till");
                                                                account = Console.ReadLine();

                                                                if (account == savingsAccount.getAccountNum())
                                                                {

                                                                    Console.WriteLine("Hur mycket vill du ta ut?");

                                                                    string transfer = Console.ReadLine();
                                                                    try
                                                                    {
                                                                        int result = Int32.Parse(transfer);

                                                                        if (result >= investmentAccount.getBalance())
                                                                        {
                                                                            savingsAccount.addMoney(result);
                                                                            investmentAccount.removeMoney(result);

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
                                                                Console.WriteLine("Inget sådant konto finns just nu");
                                                            }
                                                            break;

                                                        case "3":
                                                            break;

                                                    }

                                                    break;

                                                case "4":
                                                    transactionRunning = false;
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
                                    Console.WriteLine("Inget sådant konto finns just nu");
                                }
                                break;

                        }
                        break;

                    case "3":


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
                                    Console.WriteLine("Var vänlig skriv in ditt kontonummer");
                                    string account = Console.ReadLine();

                                    if (account == personalAccount.getAccountNum())
                                    {
                                        Console.WriteLine($"Du har {personalAccount.getBalance()}");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Inget konto hittades");
                                    }

                                }
                                else
                                {
                                    Console.WriteLine("Inget sådant konto finns just nu");
                                }
                                break;

                            case "2":
                                if (savingsCreated == true)
                                {
                                    Console.WriteLine("Var vänlig skriv in ditt kontonummer");
                                    string account = Console.ReadLine();

                                    if (account == savingsAccount.getAccountNum())
                                    {
                                        Console.WriteLine($"Du har {savingsAccount.getBalance()}");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Inget konto hittades");
                                    }

                                }
                                else
                                {
                                    Console.WriteLine("Inget sådant konto finns just nu");
                                }
                                break;

                            case "3":
                                if (InvestmentCreated == true)
                                {
                                    Console.WriteLine("Var vänlig skriv in ditt kontonummer");
                                    string account = Console.ReadLine();

                                    if (account == investmentAccount.getAccountNum())
                                    {
                                        Console.WriteLine($"Du har {investmentAccount.getBalance()}");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Inget konto hittades");
                                    }

                                }
                                else
                                {
                                    Console.WriteLine("Inget sådant konto finns just nu");
                                }
                                break;


                            case "4":
                                break;

                        }


                        break;


                    case "4":
                        running = false;
                        break;

                }

            };
        }
    }
}
