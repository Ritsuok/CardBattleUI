using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TurnEnd : MonoBehaviour {
	Points points;
	// BattlClass
	Battle battle;
	private GameObject nullObj;
	private GameObject H0;
	private GameObject H0Child;
	private int H0_AP;
	private GameObject H1;
	private GameObject H1Child;
	private int H1_AP;
	private GameObject H2;
	private GameObject H2Child;
	private int H2_AP;
	private GameObject H3;
	private GameObject H3Child;
	private int H3_AP;

	private GameObject E1;

	private List<GameObject> childGameobjects;
	private List<int> cardAPs;

	// Use this for initialization
	void Start () {
		// Find H1
		H0 = GameObject.Find ("TabletopH0");
		H1 = GameObject.Find ("TabletopH1");
		H2 = GameObject.Find ("TabletopH2");
		H3 = GameObject.Find ("TabletopH3");
		Debug.Log ("H1 = " + H1.name);

		// new List
		childGameobjects = new List<GameObject>(){H0Child,H1Child,H2Child,H3Child};
		cardAPs = new List<int>(){H0_AP,H1_AP,H2_AP,H3_AP};
		
		// Get BattleClass
		battle = H1.GetComponent<Battle> ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// do when this is clicked
	public void isClicked(){
		//H1Child = H1.transform.FindChild ("Child").gameObject;

		// inistialize with null
		for (int i = 0; i < childGameobjects.Count; i++) {
			childGameobjects[i] = null;
		}

		// inistialize with 0
		for (int i = 0; i < cardAPs.Count; i++) {
			cardAPs[i] = 0;
		}


		// find childs
		foreach(Transform child in H0.transform) {
			if (child.gameObject == null) {
				Debug.Log ("H0Child is null");

				return;
			}
			H0Child = child.gameObject;
			Debug.Log ("H0childCard = " + H0Child.name);
			childGameobjects[0] = H0Child;
			Debug.Log ("H0childCard in List[0] = " + childGameobjects[0].name);

		}
		foreach(Transform child in H1.transform) {

			H1Child = child.gameObject;
			childGameobjects[1] = H1Child;
		}
		foreach(Transform child in H2.transform) {

			H2Child = child.gameObject;
			childGameobjects[2] = H2Child;
		}
		foreach(Transform child in H3.transform) {

			H3Child = child.gameObject;
			childGameobjects[3] = H3Child;
		}
		for (int i = 0; i < childGameobjects.Count; i++) {
			if (childGameobjects[i] == null) {
				Debug.Log (i + " null " );
				Debug.Log (i + " Ap = " + cardAPs[i]);
			}else{
			// Get PointClass of the childCard
			points = childGameobjects[i].GetComponent<Points> ();
			cardAPs[i] = points.attackPoint;
			Debug.Log (i + " Ap = " + cardAPs[i]);
			}

		}
/*		// Get PointClass of the childCard
		points = H1Child.GetComponent<Points> ();
		Debug.Log ("H1childCard = " + H1Child.name);
		Debug.Log ("H1 Ap = " + points.attackPoint);
*/
		Debug.Log ("I'm Clicked");
		//battle.attack ();

	}


}
