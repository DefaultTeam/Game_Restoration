using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventar : MonoBehaviour {

	public int[] items;
	public int mouseSlot;
	public InventarLibrary lib;

	void OnGUI()
	{
		for (int x = 0; x < 5; x++) 
		{
			for (int y = 0; y < 5; y++) 
			{
				if (GUI.Button (new Rect (x * 100, y * 100, 100, 100), lib.Images[items[y * 5 + x]])) 
				{
					
				}
			}
		}
	}
}
