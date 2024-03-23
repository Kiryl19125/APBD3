using APBD3.Classes.Products;
using APBD3.Interfaces;

namespace APBD3.Classes;

public abstract class Container
{
    protected static int ID = 0;

    public double _loadWeight { get; set; }
    public double _selfWeight { get; set; }
    public double _height { get; set; }
    public double _depth { get; set; }
    public double _maxLoad { get; set; }
    public string _serialNumber { get; set; }

    public Container(double selfWeight, double height, double depth, double maxLoad)
    {
        _loadWeight = 0;
        _selfWeight = selfWeight;
        _height = height;
        _depth = depth;
        _maxLoad = maxLoad;
        ID++;
    }

    public abstract void load(Product product);

    public abstract void unload();
    
    public override string ToString()
    {
        return $"Container - Serial Number: {_serialNumber}, Load Weight: {_loadWeight}, Self Weight: {_selfWeight}, Height: {_height}, Depth: {_depth}, Max Load: {_maxLoad}";
    }
}