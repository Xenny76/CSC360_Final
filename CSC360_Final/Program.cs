// CSC360_Final/Program.cs
using System;
using CSC360_Final.ConcreteClasses;

namespace CSC360_Final
{
    class Program
    {
        static void Main()
        {
            var fwFactory = new FlyweightFactory();
            var characterState = new CharacterState(fwFactory);
            var cardState = new CardState(fwFactory);
            var context = new Context();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("1) Create Character");
                Console.WriteLine("2) Create Card");
                Console.WriteLine("3) List Flyweights");
                Console.WriteLine("4) Print Objects");
                Console.WriteLine("5) Exit");
                Console.Write("Choice: ");
                var choice = Console.ReadLine();

                if (choice == "5") break;

                switch (choice)
                {
                    case "1":
                        // 1. prompt for class name
                        Console.Write("  Character Name: ");
                        var cname = Console.ReadLine()!;

                        // 2. if brand-new, ask for base health
                        if (!fwFactory.HasCharacter(cname))
                        {
                            Console.Write($"  New class—enter standard Health for '{cname}': ");
                            var stdHp = int.Parse(Console.ReadLine()!);
                            fwFactory.RegisterCharacter(cname, stdHp);
                        }

                        // 3. now just ask attack (extrinsic)
                        Console.Write("  Attack: ");
                        var attack = int.Parse(Console.ReadLine()!);

                        context.CurrentState = characterState;
                        context.Request(cname, attack);
                        break;

                    case "2":
                        // suit is still extrinsic; value comes from the flyweight lookup
                        Console.Write("  Card Name (e.g. Ace, 7, King): ");
                        var cardName = Console.ReadLine()!;
                        Console.Write("  Suit: ");
                        var suit = Console.ReadLine()!;

                        context.CurrentState = cardState;
                        context.Request(cardName, suit);
                        break;

                    case "3":
                        Console.WriteLine("\n-- Flyweight Pool --");
                        foreach (ConcreteFlyweight fw in fwFactory.Flyweights)
                        {
                            Console.WriteLine(
                              fw.BaseHealth > 0
                                ? $"[Character] {fw.Key}, Health={fw.BaseHealth}"
                                : $"[Card]      {fw.Key}, Value={fw.CardValue}"
                            );
                        }
                        Console.WriteLine("Press Enter to continue…");
                        Console.ReadLine();
                        break;

                    case "4":
                        Console.WriteLine("\n-- Created Objects --");
                        context.PrintAll();
                        Console.WriteLine("Press Enter to continue…");
                        Console.ReadLine();
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Press Enter…");
                        Console.ReadLine();
                        break;
                }
            }
        }
    }
}
