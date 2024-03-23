namespace APBD3.Classes.Products;

public class ProductTemperatureMap
{
    public static Dictionary<ProductName, double> productTemperatureMap = new Dictionary<ProductName, double>()
    {
        { ProductName.BANANAS, 13.3 },
        { ProductName.CHOCOLATE, 18 },
        { ProductName.FISH, 2 },
        { ProductName.MEAT, -15 },
        { ProductName.ICE_CREAME, -18 },
        { ProductName.FROZEN_PIZZA, -30 },
        { ProductName.CHEESE, 7.2 },
        { ProductName.SAUSAGES, 5 },
        { ProductName.BUTTER, 20.5 },
        { ProductName.EGGS, 19 }
    };
}