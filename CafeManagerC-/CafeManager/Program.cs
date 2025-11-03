using System.Security.Cryptography.X509Certificates;

namespace CafeManager
{
    internal class Program
    {

        static void Main(string[] args)
        {
            MenuSelection();
        }
        public static List<string> Items = new List<string>();
        public static List<decimal> Price = new List<decimal>();
        public static List<int> Quanity = new List<int>();
        static void AddItem()
        {
            ClearScreen();
            string Decision1 = "";
            string Decision2 = "";
            string Decision3 = "";
            while (Decision1.ToUpper() != "DONE")
            {
                Console.WriteLine("Which item would you like to Add? Type \"Done\" when finsihed.");
                Decision1 = Console.ReadLine();
                if (Decision1.ToUpper() == "DONE")
                {
                    break;
                }
                if (string.IsNullOrWhiteSpace(Decision1))
                {
                    Console.WriteLine("You can't do that.");
                    AddItem();
                }
                Console.WriteLine("What is the Price?");
                Decision2 = Console.ReadLine();
                while (Convert.ToDecimal(Decision2) <= 0)
                {
                    Console.WriteLine("You can't do that.");
                    Console.WriteLine("What is the Price?");
                    Decision2 = Console.ReadLine();
                }
                Console.WriteLine("How Many?");
                Decision3 = Console.ReadLine();
                while (Convert.ToInt32(Decision3) <= 0)
                {
                    Console.WriteLine("You can't do that.");
                    Console.WriteLine("How Many?");
                    Decision3 = Console.ReadLine();
                }
                Items.Add(Decision1);
                Price.Add(Convert.ToDecimal(Decision2));
                Quanity.Add(Convert.ToInt32(Decision3));
                ViewCart();
                ClearScreen();


            }
        }
        static void ViewCart()
        {
            ClearScreen();
            for (int i = 0; i < Items.Count(); i++)
            {
                Console.WriteLine($"Items: {Items[i]} || Price: {Price[i]} || Quanity: {Quanity[i]}");
            }
            PressContinue();
        }
        static void MenuSelection()
        {
            ClearScreen();
            var MenuNumber = "";

            while (MenuNumber != "5")
            {
                ClearScreen();
                Console.WriteLine("1. Add Item\n2. Remove Item\n3. View Cart\n4. Checkout\n5. Quit");
                MenuNumber = Console.ReadLine();

                switch (MenuNumber)
                {
                    case "1":
                        AddItem();
                        break;
                    case "2":
                        RemoveItems();
                        break;
                    case "3":
                        ViewCart();
                        break;
                    case "4":
                        CheckOut();
                        break;
                    default:
                        Console.WriteLine("Goodbye...");
                        break;
                }
            }

        }
        static void RemoveItems()
        {
            ClearScreen();
            for (int i = 0; i < Items.Count(); i++)
            {
                Console.WriteLine($"Items {i + 1}.{Items[i]}.");
            }
            Console.WriteLine("Which Item Would you like to Remove?");
            Console.ReadLine();

        }
        static void ClearScreen()
        {
            Console.Clear();
            Console.WriteLine("----------------------------------");
        }
        static void PressContinue()
        {
            Console.WriteLine("\nPress Enter to Continue...");
            Console.ReadLine();
        }
        static void CheckOut()
        {
            Console.WriteLine("Would you like to use a Discount Code? (Y/N)");
            string decisionForDiscountCode = Console.ReadLine();
            if (decisionForDiscountCode.ToUpper() == "Y")
            {
                Console.WriteLine("What is the code you would like to Enter?");
                string discountCode = Console.ReadLine();
                bool statement = true;
                while (statement)
                {
                    if (discountCode == "STUDENT10")
                    {
                        decimal finalAmountWithDiscount = TotalAmount() - ComputeDiscount() + ComputeTax();
                        statement = false;
                    }
                    else
                    {
                        Console.WriteLine("That code was invalid.");
                        Console.WriteLine("Would you like to try again? (Y/N)");
                        decisionForDiscountCode = Console.ReadLine();
                        if (decisionForDiscountCode.ToUpper() == "N")
                        {
                            statement = false;
                        }
                    }
                }
               
            }
            decimal finalAmountWithOutDiscount = TotalAmount() + ComputeTax();
            Console.WriteLine($"Total Amount: {TotalAmount()} || Tax: {ComputeTax()} || Discount Savings: {ComputeDiscount()} Final Amount: {finalAmountWithDiscount}");
            PressContinue();
        }
        static decimal ComputeTax()
        {
            decimal tax = .095M;
            decimal totalTax = tax * TotalAmount();
            return totalTax = Math.Round(totalTax, 2);
        }
        static decimal TotalAmount()
        {
            decimal theRealTotal = 0;
            for (int i = 0; i < Items.Count(); i++)
            {
                decimal total = Price[i] * Quanity[i];
                theRealTotal = theRealTotal + total;
            }
            return theRealTotal;
        }
        static decimal ComputeDiscount()
        {
            decimal discount = .10M;
            decimal totalDiscount = discount * TotalAmount();
            return totalDiscount;
        }



        
    }
        
        
}
