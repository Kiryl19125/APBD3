namespace APBD3.Classes.Products;

public abstract class Product
{
    public string _name { get; }
    public double _weight { get; }

    public ProductType _ProductType { get; }
    public ProductSafety _ProductSafety { get; }

    public Product(string name, double weight)
    {
        _name = name;
        _weight = weight;
        _ProductSafety = ProductSafety.SAFE;
        _ProductType = ProductType.SOLID;
    }

    public Product(string name, double weight, ProductSafety productSafety) : this(name, weight)
    {
        _ProductSafety = productSafety;
        _ProductType = ProductType.SOLID;
    }

    public Product(string name, double weight, ProductSafety productSafety, ProductType productType) : this(name,
        weight, productSafety)
    {
        _ProductType = productType;
    }
}