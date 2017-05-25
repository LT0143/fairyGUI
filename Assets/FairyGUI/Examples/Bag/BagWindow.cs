using System;
using System.Collections.Generic;
using FairyGUI;
using UnityEngine;
using DG.Tweening;

public class BagWindow : Window
{
	GList _list;
	Controller _page;

	public BagWindow()
	{
	}

	protected override void OnInit()
	{
		this.contentPane = UIPackage.CreateObject("Bag", "BagWin").asCom;
		this.Center();
		this.modal = true;

		_page = this.contentPane.GetController("page");

		_list = this.contentPane.GetChild("list").asList;
		_list.onClickItem.Add(__clickItem);
		_list.itemRenderer = RenderListItem;
		_list.scrollPane.onScroll.Add(OnScroll);
		_list.numItems = 45;
	}

	void RenderListItem(int index, GObject obj)
	{
		GButton button = (GButton)obj;
		button.icon = "i" + UnityEngine.Random.Range(0, 10);   //设置图片和图片的名字
		button.title = "" + UnityEngine.Random.Range(0, 100);
	}

	void OnScroll()
	{
		_page.selectedIndex = _list.scrollPane.currentPageX;
        Debug.Log("_list.scrollPane.currentPageX  " + _list.scrollPane.currentPageX);
	}

	override protected void DoShowAnimation()
	{
		this.SetScale(0.1f, 0.1f);
		this.SetPivot(0.5f, 0.5f);
		this.TweenScale(new Vector2(1, 1), 0.3f).SetEase(Ease.OutQuad).OnComplete(this.OnShown);
	}

	override protected void DoHideAnimation()
	{
		this.TweenScale(new Vector2(0.1f, 0.1f), 0.3f).SetEase(Ease.OutQuad).OnComplete(this.HideImmediately);
	}

    /// <summary>
    /// 点击后的列表项赋值
    /// </summary>
    /// <param name="context"></param>
	void __clickItem(EventContext context)
	{
		GButton item = (GButton)context.data;
		this.contentPane.GetChild("n11").asLoader.url = item.icon;
		this.contentPane.GetChild("n13").text = item.icon;
	}
}
