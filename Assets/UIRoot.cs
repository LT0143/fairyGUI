using UnityEngine;
using System.Collections;
using DG.Tweening;
using FairyGUI;
using DG.Tweening;
public class UIRoot : MonoBehaviour
{
    private GObject _closeBtn;
    private GObject _handBtn;
    private GComponent _mainView;
    private GComponent _detailInfoView;
    private GComponent _titleView;
    private GComponent titleListView;
    private GObject titleGO;
    private GList titleList;
    private GButton titleButton;

    private GButton titleClickBtn;
    private Controller C1;
    private Controller C2;
    private GTextInput inputTest;

    // Use this for initialization
    void Start () {
	    GRoot.inst.SetPosition(50,50,0);//.SetContentScaleFactor(800,680);  //设置画布坐标
	    UIPackage.AddPackage("role"); //将打包后的文件直接发布到Unity的Resources目录或者其子目录下，加入资源文件夹中的包
	    UIPackage.AddPackage("DLGRoleAttribute"); //将打包后的文件直接发布到Unity的Resources目录或者其子目录下，加入资源文件夹中的包
        //_mainView = UIPackage.CreateObject("DLGRoleAttribute", "DLGRoleInfo").asCom;   //该面板切换场景不销毁
        _mainView = UIPackage.CreateObject("role", "DlgRole_property").asCom;   //该面板切换场景不销毁

        _detailInfoView = UIPackage.CreateObject("DLGRoleAttribute", "DLGRoleDetailedInfo").asCom;
        //_titleView = UIPackage.CreateObject("DLGRoleAttribute", "DLGTitle").asCom;
        //comp.Dispose();//销毁 UIPackage.CreateObject创建的包
        //GRoot.inst.AddChild(_mainView);
          GRoot.inst.AddChild(_detailInfoView);
        //GRoot.inst.AddChild(_titleView);
        //_detailInfoView.visible = false;
        //_mainView.visible = false; 


        inputTest = _detailInfoView.GetChild("tf_title").asTextInput;
        //inputTest.maxLength = 15;

        //控制器控制移动缩放
        C1 = _mainView.GetController("c1");
        _closeBtn = _mainView.GetChild("n26").asButton;
        C1.SetSelectedIndex(0);
        _closeBtn.onClick.Add(() => { C1.SetSelectedIndex(1); });

        C2 = _detailInfoView.GetController("c1");
        C2.SetSelectedIndex(8);

        //titleList = UIPackage.CreateObject("DLGRoleAttribute", "DLGTitle").asCom;

        titleListView = UIPackage.CreateObject("DLGRoleAttribute", "DLGTitle2").asCom;
         
       // titleListView.enabled = false;
      //  titleList = titleListView.GetChild("list_title").asList;
        titleGO = _detailInfoView.GetChild("list_title");
        titleGO.visible = false;
        titleList = titleGO.asCom.GetChild("list_title").asList;
        titleButton = _detailInfoView.GetChild("btn_title").asButton;
        titleButton.onClick.Add(() =>
        {
            if (titleGO.visible == false)
            {
                titleGO.visible = true;
                titleList.RemoveChildrenToPool();
                for (int i = 0; i < 3; i++)
                {
                    GButton item = titleList.AddItemFromPool().asButton;
                    item.text =" i am" +  i + item.name;
                    GButton itemBtn = item.GetChild("n1").asButton;
                    itemBtn.onClick.Add(() =>
                    {
                        Debug.Log(item.text);
                        if (titleClickBtn == null)
                        {
                            titleClickBtn = itemBtn;
                            Debug.Log("第一次选中");
                       }
                        else
                        {
                            if (titleClickBtn == itemBtn)
                            {
                                titleClickBtn = null;
                                //具体功能区分
                            }
                            else
                            {
                                titleClickBtn = item;
                            }
                            titleClickBtn.selected = false;
                            //titleClickBtn.GetController("c1").se;
                            Debug.Log("上个选中了" + titleClickBtn.selected );
                       }
                       titleClickBtn = itemBtn;
                    });
               }
            }
            else
            {
                titleGO.visible = false;
                Debug.Log(" titleGO.visible = false;");
            }
        });
        IntTest();
      //  testPanel();
        //GComponent win = comp.GetChild("n2").asCom;
        //cl - win.GetController("滑进来了");
     //   TestImg();
       // TestList();
        //ModeTest();
    }

