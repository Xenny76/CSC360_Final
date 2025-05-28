// CSC360_Final/ConcreteClasses/ConcreteFlyweight.cs
using CSC360_Final.Interfaces;

namespace CSC360_Final.ConcreteClasses
{
    public class ConcreteFlyweight : IFlyweight
    {
        public string Key { get; }
        public int BaseHealth { get; }     // >0 for characters
        public int CardValue { get; }      // >0 for cards

        public ConcreteFlyweight(string key, int baseHealth = 0, int cardValue = 0)
        {
            Key = key;
            BaseHealth = baseHealth;
            CardValue = cardValue;
        }
    }
}
