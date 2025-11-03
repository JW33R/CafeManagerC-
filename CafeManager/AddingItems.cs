

namespace CafeManager
{
    internal class AddingItems
    {
        public static void AddItem()
        {
            List<string> Items = new List<string>();
            List<string> Price = new List<string>();
            List<string> Quanity = new List<string>();
            string Decision1 = "";
            string Decision2 = "";
            string Decision3 = "";
            while (Decision1.ToUpper() != "DONE")
            {
                Console.WriteLine("Which item would you like to Add? Type \"Done\" when finsihed.");
                Decision1 = Console.ReadLine();
                if (Decision1.ToUpper() == "DONE")
                {
                    goto EndLoop;
                }
                if (Decision1.TrimStart() == "")
                {
                    Console.WriteLine("You can't do that.");
                    AddItem();
                }
                Console.WriteLine("What is the Price?");
                double ConvertDecision2 = Convert.ToDouble(Decision1 = Console.ReadLine());
                if (Decision2.TrimStart() == " ")
                {
                    Console.WriteLine("You can't do that.");
                    AddItem();
                }
                Console.WriteLine("How Many?");
                int ConvertDecision3 = Convert.ToInt32(Decision3 = Console.ReadLine());
                if (Decision3.TrimStart() == "")
                {
                    Console.WriteLine("You can't do that.");
                    AddItem();
                }
                Items.Add(Decision1);
                Price.Add(Decision2);
                Quanity.Add(Decision3);
                foreach (var num in Items)
                {
                    Console.WriteLine($"You added {Items} || {Price} || {Quanity}");
                }
            }
        EndLoop:
            Console.WriteLine("");
            
            






        }        
    }
}
