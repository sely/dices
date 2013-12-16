using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class box_onclick_roll : MonoBehaviour {

	List<GameObject> dices = new List<GameObject>();
	public List<GameObject> dices_prefab = new List<GameObject>();
	GameObject dice_w6_0;


	// Use this for initialization
	void Start () {
		//GameObject dice_w6 = (GameObject)Resources.Load("dices/dice_w6",typeof(GameObject));
		
		//dices_prefab.Add(dice_w6);
		//dice_w6_0 = dice_w6;
	}
	
	
	void createDice() {
		int ind = (int) Random.Range(0, dices_prefab.Count);
		GameObject dice = (GameObject) Instantiate(dices_prefab[ind]);
		 
		dices.Add(dice);

	}

	// Update is called once per frame
	void Update () {

	}

	void rollAll() {
		foreach (GameObject dice in dices)
		{
			dice.GetComponent<dice_roll>().roll();
		}
	}
	
	
	void OnGUI() {
		if (GUI.Button (new Rect (10,10,80,80), "+")) {
			createDice();
		}
		
		if (GUI.Button (new Rect (100,10,80,80), "+")) {
			rollAll();
		}
	}
}
