using APBD3.Classes.Products;
using APBD3.Exceptions;
using APBD3.Interfaces;

namespace APBD3.Classes;

public class LContainer : Container, IHazardNotifier
{
    public LContainer(double selfWeight, double height, double depth, double maxLoad) : base(selfWeight, height, depth,
        maxLoad)
    {
        _serialNumber = "KON-L-" + ID;
    }

    public override void load(Product product)
    {
        if (product._ProductType != ProductType.LIQUID)
        {
            throw new InvalidProductException(message: new string(product._name + " is not LIQUID"));
        }

        Console.WriteLine("Loading container: " + _serialNumber);

        if (product._ProductSafety == ProductSafety.UNSAFE)
        {
            if (product._weight + _loadWeight > 0.5 * _maxLoad)
            {
                notifyWarning();
                return;
            }
        }
        else if (product._weight + _loadWeight > 0.9 * _maxLoad)
        {
            notifyWarning();
            return;
        }

        _loadWeight += product._weight;
    }

    public override void unload()
    {
        Console.WriteLine("Unloading container: " + _serialNumber);
        _loadWeight = 0;
    }

    public void notifyWarning()
    {
        Console.Error.WriteLine("unsafe container incident: " + _serialNumber);
    }
}