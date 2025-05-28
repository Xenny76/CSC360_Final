// CSC360_Final/ConcreteClasses/ConcreteProduct.cs
using CSC360_Final.Interfaces;
using System;

namespace CSC360_Final.ConcreteClasses
{
    public class ConcreteProduct : IProduct
    {
        private readonly ConcreteFlyweight _fw;
        private readonly int? _attack;
        private readonly string? _suit;

        // Character ctor
        public ConcreteProduct(ConcreteFlyweight fw, int attack)
        {
            _fw = fw;
            _attack = attack;
        }

        // Card ctor
        public ConcreteProduct(ConcreteFlyweight fw, string suit)
        {
            _fw = fw;
            _suit = suit;
        }

        public void PrintInfo()
        {
            if (_fw.BaseHealth > 0)
            {
                Console.WriteLine(
                  $"[Character] {_fw.Key}, Health={_fw.BaseHealth}, Attack={_attack}");
            }
            else
            {
                Console.WriteLine(
                  $"[Card] {_fw.Key} of {_suit}, Value={_fw.CardValue}");
            }
        }
    }
}
