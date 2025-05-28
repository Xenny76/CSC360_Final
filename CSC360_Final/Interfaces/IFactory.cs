namespace CSC360_Final.Interfaces
{
    public interface IFactory<T>
    {
        T Create(string key, params object[] extrinsic);
    }
}