    void IntTest()
    {
        float a = 600.0f;
        float b =1-80.0f/100f;
        float c = a * b;
        Debug.Log(c );
    }

    void ModeTest()
    {
        Object prefab = Resources.Load("Role/npc");
        GameObject go = (GameObject)Object.Instantiate(prefab);
        go.transform.localPosition = new Vector3(0, -89, 0); //set z to far from UICamera is important!
        go.transform.localScale = new Vector3(180, 180, 180);
        go.transform.localEulerAngles = new Vector3(0, 100, 0);
        _titleView.GetChild("holder").asGraph.SetNativeObject(new GoWrapper(go));
    }

    void TestButton()
    {

        //_handBtn = _mainView.GetChild("btn_head");
        //Debug.Log(_handBtn.name);
        //_handBtn.onClick.Add(OnClickHand);

        //_closeBtn = _detailInfoView.GetChild("btn_close");

        //_detailInfoView.GetChild("btn_close").onClick.Add(() => {
        //    _mainView.visible = true;
        //    _detailInfoView.visible = false;
        //    Debug.Log("CloseOnClick");
        //});
    }

    void TestList()
    {
        GList list = _titleView.GetChild("list_title").asList;
        //    list.SetVirtualAndLoop(); //虚拟循环
        for (int i = 0; i < 3; i++)
        {
            GButton item = list.AddItemFromPool().asButton;//添加元素
            item.GetChild("title").text = "joiajdsoi  " + i;
            //item.GetChild("tf_title").asTextField.color = 
        }//
         //     list.EnsureBoundsCorrect(); //通知GList立刻重排
         //  list.numItems = 5; //列表长度
         //  list.itemRenderer = RenderListItem;
         //list.itemRenderer = (int index, GObject item) =>
         //{
         //    GButton button = (GButton) item;
         //    button.icon = UIPackage.GetItemURL("DLGRoleAttribute", "n" + (index + 1))  ; };
    }

    void TestImg()
    {
        //GGraph g1 = comp.GetChild("g1").asGraph;
        //Texture2D tex = Resources.Load<Texture2D>("pic/1");

        //   Image img = new Image(); 
        //   img.texture = new NTexture(tex);
        //   img.SetSize(100,100);
        //   g1.SetNativeObject(img);
    }

    void testPanel()
    {
        //加入包
        //与其他UIPackage.CreateObject创建出来的界面不同，UIPanel在GameObjec销毁时（手动销毁或者过场景等）时会一并销毁。
        //UIPanel panel = gameObject.GetComponent<UIPanel>();
        //GComponent view = panel.ui;

        //动态创建UIPanel为任意游戏对象挂接UI界面，UIPanel的生命周期将和yourGameObject保持一致,注意yourGameObject的layer
        //   UIPanel panel = gameObject.AddComponent<UIPanel>();
        //   panel.packageName ="DlgRoleInfo";
        //panel.componentName = "detail";
        //   panel.CreateUI();

    }

    //void RenderListItem(int index,GObject obj)
    //{
    //    MailItem item = (MailItem) obj;

    //}

    void OnClickHand()
    {
        _mainView.visible = false;
        _detailInfoView.visible = true;
        Debug.Log("HandOnClick");
    }

    // Update is called once per frame
    void OnClickClose() {
        _mainView.visible = true;
        _detailInfoView.visible = false;
        Debug.Log("CloseOnClick");
    }

    public class Title
    {
        private int type;//类型
        int id;
        int time;//持续时间
    }
}