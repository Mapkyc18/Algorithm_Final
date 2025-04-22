using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_Final
{
    public class DungeonMap
    {
        Dictionary<int, RoomNode> allRooms = new Dictionary<int, RoomNode>();
        Random rng = new Random();
        int finalRoom;

        public DungeonMap()
        {
            for (int r = 1; r <= 15; r++)
            {
                allRooms[r] = new RoomNode(r);
            }
            for (int r = 1; r <= 14; r++)
            {
                allRooms[r].Paths.Add(allRooms[r + 1]);
            }
            finalRoom = 15;
        }

        public void Run(HeroPlayer hero, ChallengeBST challenges)
        {
            Stack<int> route = new Stack<int>();
            int current = 1;
            route.Push(current);

            while (hero.HP > 0 && current != finalRoom)
            {
                Console.Clear();
                Console.WriteLine($"Room {current}... here we go!");

                int lvl = challenges.FindClosest(current);
                if (lvl != -1)
                {
                    Console.WriteLine($"Challenge ahead! Level: {lvl}");
                    if (hero.Pow > lvl || hero.Bag.Contains("Sword"))
                    {
                        Console.WriteLine("You crushed it!");
                        challenges.Delete(lvl);
                    }
                    else
                    {
                        int hit = Math.Abs(hero.Pow - lvl);
                        hero.HP -= hit;
                        Console.WriteLine($"Oof! Lost {hit} HP. Left: {hero.HP}");
                    }
                }

                if (rng.Next(0, 10) == 0)
                {
                    hero.GrabLoot("Gold");
                    Console.WriteLine("Found some shiny Gold!");
                }

                RoomNode here = allRooms[current];
                if (here.Paths.Count > 0)
                {
                    current = here.Paths[0].RoomID;
                    route.Push(current);
                }
                else
                {
                    route.Pop();
                    if (route.Count == 0) break;
                    current = route.Peek();
                }

                Console.WriteLine("\nHit Enter to move on...");
                Console.ReadLine();
            }

            if (hero.HP > 0 && current == finalRoom)
            {
                Console.WriteLine("You made it to the exit! Let’s gooo!");
            }
            else
            {
                Console.WriteLine("Rip... Here's where you ended:");
                foreach (int step in route)
                    Console.WriteLine($"Room {step}");
            }
        }

    }
}
