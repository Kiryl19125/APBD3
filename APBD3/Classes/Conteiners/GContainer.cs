using APBD3.Classes.Products;
using APBD3.Exceptions;
using APBD3.Interfaces;

namespace APBD3.Classes;

public class GContainer : Container, IHazardNotifier
{
    public double _preasure { get; set; }

    public GContainer(double selfWeight, double height, double depth, double maxLoad, double preasure) : base(
        selfWeight, height, depth,
        maxLoad)
    {
        _serialNumber = "KON-G-" + ID;
        _preasure = preasure;
    }

    public override void load(Product product)
    {
        if (product._ProductType != ProductType.GAZ)
        {
            throw new InvalidProductException();
        }

        if (_loadWeight + product._weight > _maxLoad)
        {
            throw new OverfillException();
        }

        _loadWeight += product._weight;
    }

    public override void unload()
    {
        Console.WriteLine("Unloading container: " + _serialNumber);
        _loadWeight *= 0.05;
    }

    public void notifyWarning()
    {
        Console.Error.WriteLine("unsafe container incident: " + _serialNumber);
    }
}