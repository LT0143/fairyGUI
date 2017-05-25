using UnityEngine;
using System.Collections;
using FairyGUI;


public class PlayMovie : MonoBehaviour
{
    public GLoader movieLdr;
    public MovieTexture moveTex;
    private GComponent _mainView;

    // Use this for initialization
    void Start ()
	{
        //   UIPanel panel = gameObject.AddComponent<UIPanel>();
        //   panel.packageName = "moviePlay";
        //panel.componentName = "moviePlaying";
        //   panel.CreateUI();
      //  GRoot.inst.SetPosition(150, 150, 0);//.SetContentScaleFactor(800,680);  //设置画布坐标
      //  GRoot.inst.SetContentScaleFactor(2, 2, 0);//.SetContentScaleFactor(800,680);  //设置画布坐标
        UIPackage.AddPackage("MoviePlay/moviePlay");
        _mainView = UIPackage.CreateObject("Package1", "moviePlaying").asCom;   

        moveTex =(MovieTexture) Resources.Load("Movie1.mp4");
        GRoot.inst.AddChild(_mainView);
        if (moveTex !=null)
        {
            Debug.Log("moveTex" + moveTex.name);
            movieLdr = _mainView.GetChild("ldr_movie").asLoader;
           // movieLdr.scale = new Vector2(2, 2);
            moveTex.loop = true;
            movieLdr.texture = new NTexture(moveTex);
            //GetComponent<Renderer>().material.mainTexture = moveTex;
            moveTex.Play();
            //moveTex.Pause();
        }


    }

    // Update is called once per frame
    void Update () {
	
	}

    
}
