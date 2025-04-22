using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_Final
{
    public class HeroPlayer
    {
        public string PlayerName;
        public int Pow = 7;
        public int Speed = 6;
        public int Smarts = 5;
        public int HP = 20;

        public Queue<string> Bag = new Queue<string>();
        public Stack<string> Loot = new Stack<string>();

        public HeroPlayer(string name)
        {
            PlayerName = name;
            Bag.Enqueue("Sword");
            Bag.Enqueue("Health Potion");
        }

        public void GrabItem(string item)
        {
            if (Bag.Count >= 5) Bag.Dequeue();
            Bag.Enqueue(item);
        }

        public void GrabLoot(string loot)
        {
            Loot.Push(loot);
        }

        public void ShowStats()
        {
            Console.WriteLine("=========================");
            Console.WriteLine($"Name: {PlayerName}");
            Console.WriteLine($"Power: {Pow}");
            Console.WriteLine($"Speed: {Speed}");
            Console.WriteLine($"Smarts: {Smarts}");
            Console.WriteLine($"HP: {HP}");
            Console.WriteLine("Bag: " + string.Join(", ", Bag));
            Console.WriteLine("=========================");
        }

    }
}
