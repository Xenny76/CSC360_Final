namespace CSC360_Final.Interfaces
{
    public interface IState
    {
        IProduct Handle(string key, params object[] extrinsic);
        void SetContext(object context);
    }
}