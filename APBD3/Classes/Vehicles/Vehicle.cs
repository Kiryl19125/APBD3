namespace APBD3.Classes;

public abstract class Vehicle
{
    public List<Container> _containers { get; set; }
    public int _containerCapacity { get; set; }
    public int _containerCount { get; set; }
    public double _maxLoad { get; set; }
    public double _currentLoad { get; set; }

    public Vehicle(int containerCapacity, double maxLoad)
    {
        _containers = new List<Container>();
        _containerCapacity = containerCapacity;
        _containerCount = 0;
        _maxLoad = maxLoad;
        _currentLoad = 0;
    }

    public abstract void LoadContainers(List<Container> containers);
    public abstract void LoadContainer(Container container);
    
    public override string ToString()
    {
        return $"Vehicle: Capacity = {_containerCapacity}, Max Load = {_maxLoad}, Current Load = {_currentLoad}, Container Count = {_containerCount}";
    }
}