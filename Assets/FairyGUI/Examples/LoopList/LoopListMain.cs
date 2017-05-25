using UnityEngine;
using FairyGUI;

public class LoopListMain : MonoBehaviour
{
	GComponent _mainView;
	GList _list;

	void Start()
	{
        Application.targetFrameRate = 60;   //目标速率帧
        Stage.inst.onKeyDown.Add(OnKeyDown);

        UIPackage.AddPackage("UI/LoopList");

        _mainView = this.GetComponent<UIPanel>().ui;

        _list = _mainView.GetChild("list").asList;
        _list.SetVirtualAndLoop();

        _list.itemRenderer = RenderListItem;   //添加委托事件
        _list.numItems = 5;
        _list.scrollPane.onScroll.Add(DoSpecialEffect);

        DoSpecialEffect();
    }

	void DoSpecialEffect()
	{
		//change the scale according根据 to the distance to middle
		float midX = _list.scrollPane.posX + _list.viewWidth / 2;
		int cnt = _list.numChildren;   //子项数量从0开始计算
        Debug.Log("cnt" + cnt + "  _list.numItems子项数量从1开始计算" + _list.numItems);
		for (int i = 0; i < cnt; i++)
		{
			GObject obj = _list.GetChildAt(i);
			float dist = Mathf.Abs(midX - obj.x - obj.width / 2);
			if (dist > obj.width) //no intersection t图片与中心没有交集
				obj.SetScale(1, 1);
			else
			{
				float ss = 1 + (1 - dist / obj.width) * 0.24f; //结果大于1。越往中心越大。
				obj.SetScale(ss, ss);
			}
		}

		_mainView.GetChild("n3").text = "" + ((_list.GetFirstChildInView() + 1) % _list.numItems);
	}

	void RenderListItem(int index, GObject obj)
	{
		GButton item = (GButton)obj;
		item.SetPivot(0.5f, 0.5f);//放大缩小由中心开始
		item.icon = UIPackage.GetItemURL("LoopList", "n" + (index + 1));
	}

	void OnKeyDown(EventContext context)
	{
		if (context.inputEvent.keyCode == KeyCode.Escape)
		{
			Application.Quit();
		}
	}
}