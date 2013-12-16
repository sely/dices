using UnityEngine;
using System.Collections;

public class dice_roll : MonoBehaviour {

	public int minImpuls = 1;
	public int maxImpuls = 100;

	public int minForce = 0;
	public int maxForce = 100;

	public int eyes = 6;
	public int multiplier = 1;

	Vector2[] expectedRotations;
	int[] falseRotations;

	// Use this for initialization
	void Start () {
		roll ();
	}

	public void roll(){
		transform.rotation = Quaternion.Euler(getRandV3(0,360));
		rigidbody.AddTorque(getRandV3(minImpuls,maxImpuls));
		rigidbody.AddForce(getRandV3(minForce,maxForce));
		transform.position = new Vector3(Random.Range(-4, 4),7,Random.Range(-4, 4));
	}

	Vector3 getRandV3 (float min, float max) {
		return new Vector3(Random.Range(min, max), Random.Range(min, max), Random.Range(min, max));
	}
	// Update is called once per frame
	void Update () {
	
	}

	void setRotations () {
		Vector2[] expectedRotations;
		int[] falseRotations;
		switch(eyes) {
		case 3: {
			expectedRotations = new Vector2[]{
				new Vector2(0, 0),
				new Vector2(0, 240),
				new Vector2(0, 120)
			};
			falseRotations = new int[]{
				90,270
			};
			break;
		}
		case 4: {
			expectedRotations = new Vector2[]{
				new Vector2(0, 250),
				new Vector2(0, 0),
				new Vector2(55, 125),
				new Vector2(305, 125)
			};
			break;
		}
		case 6: {
			expectedRotations = new Vector2[]{
				new Vector2(0, 90),
				new Vector2(0, 0),
				new Vector2(90, 0),
				new Vector2(270, 0),
				new Vector2(0, 180),
				new Vector2(0, 270)
			};
			break;
		}
		case 8: {
			expectedRotations = new Vector2[]{
				new Vector2(305, 0),
				new Vector2(0, 125),
				new Vector2(0, 55),
				new Vector2(305, 180),
				new Vector2(55, 0),
				new Vector2(0, 235),
				new Vector2(0, 305),
				new Vector2(55, 180)
			};
			break;
		}
		case 10: {
			expectedRotations = new Vector2[]{
				new Vector2(305, 0),
				new Vector2(0, 125),
				new Vector2(0, 55),
				new Vector2(305, 180),
				new Vector2(55, 0),
				new Vector2(0, 235),
				new Vector2(0, 305),
				new Vector2(0, 235),
				new Vector2(0, 305),
				new Vector2(55, 180)
			};
			break;
		}
		}
	}
	
	int getNumber() {
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
		if (eyes != 10)
			ind ++;
		ind = ind * multiplier;
		return ind;
	}
}
