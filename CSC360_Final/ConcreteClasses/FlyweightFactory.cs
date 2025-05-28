// CSC360_Final/ConcreteClasses/FlyweightFactory.cs
using CSC360_Final.Interfaces;
using System;
using System.Collections.Generic;

namespace CSC360_Final.ConcreteClasses
{
    public class FlyweightFactory : IFactory<IFlyweight>
    {
        // now instance-level so we can mutate at runtime:
        private readonly Dictionary<string, int> _healthByName;

        // cards still use a static lookup
        private static readonly Dictionary<string, int> _cardValueByName = new()
        {
            ["Ace"] = 1,
            ["2"] = 2,
            ["3"] = 3,
            ["4"] = 4,
            ["5"] = 5,
            ["6"] = 6,
            ["7"] = 7,
            ["8"] = 8,
            ["9"] = 9,
            ["10"] = 10,
            ["Jack"] = 11,
            ["Queen"] = 12,
            ["King"] = 13
        };

        private readonly Dictionary<string, IFlyweight> _pool = new();

        public FlyweightFactory()
        {
            // seed with your defaults:
            _healthByName = new Dictionary<string, int>
            {
                ["Warrior"] = 100,
                ["Mage"] = 80,
                ["Archer"] = 60
            };
        }

        /// <summary>
        /// Call Create("Warrior") or Create("Ace") — suit/extrinsics handled by your IState/Product.
        /// </summary>
        public IFlyweight Create(string key, params object[] _)
        {
            if (_pool.TryGetValue(key, out var existing))
                return existing;

            IFlyweight fw;
            if (_healthByName.TryGetValue(key, out var hp))
            {
                // new character type
                fw = new ConcreteFlyweight(key, baseHealth: hp);
            }
            else if (_cardValueByName.TryGetValue(key, out var cv))
            {
                // new card type
                fw = new ConcreteFlyweight(key, cardValue: cv);
            }
            else
            {
                // fallback: unknown
                fw = new ConcreteFlyweight(key);
                // you could choose to treat unknown as character—up to you
            }

            _pool[key] = fw;
            return fw;
        }

        public IReadOnlyCollection<IFlyweight> Flyweights => _pool.Values;

        // helpers for your Program.cs logic:
        public bool HasCharacter(string key) => _healthByName.ContainsKey(key);

        public void RegisterCharacter(string key, int baseHealth)
        {
            _healthByName[key] = baseHealth;
            // if someone already created instances, you might want to update them—but typically you
            // only register *before* any Create(key) calls for that key.
        }
    }
}
