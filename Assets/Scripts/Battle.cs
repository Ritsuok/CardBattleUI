using UnityEngine;
using System.Collections;


public class Battle : MonoBehaviour {

	Points points;

	GameObject childCard;



	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {

	
	}

	// will becalled from TurnEnd Class
	public void attack(){
		Debug.Log ("doing attack()");

		// find child
		foreach(Transform child in transform) {
			childCard = child.gameObject;
		}

				if (childCard != null) {
			// Get PointClass of the childCard
			points = childCard.GetComponent<Points> ();

			Debug.Log ("childCard = " + childCard.name);
			Debug.Log ("H1 Ap = " + points.attackPoint);
			Debug.Log ("H1 Dp = " + points.defencePoint);
			Debug.Log ("H1 Cp = " + points.costPoint);
		}

	}

}
