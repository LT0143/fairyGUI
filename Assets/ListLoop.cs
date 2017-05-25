using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FairyGUI;
using UnityEngine;
using DG.Tweening;
using System.Xml;
using System.IO;

public class ListLoop : MonoBehaviour
{
    private GComponent _mainView;
    //GList _list;
    //Bag bag = new Bag();
    //private GTextInput input;
    //private GTextField lenth;
    private GTextField yesTf;
    private GTextField noTf;
    void Start()
    {
        //    for (int i = 0; i < 20; i++)
        //    {
        //        bag.NewCell();
        //    }
        //    UIObjectFactory.SetPackageItemExtension(BagUI.url, typeof(BagUI));

        UIPackage.AddPackage("LoopList/language");
       // UIPackage.AddPackage("UI/LoopList");

        _mainView = this.GetComponent<UIPanel>().ui;
        //input = _mainView.GetChild("n2").asTextInput;
        //lenth = _mainView.GetChild("n3").asTextField;

        //input.onChanged.Add(() =>
        //{
        //    byte[] rAarray = System.Text.Encoding.Default.GetBytes(input.text);
        //    byte[] newArry= new byte[15];
        //    //string newText = string.Empty;
        //    int len = rAarray.Length;
        //    lenth.text = "当前输入字符串的长度" + len;
        //    if(len > 15)
        //    {
        //        //for (int i = 0; i < 15; i++)
        //        //{
        //        //    newArry[i] = rAarray[i];
        //        //}
        //        Array.Copy(rAarray,0,newArry,0,15);
        //        input.text = System.Text.Encoding.Default.GetString(newArry);
        //        rAarray = System.Text.Encoding.Default.GetBytes(input.text);
        //        len = rAarray.Length;
        //        lenth.text = "限制后输入字符串的长度" + len;
        //    }

        //});
        //_list = _mainView.GetChild("list_loop").asList;
        //////list = _mainView.GetChild("list").asList;
        //_list.SetVirtualAndLoop();
        //_list.itemRenderer = (int index, GObject item) =>
        //{
        //    GButton button = (GButton)item;
        //    //button.icon = UIPackage.GetItemURL("LoopList", "n" + (index + 1));
        //    item.SetPivot(0.5f, 0.5f);//放大缩小由中心开始
        //    button.icon = UIPackage.GetItemURL("test", "k19" );//+ (index + 1)
        //};
        //_list.numItems = 5;
        //_list.scrollPane.onScroll.Add(DoSpecialEffect);
        //DoSpecialEffect();


        //yesTf = _mainView.GetChild("qd").asTextField;
        //noTf = _mainView.GetChild("qx").asTextField;
        loadXml();
    }

    void loadXml()
    {
        //XmlDocument xml = new XmlDocument();
        //XmlReaderSettings set = new XmlReaderSettings();
        //set.IgnoreComments = true;
        //xml.Load(XmlReader.Create(Application.dataPath+ "Resources/LoopList/yuyan.xml",set));
        //XmlNodeList xmlNodeList = xml.SelectSingleNode("resources").ChildNodes;
        string fileContent = Resources.Load("LoopList/yuyanTest").ToString(); //自行载入语言文件
        FairyGUI.Utils.XML xml = new FairyGUI.Utils.XML(fileContent);
        UIPackage.SetStringsSource(xml);
    }


    /*  背包
    void DoSpecialEffect()
    {
        //change the scale according根据 to the distance to middle
        float midY = _list.scrollPane.posY + _list.viewHeight / 2;
        int cnt = _list.numChildren;   //子项数量从0开始计算
        //Debug.Log("cnt" + cnt + "  _list.numItems子项数量从1开始计算" + _list.numItems);
        for (int i = 0; i < cnt; i++)
        {
            GObject obj = _list.GetChildAt(i);
            float dist = Mathf.Abs(midY - obj.y - obj.height/2f);
            if (dist >= obj.height) //no intersection t图片与中心没有交集
            {
                //obj.SetScale(1, 1);
                obj.TweenScale(new Vector2(1f, 1f), 0.2f).SetEase(Ease.OutSine); //.OnComplete(this.HideImmediately);
                obj.TweenMoveX(0, 0.2f);//.SetEase(Ease.OutQuad); //.OnComplete(this.HideImmediately);
            }
            else
            {
                //float ss = 1 + (1 - dist / obj.width) * 0.4f; //结果大于1。越往中心越大。
                obj.TweenScale(new Vector2(1.4f, 1.4f), 0.2f).SetEase(Ease.OutSine);
                    //.OnComplete(this.HideImmediately);
                obj.TweenMoveX(60f, 0.2f);//.SetEase(Ease.OutSine); //.OnComplete(this.HideImmediately);

                //obj.SetScale(ss, ss);
            }
        }

        //_mainView.GetChild("n3").text = "" + ((_list.GetFirstChildInView() + 1) % _list.numItems);
    }

    void Update()
    {
        if (Input.GetKeyDown( KeyCode.A))
        {
            //Bag.Instance.AddProp();

        }
    }
    */


}

