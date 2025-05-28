using CSC360_Final.Interfaces;
namespace CSC360_Final.ConcreteClasses
{
    public class Context
    {
        private readonly List<IProduct> _created = new();
        public IState? CurrentState { get; set; }
        public void Request(string key, params object[] extrinsic)
        {
            if (CurrentState == null) throw new InvalidOperationException("State not set");
            var prod = CurrentState.Handle(key, extrinsic);
            _created.Add(prod);
        }

        public void PrintAll()
        {
            Console.WriteLine("\n=== All Created Objects ===");
            _created.ForEach(p => p.PrintInfo());
        }
    }
}