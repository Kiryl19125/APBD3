using APBD3.Interfaces;

namespace APBD3.Classes;

public class Ship : Vehicle, IHazardNotifier
{
    public Ship(int containerCapacity, double maxLoad) : base(containerCapacity, maxLoad)
    {
    }


    public override void LoadContainers(List<Container> containers)
    {
        if (GetSumWeight(containers) + _currentLoad > _maxLoad)
        {
            notifyWarning();
            return;
        }

        if (containers.Count() + _containerCount > _containerCapacity)
        {
            notifyWarning();
            return;
        }

        foreach (var container in containers)
        {
            _containers.Add(container);
        }

        UpdateContainerInfo();
    }

    public override void LoadContainer(Container container)
    {
        if (container._selfWeight + container._loadWeight + _currentLoad > _maxLoad)
        {
            notifyWarning();
            return;
        }

        if (_containerCount + 1 > _containerCapacity)
        {
            notifyWarning();
            return;
        }

        _containers.Add(container);
        UpdateContainerInfo();
    }

    public Container unloadContainer(string containerNumber)
    {
        foreach (var container in _containers)
        {
            if (container._serialNumber.Equals(containerNumber))
            {
                Container toRturn = container;
                _containers.Remove(container);
                return toRturn;
            }
        }

        UpdateContainerInfo();

        return null;
    }

    public void ReplaceContainer(string toReplace, Container newContainer)
    {
        for (int i = 0; i < _containers.Count(); i++)
        {
            if (_containers[i]._serialNumber.Equals(toReplace))
            {
                _containers.RemoveAt(i);
                _containers.Add(newContainer);
            }
        }
        UpdateContainerInfo();
    }

    public void MoveContainerToAnotherVehicle(string containerNumber, Vehicle vehicle)
    {
        for (int i = 0; i < _containers.Count(); i++)
        {
            if (_containers[i]._serialNumber.Equals(containerNumber))
            {
                Container toReplace = _containers[i];
                _containers.RemoveAt(i);
                vehicle._containers.Add(toReplace);
            }
        }

        UpdateContainerInfo();
    }

    public void ShowContainers()
    {
        foreach (var container in _containers)
        {
            Console.WriteLine(container);
        }
    }

    private double GetSumWeight(List<Container> containers)
    {
        double sum = 0;
        foreach (var container in containers)
        {
            sum += container._loadWeight + container._selfWeight;
        }

        return sum;
    }

    private void UpdateContainerInfo()
    {
        double newWeight = 0;
        foreach (var container in _containers)
        {
            newWeight += container._loadWeight + container._selfWeight;
        }

        _currentLoad = newWeight;
        _containerCount = _containers.Count();
    }

    public void notifyWarning()
    {
        Console.Error.WriteLine("Warning on a ship");
    }
}