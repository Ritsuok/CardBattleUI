﻿using UnityEngine;
using UnityEngine.UI;
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
	private GameObject batsu;

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
	private bool attacked = false;

	enum State{
		NotInBattle,
		Battle0,
		Battle1,
		Battle2,
		Battle3,
		GameOver
	};



	private int listIndex;

	State state = State.NotInBattle;

	private List<State> statelist;

	private int count = 0;

	private float timer;
	private int waitingTime = 2;
	private bool wait = false;

	private int fightH;
	private int fightE;
	
	// Use this for initialization
	void Start () {
		mathPanel = GameObject.Find ("MathPanel");
		Debug.Log (mathPanel + "found");
		mathbattle = mathPanel.GetComponent<MathBattle> ();
		mathPanel.SetActive(false);
		batsu = GameObject.Find ("BatsuImage");
		batsu.SetActive (false);
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

		statelist = new List<State>(){State.Battle0, State.Battle1, State.Battle2, State.Battle3, State.NotInBattle,State.GameOver};
		
		// Get BattleClass
		battle = H1.GetComponent<Battle> ();

		 
		
	}
	
	// Update is called once per frame
	void Update () {

		switch (state) {
		case State.Battle1:
			listIndex = 1;

			if(wait2sec()){
				mathPanel.SetActive(true);
				mathbattle.inputDPAP (EcardDPs [fightE], HcardAPs [fightH]);
				state = State.NotInBattle;
			}
			break;
		case State.Battle2:
			listIndex = 2;
			if(wait2sec()){
				mathPanel.SetActive(true);
				mathbattle.inputDPAP (EcardDPs [fightE], HcardAPs [fightH]);
				state = State.NotInBattle;
			}
			break;
		case State.Battle3:
			listIndex = 3;
			if(wait2sec()){
				mathPanel.SetActive(true);
				mathbattle.inputDPAP (EcardDPs [fightE], HcardAPs [fightH]);
				state = State.NotInBattle;
			}
			break;
		}
		if (defeat == true) {
			move();
		}

		if (attacked == true) {
			shake(nullObj);
		}
		if (wait == true) {
			deactive(nullObj);
		}
	}
	
	// do when this is clicked
	public void isClicked(){
		for (int i = 0; i < HtabletopGameobjects.Count; i++) {
			dropchange = HtabletopGameobjects[i].GetComponent<DropChange>();
			HChildsAreTrue[i] = dropchange.childIs;
			Debug.Log ("H" + i + " Child = " + HChildsAreTrue[i]);
			// when Enemy cards tabletop starts with null, active the bellow script

			dropchange = EtabletopGameobjects[i].GetComponent<DropChange>();
			EChildsAreTrue[i] = dropchange.childIs;

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
		//mathPanel.SetActive(true);
	

		Debug.Log ("I'm Clicked");
		listIndex = 1;
		glowTheFight (listIndex);
/*
		//check if HtabletopGameobjects is on table
		if (HcardAPs [1] <= 0) {
			fightH = 2;
			fightE = 2;
			state = State.Battle2;
		}
		//check if EtabletopGameobjects is on table
		if (EcardDPs [1] <= 0) {
			fightH = 1;
			fightE = 0;
			glow (HtabletopGameobjects [fightH]);
			glow (EtabletopGameobjects [fightE]);
			state = State.Battle1;
		} else {
			fightH = 1;
			fightE = 1;
			glow (HtabletopGameobjects [fightH]);
			glow (EtabletopGameobjects [fightE]);
			state = State.Battle1;
		}
*/		
		//battle.attack ();
		Debug.Log ("AfterLoop E" + 1 + " Dp = " + EcardDPs[fightE]);
		Debug.Log ("AfterLoop H" + 1 + " Ap = " + HcardAPs[fightH]);


		//mathbattle.testMethod ("test is done");
		//mathbattle.inputDPAP (EcardDPs[fightE], HcardAPs[fightH]);
		//mathbattle.inputDPAP (30, 15);


	}
	public void firstBattle(bool winOrLoose){
		mathPanel = GameObject.Find ("MathPanel");
		mathPanel.SetActive(false);
		//print ("winOrLoose = " + winOrLoose);
		//print("fistBattle E" + 1 + " Dp = " + EcardDPs[fightE]);
		//print("fistBattle E" + 1 + " card.name = " + EchildGameobjects[fightE].name);
		//print("fistBattle E" + 1 + " points.defencePoint = " + pointsList[fightE].defencePoint);

		if (winOrLoose == true) {

			pointsList [fightE].defencePoint = EcardDPs [fightE] - HcardAPs [fightH];
			print ("fistBattle E" + 1 + " points.defencePoint = " + pointsList [fightE].defencePoint);
			if (pointsList [fightE].defencePoint <= 0) {
				pointsList [fightE].defencePoint = 0;
			}
			nullObj = EchildGameobjects [fightE];
			attacked = true;
			//pointsList[fightE].setPointonCard();
			print ("card.transform.position.x =" + EchildGameobjects [fightE].transform.position.x);
			print ("card.transform.position.y =" + EchildGameobjects [fightE].transform.position.y);

		} else {
			batsu.SetActive (true);
			nullObj = batsu;
			wait = true;
		}

	}
	void nextbattle(){
		unGlow();
		//if the answer is smaller than 0 release parent and set defeat = true
		if (pointsList[fightE].defencePoint <= 0) {
			//EchildGameobjects[fightE].transform.SetParent(lostCardsE.transform);
			EchildGameobjects[fightE].transform.SetParent(EchildGameobjects[fightE].transform.parent.parent);
			print("lostCardsE.transform.position.x =" + lostCardsE.transform.position.x);
			print("lostCardsE.transform.position.y =" + lostCardsE.transform.position.y);
			defeat = true;
		}else{
			listIndex ++;
			glowTheFight(listIndex);
		}

	}

	void move(){
		print ("moving");
		int moveScale = 3;
		int cardX = (int)EchildGameobjects [fightE].transform.position.x;
		int cardY = (int)EchildGameobjects [fightE].transform.position.y;
		float garbageX = lostCardsE.transform.position.x;
		float garbageY = lostCardsE.transform.position.y;
		if (garbageX <= cardX) {
			print (EchildGameobjects[fightE].transform.position.x + moveScale);
			cardX -= moveScale;
			//EchildGameobjects[fightE].transform.position.x += moveScale;
		}
		if (garbageY >= cardY) {
			//EchildGameobjects[fightE].transform.position.y += moveScale;
			cardY += moveScale;
		}

		print ("cardX = " + cardX + " lostCardsE.transform.position.x =" + lostCardsE.transform.position.x);
		print ("cardY = " + cardY + " lostCardsE.transform.position.y =" + lostCardsE.transform.position.y);

		EchildGameobjects [fightE].transform.position = new Vector2 (cardX, cardY);
		//EchildGameobjects [fightE].transform.position.x = (float)cardX;
		//EchildGameobjects [fightE].transform.position.y = (float)cardY;

		if (lostCardsE.transform.position.x >= EchildGameobjects [fightE].transform.position.x && lostCardsE.transform.position.y <= EchildGameobjects [fightE].transform.position.y) {
			defeat = false;
			EchildGameobjects[fightE].transform.SetParent(lostCardsE.transform);
			if (EchildGameobjects[fightE] == EchildGameobjects[0]) {
				youWin();
			}
			listIndex ++;
			glowTheFight(listIndex);
		}
	}
	private void shake(GameObject shakeObject){
		int moveScale = 10;
		int cardX = (int)shakeObject.transform.position.x;
		int cardY = (int)shakeObject.transform.position.y;

		if (count%2 == 0) {
			moveScale = moveScale*-1;
			cardX += moveScale;
		}else{
			cardX += moveScale;
		}
		shakeObject.transform.position = new Vector2 (cardX, cardY);
		count++;

		if (count>79) {
			pointsList[fightE].setPointonCard();
			count = 0;
			nextbattle ();
			attacked = false;
		}


	}

	void deactive(GameObject deactiveObject){
		timer += Time.deltaTime;
		if (timer > waitingTime) {
			deactiveObject.SetActive(false);
			timer = 0;
			nullObj = null;
			wait = false;
			state = statelist[listIndex];
		}
	}
	private List<GameObject> nowGlows = new List<GameObject>();
	private List<Color> nowColors = new List<Color> ();
	void glow(GameObject glowObject){
		nowGlows.Add(glowObject);
		float size = (float)1.1;
		Color originColor = glowObject.GetComponent<Image> ().color;
		nowColors.Add (originColor);
		print ("image color is " + glowObject.GetComponent<Image> ().color);
		print ("Vector3 is " + glowObject.GetComponent<RectTransform> ().transform.localScale);
		glowObject.GetComponent<Image>().color = new Color (255, 255, 255, 255);
		glowObject.GetComponent<RectTransform> ().transform.localScale = new Vector3(size, size, size);

	}
	void unGlow(){
		for (int i = 0; i < nowGlows.Count; i++) {
			nowGlows[i].GetComponent<Image>().color = nowColors[i];
			nowGlows[i].GetComponent<RectTransform> ().transform.localScale = new Vector3(1, 1, 1);
		}
		nowColors.Clear ();
		nowGlows.Clear ();
	}

	bool wait2sec(){
		timer += Time.deltaTime;
		Debug.Log ("timer = " + timer);
		if (timer > waitingTime) {
			timer = 0;
			return true;
		} else {
			return false;
		}

	}
	void glowTheFight(int indexNow){
		//check if HtabletopGameobjects is on table
		if (HcardAPs [indexNow] <= 0) {
			fightH = indexNow + 1;
			fightE = indexNow + 1;
			state = statelist [indexNow + 1];
			indexNow ++;
		}
		//check if EtabletopGameobjects is on table
		if (EcardDPs [indexNow] <= 0) {
			fightH = indexNow;
			fightE = 0;
			glow (HtabletopGameobjects [fightH]);
			glow (EtabletopGameobjects [fightE]);
			state = statelist [indexNow];
		} else {
			fightH = indexNow;
			fightE = indexNow;
			glow (HtabletopGameobjects [fightH]);
			glow (EtabletopGameobjects [fightE]);
			state = statelist [indexNow];
		}
	}
	void youWin(){
		print ("You Win!");
	}

}
