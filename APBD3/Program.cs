using APBD3.Classes;
using APBD3.Classes.Products;

Console.WriteLine("Hello");

LContainer lContainer = new LContainer(0.1, 2, 3000, 2);
GContainer gContainer = new GContainer(0.3, 1.5, 3000, 1, 200);
CContainer cContainer = new CContainer(0.08, 3, 4000, 4, ProductName.BANANAS);

Ship ship = new Ship(5, 12);
ship.LoadContainer(lContainer);
ship.LoadContainer(gContainer);
ship.LoadContainer(cContainer);


List<Container> containers = new List<Container>();
for (int i = 0; i < 12; i++)
{
    containers.Add(new CContainer(0.03, 3, 5000, 6, ProductName.EGGS));
    containers.Add(new GContainer(0.4, 2, 3500, 2, 300));
    containers.Add(new LContainer(0.1, 2.3, 4000, 3));
}

Ship ship2 = new Ship(50, 200);
ship2.LoadContainers(containers);

ship.ShowContainers();

ship2.ShowContainers();

ship.ReplaceContainer("KON-L-1", new CContainer(0.03, 3, 5000, 6, ProductName.MEAT));

ship.MoveContainerToAnotherVehicle("KON-G-2", ship2);
