using System.Collections.Generic;


public class BagCell
{
    public Prop prop;


}

public class Bag
{
    public List<BagCell> CellList = new List<BagCell>();
    public static Bag Instance;

    public Bag()
    {
        Instance = this;
    }

    public void NewCell()
    {
        BagCell cell = new BagCell();
        CellList.Add(cell);
    }
    public void AddProp(string name)
    {
        Prop prop = new Prop();
        prop.Name = name;

    }

    //public BagCell FindBagCell()
    //{

    //}
}

