using UnityEngine;
using System.Collections;
using FairyGUI;

public class UIRootSize : MonoBehaviour {
    private GComponent _mainView;
    private GObject _closeBtn;

    // Use this for initialization
    void Start () {
        UIPackage.AddPackage("role"); //将打包后的文件直接发布到Unity的Resources目录或者其子目录下，加入资源文件夹中的包
        _mainView = UIPackage.CreateObject("role", "DlgRole_property").asCom;   //该面板切换场景不销毁
        
    }
	
	// Update is called once per frame
	void Update () {
	    
	}
}
