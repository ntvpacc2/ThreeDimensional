namespace Model
{
    public interface IThreeDimensional
    {
        string Name { get; }
        double Volume { get; }
        string ToString();
    }
}
