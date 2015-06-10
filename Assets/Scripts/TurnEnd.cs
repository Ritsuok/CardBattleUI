using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TurnEnd : MonoBehaviour {
	// Field Points Class
	Points points;
	private List<Points> pointsList;
	// Field DropChange Class
	DropChange dropchange;
	// Field MathBattle Class
	MathBattle mathbattle;


	// BattlClass
	Battle battle;

	private GameObject mathPanel;

	// Tabletop Card Ap DP CP default
	private GameObject nullObj;

	private GameObject lostCardsH;
	private GameObject lostCardsE;

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

	private List<bool> HChildsAreTrue;
	private List<GameObject> HtabletopGameobjects;
	private List<GameObject> HchildGameobjects;
	private List<int> HcardAPs;
	private List<int> HcardDPs;
	private List<int> HcardCPs;

	private List<bool> EChildsAreTrue;
	private List<GameObject> EtabletopGameobjects;
	private List<GameObject> EchildGameobjects;
	private List<int> EcardAPs;
	private List<int> EcardDPs;
	private List<int> EcardCPs;

	private bool defeat = false;

	enum State{
		NotInBattle,
		Battle0,
		Battle1,
		Battle2,
		Battle3,
	};

	private int listIndex;

	State state = State.NotInBattle;

	private List<State> statelist;

	
	// Use this for initialization
	void Start () {
		mathPanel = GameObject.Find ("MathPanel");
		Debug.Log (mathPanel + "found");
		mathbattle = mathPanel.GetComponent<MathBattle> ();
		mathPanel.SetActive(false);
		nullObj = new GameObject ();
		//mathbattle = new MathBattle ();

		// Find Home tabletops
		H0 = GameObject.Find ("TabletopH0");
		H1 = GameObject.Find ("TabletopH1");
		H2 = GameObject.Find ("TabletopH2");
		H3 = GameObject.Find ("TabletopH3");
		lostCardsH = GameObject.Find ("LostCardH");
		// Find Enemy tabletops
		E0 = GameObject.Find ("TabletopE0");
		E1 = GameObject.Find ("TabletopE1");
		E2 = GameObject.Find ("TabletopE2");
		E3 = GameObject.Find ("TabletopE3");
		lostCardsE = GameObject.Find ("LostCardE");
		//Debug.Log ("H1 = " + H1.name);


		// new List
		pointsList = new List<Points> (){points,points,points,points};
		HChildsAreTrue = new List<bool> (){false,false,false,false};
		HtabletopGameobjects = new List<GameObject> (){H0,H1,H2,H3};
		HchildGameobjects = new List<GameObject>(){H0Child,H1Child,H2Child,H3Child};
		HcardAPs = new List<int>(){H0_AP,H1_AP,H2_AP,H3_AP};
		HcardDPs = new List<int>(){H0_DP,H1_DP,H2_DP,H3_DP};
		HcardCPs = new List<int>(){H0_CP,H1_CP,H2_CP,H3_CP};
		
		// new List
		EChildsAreTrue = new List<bool> (){true,true,true,true};// after AI, adjust this! 
		EtabletopGameobjects = new List<GameObject> (){E0,E1,E2,E3};
		EchildGameobjects = new List<GameObject>(){E0Child,E1Child,E2Child,E3Child};
		EcardAPs = new List<int>(){E0_AP,E1_AP,E2_AP,E3_AP};
		EcardDPs = new List<int>(){E0_DP,E1_DP,E2_DP,E3_DP};
		EcardCPs = new List<int>(){E0_CP,E1_CP,E2_CP,E3_CP};

		statelist = new List<State>(){State.Battle0, State.Battle1, State.Battle2, State.Battle3, State.NotInBattle};
		
		// Get BattleClass
		battle = H1.GetComponent<Battle> ();

		 
		
	}
	
	// Update is called once per frame
	void Update () {

		switch (state) {
		case State.Battle1:
			listIndex = 1;
			mathPanel.SetActive(true);
			mathbattle.inputDPAP (EcardDPs [listIndex], HcardAPs [listIndex]);
			state = State.NotInBattle;
			break;
		case State.Battle2:
			listIndex = 2;
			mathPanel.SetActive(true);
			mathbattle.inputDPAP (EcardDPs [2], HcardAPs [2]);
			state = State.NotInBattle;
			break;
		case State.Battle3:
			listIndex = 3;
			mathPanel.SetActive(true);
			mathbattle.inputDPAP (EcardDPs [3], HcardAPs [3]);
			state = State.NotInBattle;
			break;
		}
		if (defeat == true) {
			move();
		}
		
	}
	
	// do when this is clicked
	public void isClicked(){
		for (int i = 0; i < HtabletopGameobjects.Count; i++) {
			dropchange = HtabletopGameobjects[i].GetComponent<DropChange>();
			HChildsAreTrue[i] = dropchange.childIs;
			Debug.Log ("H" + i + " Child = " + HChildsAreTrue[i]);
			// when Enemy cards tabletop starts with null, active the bellow script
			/*
			dropchange = EtabletopGameobjects[i].GetComponent<DropChange>();
			EChildsAreTrue[i] = dropchange.childIs;
			*/
			Debug.Log ("E" + i + " Child = " + EChildsAreTrue[i]);

		}
		
		// inistialize with null or 0
		for (int i = 0; i < HchildGameobjects.Count; i++) {
			HchildGameobjects[i] = nullObj;
			HcardAPs[i] = 0;
			HcardDPs[i] = 0;
			HcardCPs[i] = 0;
			EchildGameobjects[i] = nullObj;
			EcardAPs[i] = 0;
			EcardDPs[i] = 0;
			EcardCPs[i] = 0;
		}

		//Debug.Log (HtabletopGameobjects[0].transform.childCount);
		//Debug.Log ("HchildGameobjects.Count "+HchildGameobjects.Count);
		//Debug.Log ("HtabletopGameobjects.Count "+HtabletopGameobjects.Count);
		/*		if (H0.transform.IsChildOf(H0.transform))　{
			　　Debug.Log("true");
		}　else　{
			　　Debug.Log("false");
		}
*/
		// Home and Enemy get child, GetComponent<Points>, assign Ap,DP,CP
		for (int i = 0; i < HtabletopGameobjects.Count; i++) {
			//Debug.Log ("HtabletopGameobjects in for loop : " + HtabletopGameobjects[i].transform.childCount);
/*			if (HtabletopGameobjects[i].transform.childCount != 0)　{
				continue;
			}
*/
			if (HChildsAreTrue[i]) {
				HchildGameobjects[i] = HtabletopGameobjects[i].transform.GetChild (0).gameObject;
				pointsList[i] = HchildGameobjects[i].GetComponent<Points> ();
				HcardAPs[i] = pointsList[i].attackPoint;
				HcardDPs[i] = pointsList[i].defencePoint;
				HcardCPs[i] = pointsList[i].costPoint;
			}

			Debug.Log ("H" + i + " Ap = " + HcardAPs[i]);
			Debug.Log ("H" + i + " Dp = " + HcardDPs[i]);
			Debug.Log ("H" + i + " Cp = " + HcardCPs[i]);

			if (EChildsAreTrue[i]) {
				EchildGameobjects[i] = EtabletopGameobjects[i].transform.GetChild (0).gameObject;			
				pointsList[i] = EchildGameobjects[i].GetComponent<Points> ();
				EcardAPs[i] = pointsList[i].attackPoint;
				EcardDPs[i] = pointsList[i].defencePoint;
				EcardCPs[i] = pointsList[i].costPoint;
			}

			Debug.Log ("E" + i + " Ap = " + EcardAPs[i]);
			Debug.Log ("E" + i + " Dp = " + EcardDPs[i]);
			Debug.Log ("E" + i + " Cp = " + EcardCPs[i]);
			
		}


		//GetComponent<mathPanel>().enabled = false;
		mathPanel.SetActive(true);
	

		Debug.Log ("I'm Clicked");
		state = State.Battle1;
		//battle.attack ();
		Debug.Log ("AfterLoop E" + 1 + " Dp = " + EcardDPs[listIndex]);
		Debug.Log ("AfterLoop H" + 1 + " Ap = " + HcardAPs[listIndex]);


		//mathbattle.testMethod ("test is done");
		//mathbattle.inputDPAP (EcardDPs[listIndex], HcardAPs[listIndex]);
		//mathbattle.inputDPAP (30, 15);


	}
	public void firstBattle(bool winOrLoose){
		mathPanel = GameObject.Find ("MathPanel");
		mathPanel.SetActive(false);
		print ("winOrLoose = " + winOrLoose);
		print("fistBattle E" + 1 + " Dp = " + EcardDPs[listIndex]);
		print("fistBattle E" + 1 + " card.name = " + EchildGameobjects[listIndex].name);
		print("fistBattle E" + 1 + " points.defencePoint = " + pointsList[listIndex].defencePoint);

		if (winOrLoose == true) {

			pointsList[listIndex].defencePoint = EcardDPs[listIndex]-HcardAPs[listIndex];
			print("fistBattle E" + 1 + " points.defencePoint = " + pointsList[listIndex].defencePoint);
			if (pointsList[listIndex].defencePoint <= 0) {
				pointsList[listIndex].defencePoint = 0;
			}
			pointsList[listIndex].setPointonCard();
			print("card.transform.position.x =" + EchildGameobjects[listIndex].transform.position.x);
			print("card.transform.position.y =" + EchildGameobjects[listIndex].transform.position.y);
			//EchildGameobjects[listIndex].transform.SetParent(lostCardsE.transform);
			EchildGameobjects[listIndex].transform.SetParent(EchildGameobjects[listIndex].transform.parent.parent);
			print("lostCardsE.transform.position.x =" + lostCardsE.transform.position.x);
			print("lostCardsE.transform.position.y =" + lostCardsE.transform.position.y);
			defeat = true;
		}

	}
	void move(){
		print ("moving");
		int moveScale = 3;
		int cardX = (int)EchildGameobjects [listIndex].transform.position.x;
		int cardY = (int)EchildGameobjects [listIndex].transform.position.y;
		float garbageX = lostCardsE.transform.position.x;
		float garbageY = lostCardsE.transform.position.y;
		if (garbageX <= cardX) {
			print (EchildGameobjects[listIndex].transform.position.x + moveScale);
			cardX -= moveScale;
			//EchildGameobjects[listIndex].transform.position.x += moveScale;
		}
		if (garbageY >= cardY) {
			//EchildGameobjects[listIndex].transform.position.y += moveScale;
			cardY += moveScale;
		}

		print ("cardX = " + cardX + " lostCardsE.transform.position.x =" + lostCardsE.transform.position.x);
		print ("cardY = " + cardY + " lostCardsE.transform.position.y =" + lostCardsE.transform.position.y);

		EchildGameobjects [listIndex].transform.position = new Vector2 (cardX, cardY);
		//EchildGameobjects [listIndex].transform.position.x = (float)cardX;
		//EchildGameobjects [listIndex].transform.position.y = (float)cardY;

		if (lostCardsE.transform.position.x >= EchildGameobjects [listIndex].transform.position.x && lostCardsE.transform.position.y <= EchildGameobjects [listIndex].transform.position.y) {
			defeat = false;
			EchildGameobjects[listIndex].transform.SetParent(lostCardsE.transform);

			state = statelist[listIndex+1];
		}
	}
	
}
