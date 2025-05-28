// CSC360_Final/ConcreteClasses/CardState.cs
using CSC360_Final.Interfaces;

namespace CSC360_Final.ConcreteClasses
{
    public class CardState : IState
    {
        private readonly FlyweightFactory _fwFactory;
        private readonly ConcreteFactory _prodFactory = new();

        public CardState(FlyweightFactory fwFactory) => _fwFactory = fwFactory;
        public void SetContext(object ctx) { }

        public IProduct Handle(string key, params object[] extrinsic)
        {
            var suit = (string)extrinsic[0];

            // flyweight keyed only on card name
            var fw = (ConcreteFlyweight)_fwFactory.Create(key);

            // pass suit to your product as extrinsic
            return _prodFactory.Create(key, fw, suit);
        }
    }
}
