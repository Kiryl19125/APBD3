using APBD3.Classes.Products;
using APBD3.Exceptions;
using APBD3.Interfaces;

namespace APBD3.Classes;

public class CContainer : Container, IHazardNotifier
{
    public double _temperature { get; set; }

    public ProductName _productName { get; set; }

    public CContainer(double selfWeight, double height, double depth, double maxLoad,
        ProductName productName) : base(selfWeight, height, depth, maxLoad)
    {
        _serialNumber = "KON-C-" + ID;
        _temperature = ProductTemperatureMap.productTemperatureMap[productName];
        _productName = productName;
    }

    public override void load(Product product)
    {
        if (product._ProductType != ProductType.SOLID || product._ProductSafety != ProductSafety.SAFE)
        {
            throw new InvalidProductException();
        }

        Console.WriteLine("Loading container: " + _serialNumber);

        if (product._weight + _loadWeight > _maxLoad)
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