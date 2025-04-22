using Algorithm_Final;
using System;
using System.Collections.Generic;


static void Main()
{
    Console.WriteLine("Welcome to Hero’s Quest!");
    Console.Write("Enter your name: ");
    string playerName = Console.ReadLine();

    HeroPlayer myHero = new HeroPlayer(playerName);

    Console.WriteLine($"\n{playerName}, get ready for the adventure!");
    myHero.ShowStats();

    DungeonMap gameMap = new DungeonMap();
    ChallengeBST challengeSystem = new ChallengeBST();

    foreach (int lvl in new int[] { 5, 8, 3, 12, 15, 1, 10, 18, 6, 14 })
    {
        challengeSystem.Insert(lvl);
    }

    Console.WriteLine("\nPress Enter to start exploring...");
    Console.ReadLine();

    gameMap.Run(myHero, challengeSystem);

    Console.WriteLine("\nEnd of Quest. Press Enter to close.");
    Console.ReadLine();
}
