// CSC360_Final/ConcreteClasses/ConcreteFactory.cs
using CSC360_Final.Interfaces;
using System;

namespace CSC360_Final.ConcreteClasses
{
    public class ConcreteFactory : IFactory<IProduct>
    {
        public IProduct Create(string _, params object[] args)
        {
            var fw = (ConcreteFlyweight)args[0];

            // Character: args[1] is attack
            if (fw.BaseHealth > 0 && args.Length == 2 && args[1] is int atk)
                return new ConcreteProduct(fw, atk);

            // Card:      args[1] is suit
            if (fw.CardValue > 0 && args.Length == 2 && args[1] is string suit)
                return new ConcreteProduct(fw, suit);

            throw new ArgumentException("Invalid args to create product");
        }
    }
}
