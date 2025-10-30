
using System.ComponentModel.Design;

namespace CafeManager
{
    internal class Menu
    {

        public void MenuSelection()
        {
            Console.WriteLine("1. Add Item\n2. Remove Item\n3. View Cart\n4. Checkout\n5. Quit");
            var MenuNumber = Console.ReadLine();

            switch (MenuNumber)
            {
                case "1":
                        AddingItems.AddItem();
                        break;
                case "2":
                        RemovingItems.RemoveItems();
                        break;
                case "3":
                        //ViewCart();
                        break;
                case "4":
                        //CheckOut();
                        break;
                default:
                        Console.WriteLine("Goodbye...");
                        break;
            }
        }
        

    }
    
}
