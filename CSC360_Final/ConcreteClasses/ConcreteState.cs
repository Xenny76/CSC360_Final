using CSC360_Final.ConcreteClasses;
using CSC360_Final.Interfaces;
public class CharacterState : IState
{
    private readonly FlyweightFactory _fwF;
    private readonly ConcreteFactory _prodF = new();

    public CharacterState(FlyweightFactory fwFactory) => _fwF = fwFactory;
    public void SetContext(object c) { }

    public IProduct Handle(string key, params object[] extrinsic)
    {
        // extrinsic[0] = attack
        var attack = (int)extrinsic[0];
        var fw = (ConcreteFlyweight)_fwF.Create(key);
        return _prodF.Create(key, fw, attack);
    }
}