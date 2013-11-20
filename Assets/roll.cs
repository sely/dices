using UnityEngine;
using System.Collections;

public class roll : MonoBehaviour {

	public GUIText resText;
	string oldNumb = "#";

	// Use this for initialization
	void Start () {
		run ();
	}

	void run () {
		transform.position = new Vector3(0,7,0);
		transform.rotation = Quaternion.Euler(new Vector3(Random.Range(0,360), Random.Range(0,360), Random.Range(0,360)));
		rigidbody.AddTorque(new Vector3(Random.Range(0,360), Random.Range(0,360), Random.Range(0,360)));
	}
	
	// Update is called once per frame
	void Update () {

		Vector2[] expectedRotations = {
			new Vector2(0, 90),
			new Vector2(0, 0),
			new Vector2(90, 0),
			new Vector2(270, 0),
			new Vector2(0, 180),
			new Vector2(0, 270)
		};

		if (rigidbody.IsSleeping()) {
			Vector3 angles = rigidbody.rotation.eulerAngles;
			float diff = 360;
			int ind = 0;
			for(int i = 0; i < expectedRotations.Length; i ++) {
				float d = Mathf.Abs(expectedRotations[i].x - angles.x) + Mathf.Abs(expectedRotations[i].y - angles.z);
				if (d < diff) {
					diff = d;
					ind = i;
				}
			}

			resText.text = (ind+1) + "";
		} else {
			resText.text = "#";
		}
	}

	void OnGUI() {
		if (rigidbody.IsSleeping() && GUI.Button (new Rect (10,10,80,80), "")) {
			run ();
		}
	}
}
