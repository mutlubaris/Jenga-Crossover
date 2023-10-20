using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventManager
{
	public static RightClickEvent OnBlockRightClicked = new RightClickEvent();
}

public class RightClickEvent : UnityEvent<Block> { }
