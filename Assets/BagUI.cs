using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FairyGUI;
using FairyGUI.Utils;

public  class BagUI :GComponent
   {
       public const string url = "ui://vmts0v9ewa2di"; 
    private GList list;
    private GComponent cell;
    public override void ConstructFromXML(XML xml)
       {
           base.ConstructFromXML(xml);
        list = GetChild("list_bag").asList;
        BuildCell();
    }

    public void NewCell()
    {
        cell = UIPackage.CreateObject("test", "Button10").asCom;
        list.AddChild(cell);
        cell.draggable = true;
       cell.onDragStart.Add((EventContext ctx) =>
       {
           DragDropManager.inst.Cancel();
           ctx.PreventDefault();  //阻止格子响应，防止格子被拖拽
           //DragDropManager.inst.StartDrag(cell,cell.icon);
       });

        cell.onDrop.Add((EventContext cxt) =>
        {
            if (cxt.sender is GButton )
            {

            }
        });
    }

    public void BuildCell()
    {
        list.RemoveChildren();
        Bag bag = Bag.Instance;
        for (int i = 0; i < bag.CellList.Count; i++)
        {
            NewCell();
        }

    }
}
 
