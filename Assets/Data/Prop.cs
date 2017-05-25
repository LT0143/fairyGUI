using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FairyGUI;


public class Prop
{
    public string Name;

    public string IconUrl
    {
        get { return UIPackage.GetItemURL("Bag", Name); }
    }

}

