using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TurnEnd : MonoBehaviour {
	// import Points Class
	Points points;
	// BattlClass
	Battle battle;
	
	// Tabletop Card Ap DP CP default
	private GameObject H0;
	private GameObject H0Child;
	private int H0_AP;
	private int H0_DP;
	private int H0_CP;
	
	private GameObject H1;
	private GameObject H1Child;
	private int H1_AP;
	private int H1_DP;
	private int H1_CP;
	
	private GameObject H2;
	private GameObject H2Child;
	private int H2_AP;
	private int H2_DP;
	private int H2_CP;
	
	private GameObject H3;
	private GameObject H3Child;
	private int H3_AP;
	private int H3_DP;
	private int H3_CP;
	
	private GameObject E0;
	private GameObject E0Child;
	private int E0_AP;
	private int E0_DP;
	private int E0_CP;
	
	private GameObject E1;
	private GameObject E1Child;
	private int E1_AP;
	private int E1_DP;
	private int E1_CP;
	
	private GameObject E2;
	private GameObject E2Child;
	private int E2_AP;
	private int E2_DP;
	private int E2_CP;
	
	private GameObject E3;
	private GameObject E3Child;
	private int E3_AP;
	private int E3_DP;
	private int E3_CP;
	
	private List<GameObject> HtabletopGameobjects;
	private List<GameObject> HchildGameobjects;
	private List<int> HcardAPs;
	private List<int> HcardDPs;
	private List<int> HcardCPs;
	
	private List<GameObject> EtabletopGameobjects;
	private List<GameObject> EchildGameobjects;
	private List<int> EcardAPs;
	private List<int> EcardDPs;
	private List<int> EcardCPs;
	
	// Use this for initialization
	void Start () {
		// Find Home tabletops
		H0 = GameObject.Find ("TabletopH0");
		H1 = GameObject.Find ("TabletopH1");
		H2 = GameObject.Find ("TabletopH2");
		H3 = GameObject.Find ("TabletopH3");
		// Find Enemy tabletops
		E0 = GameObject.Find ("TabletopE0");
		E1 = GameObject.Find ("TabletopE1");
		E2 = GameObject.Find ("TabletopE2");
		E3 = GameObject.Find ("TabletopE3");
		//Debug.Log ("H1 = " + H1.name);
		
		// new List
		HtabletopGameobjects = new List<GameObject> (){H0,H1,H2,H3};
		HchildGameobjects = new List<GameObject>(){H0Child,H1Child,H2Child,H3Child};
		HcardAPs = new List<int>(){H0_AP,H1_AP,H2_AP,H3_AP};
		HcardDPs = new List<int>(){H0_DP,H1_DP,H2_DP,H3_DP};
		HcardCPs = new List<int>(){H0_CP,H1_CP,H2_CP,H3_CP};
		
		// new List
		EtabletopGameobjects = new List<GameObject> (){E0,E1,E2,E3};
		EchildGameobjects = new List<GameObject>(){E0Child,E1Child,E2Child,E3Child};
		EcardAPs = new List<int>(){E0_AP,E1_AP,E2_AP,E3_AP};
		EcardDPs = new List<int>(){E0_DP,E1_DP,E2_DP,E3_DP};
		EcardCPs = new List<int>(){E0_CP,E1_CP,E2_CP,E3_CP};
		
		// Get BattleClass
		battle = H1.GetComponent<Battle> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	// do when this is clicked
	public void isClicked(){
		//H1Child = H1.transform.FindChild ("Child").gameObject;
		
		// inistialize with null or 0
		for (int i = 0; i < HchildGameobjects.Count; i++) {
			HchildGameobjects[i] = null;
			HcardAPs[i] = 0;
			HcardDPs[i] = 0;
			HcardCPs[i] = 0;
			EchildGameobjects[i] = null;
			EcardAPs[i] = 0;
			EcardDPs[i] = 0;
			EcardCPs[i] = 0;
		}
		

		/*
		for (int i = 0; i < E1.transform.childCount; i++) {
			print(E1.transform.GetChild (i).name);

		}
*/
		//E1Child = E1.transform.FindChild("Card").gameObject;
		
		// Get child number0
		//E1Child = E1.transform.GetChild(0).gameObject;
		//Debug.Log ("E1childCard = " + E1Child.name);
		
		// Enemy get child, GetComponent<Points>, assign Ap,DP,CP
		for (int i = 0; i < HtabletopGameobjects.Count; i++) {
			HchildGameobjects[i] = HtabletopGameobjects[i].transform.GetChild (0).gameObject;
			
			points = HchildGameobjects[i].GetComponent<Points> ();
			HcardAPs[i] = points.attackPoint;
			Debug.Log ("H" + i + " Ap = " + HcardAPs[i]);
			
			HcardDPs[i] = points.defencePoint;
			Debug.Log ("H" + i + " Dp = " + HcardDPs[i]);
			
			HcardCPs[i] = points.costPoint;
			Debug.Log ("H" + i + " Cp = " + HcardCPs[i]);

			EchildGameobjects[i] = EtabletopGameobjects[i].transform.GetChild (0).gameObject;
			
			points = EchildGameobjects[i].GetComponent<Points> ();
			EcardAPs[i] = points.attackPoint;
			Debug.Log ("E" + i + " Ap = " + EcardAPs[i]);
			
			EcardDPs[i] = points.defencePoint;
			Debug.Log ("E" + i + " Dp = " + EcardDPs[i]);
			
			EcardCPs[i] = points.costPoint;
			Debug.Log ("E" + i + " Cp = " + EcardCPs[i]);
			
		}
/*		
		// find childs
		foreach(Transform child in H0.transform) {
			if (child.gameObject == null) {
				Debug.Log ("H0Child is null");
				
				return;
			}
			H0Child = child.gameObject;
			Debug.Log ("H0childCard = " + H0Child.name);
			HchildGameobjects[0] = H0Child;
			Debug.Log ("H0childCard in List[0] = " + HchildGameobjects[0].name);
			
		}
		foreach(Transform child in H1.transform) {
			
			H1Child = child.gameObject;
			HchildGameobjects[1] = H1Child;
		}
		foreach(Transform child in H2.transform) {
			
			H2Child = child.gameObject;
			HchildGameobjects[2] = H2Child;
		}
		foreach(Transform child in H3.transform) {
			
			H3Child = child.gameObject;
			HchildGameobjects[3] = H3Child;
		}
		for (int i = 0; i < HchildGameobjects.Count; i++) {
			if (HchildGameobjects[i] == null) {
				Debug.Log (i + " null " );
				Debug.Log (i + " Ap = " + HcardAPs[i]);
			}else{
				// Get PointClass of the childCard
				points = HchildGameobjects[i].GetComponent<Points> ();
				HcardAPs[i] = points.attackPoint;
				Debug.Log (i + " Ap = " + HcardAPs[i]);
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
