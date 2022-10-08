using System;
using System.Collections.Generic;
using System.Linq;

public class cardHolder
{
    String cardNum;
    int pin;
    String firstName;
    String lastName;
    double balance;

    public cardHolder(string cardNum, int pin, string firstname, string lastname, double balance)
    {
        this.cardNum = cardNum;
        this.pin = pin;
        this.firstName = firstname;
        this.lastName = lastname;
        this.balance = balance;
    }

    public String getNum()
    {
        return cardNum;
    }
    public int getPin()
    {
        return pin;
    }

   public String getfirstName()
    {
     return firstName;
    }

    public String getlastName()
    {
        return lastName;
    }
    public double getBalance()
    {
        return balance;
    }

    public void setNum(String newCardNum)
    {
        cardNum = newCardNum;
    }
    public void setPin(int newPin)
    {
        pin = newPin;
    }
    public void setFirstname(String newFirstName)
    {
        firstName = newFirstName;
    }

    public void setLastname(String newLastname)
    {
        lastName = newLastname;
    }

    public void setBalance(double newBalance)
    {
        balance = newBalance;
    }

    public static void Main(String[] args)
    {
        void printOptions()
        {
            Console.WriteLine("Please choose from one of the following options ...");
            Console.WriteLine("1.Deposit");
            Console.WriteLine("2.Withdraw");
            Console.WriteLine("3.Show Balance");
            Console.WriteLine("4.Exit");
        }

        void deposit(cardHolder currentUser)
        {
            Console.WriteLine("How much $$ would you like to deposit");
            double deposit = Double.Parse(Console.ReadLine());
            currentUser.setBalance(deposit);
            Console.WriteLine("Thank you for your $$. Your new balance is:" + currentUser.getBalance());

        }

        void withdraw(cardHolder currentUser)
        {
            Console.WriteLine("How much $$ would you like to withdraw");
            double withdrawal = Double.Parse(Console.ReadLine());
            //Check if the user has enough money

            if (currentUser.getBalance()>withdrawal)
            {
                Console.WriteLine("Insufficient balance");
            }
            else
            {               
                currentUser.setBalance( currentUser.getBalance() - withdrawal);
                Console.WriteLine("You're good to go! Thank you:)");
            }
        }

        void balance (cardHolder currentUser)
        {
            Console.WriteLine("Current balance:" + currentUser.getBalance());
        }

        List<cardHolder> cardHolders = new List<cardHolder>();
        cardHolders.Add(new cardHolder("4532772818527395", 1234,"John", "Griffith", 150.31));
        cardHolders.Add(new cardHolder("4533928736729384", 4321, "Ashley", "Jones", 321.13));
        cardHolders.Add(new cardHolder("17824261321488t4", 9999, "Frida", "Dickerson", 105.59));
        cardHolders.Add(new cardHolder("9237478324621392", 2468, "Muneeb", "Harding", 851.84));
        cardHolders.Add(new cardHolder("2834362648272104", 4826, "Dawn", "smith", 54.27));

        Console.WriteLine("Welcome to SimpleAtm");
        Console.WriteLine("Please insert your debit card:");
        String debitCardNum = "";
        cardHolder currentUser;

        while (true)
        {
            try
            {
                debitCardNum =   Console.ReadLine();
                currentUser=cardHolders.FirstOrDefault(a=>a.cardNum == debitCardNum);
                if (currentUser == null) { break; } 
                else { Console.WriteLine("Card not recognized.Please try again"); }
            }
            catch  { Console.WriteLine("Card not recognized.Please try again"); }
        }

        Console.WriteLine("Please enter your pin");
        int userPin = 0;

        while (true)
        {
            try
            {
                userPin = int.Parse (Console.ReadLine());
                if (currentUser.getPin() == userPin) { break; }
                else { Console.WriteLine("Incorrect pin. Please try again."); }
            }
            catch { Console.WriteLine("Incorrect pin. Please try again."); }
        }

        Console.WriteLine("Welcome" + currentUser.getfirstName()+":)");
        int option = 0;
        do
        {
            printOptions();
            try
            {
              option = int.Parse (Console.ReadLine());
            }
            catch  { }
            if(option == 1) { deposit(currentUser); }
            else if (option == 2) { withdraw(currentUser); }
            else if (option == 3) { balance(currentUser); }
            else if (option==4) { break; }
            else { option = 0; }
        }
        while (option !=4);
        Console.WriteLine("Thank you! Have a nice day:)");
    }



}