using UnityEngine;
using System.Collections;
using FairyGUI;

public class ChangeLanguage : MonoBehaviour {
    private GComponent _mainView;
    private GComponent _testView;

    // Use this for initialization
    void Start () {
        GRoot.inst.SetPosition(50, 50, 0);//.SetContentScaleFactor(800,680);  //设置画布坐标
        loadXml();
        UIPackage.AddPackage("LoopList/language"); //将打包后的文件直接发布到Unity的Resources目录或者其子目录下，加入资源文件夹中的包
        //UIPackage.AddPackage("LoopList/test"); //将打包后的文件直接发布到Unity的Resources目录或者其子目录下，加入资源文件夹中的包
        //_testView = UIPackage.CreateObject("test", "VScroll").asCom;   //该面板切换场景不销毁
        _mainView = UIPackage.CreateObject("language", "language").asCom;   //该面板切换场景不销毁
                                                 
        
        GRoot.inst.AddChild(_mainView);

        //GRoot.inst.AddChild(_testView);
    }

    void loadXml()
    {
        //XmlDocument xml = new XmlDocument();
        //XmlReaderSettings set = new XmlReaderSettings();
        //set.IgnoreComments = true;
        //xml.Load(XmlReader.Create(Application.dataPath+ "Resources/LoopList/yuyan.xml",set));
        //XmlNodeList xmlNodeList = xml.SelectSingleNode("resources").ChildNodes;
        string fileContent = Resources.Load("LoopList/yuyan").ToString(); //自行载入语言文件
        FairyGUI.Utils.XML xml = new FairyGUI.Utils.XML(fileContent);
        UIPackage.SetStringsSource(xml);
    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(10, 100, 100, 30), "中文 "))
        {
            //System.Console.WriteLine("hello world");
            string fileContent = Resources.Load("LanguageXml/Chinese").ToString();

        }

        if (GUI.Button(new Rect(10, 150, 100, 30), "English "))
        {
            string fileContent = Resources.Load("LanguageXml/English").ToString();

        }
    }
    // Update is called once per frame
    void Update () {
	
	}
}
