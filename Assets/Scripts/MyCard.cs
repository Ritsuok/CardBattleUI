using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MyCard : MonoBehaviour {

	public GameObject card01;
	public GameObject MyCardsHolder;
	public GameObject dummyCard;
	private GameObject clone;
	private GameObject DeckPlaceH;
	public List<GameObject> cards;
	public int maxCards = 20;

	public List<string> availableCards;
	public List<string> cardsInDeck;

	private float handX;
	private float handY;

	// Use this for initialization
	void Start () {
		//Random rand = new Random();

		MyCardsHolder = GameObject.Find ("Hand");
		print ("MyCardsHolder is " + MyCardsHolder.name);
		DeckPlaceH = GameObject.Find ("DeckCardH");
		clone = Instantiate (dummyCard, dummyCard.transform.position, dummyCard.transform.rotation) as GameObject;
		clone.transform.SetParent (DeckPlaceH.transform);

		availableCards = new List<string>(){"Prefabs/Card01","Prefabs/Card02","Prefabs/Card03","Prefabs/Card04","Prefabs/Card05"};
		cardsInDeck = new List<string> ();
		for (int i = 0; i < maxCards; i++) {
			int rand = Random.Range(0,availableCards.Count);
			cardsInDeck.Add(availableCards[rand]);
		}

		for (int i = 0; i < 5; i++) {
			GameObject prefab = (GameObject)Resources.Load (cardsInDeck[i]);
			print ("prefab's name is " + prefab.name);
			card01 = Instantiate(prefab);
			card01.transform.SetParent(MyCardsHolder.transform);
			cardsInDeck.RemoveAt(i);
		}
/*
		GameObject prefab = (GameObject)Resources.Load ("Prefabs/Card01");
		print ("prefab's name is " + prefab.name);
		card01 = Instantiate(prefab);
		card01.transform.SetParent(MyCardsHolder.transform);
		cardsInDeck.RemoveAt(0);
*/
		//cards = new List<GameObject> ();

		//cards.Add ();
		// Instantiates a prefab named "enemy" located in any Resources
		// folder in your project's Assets folder.
		//GameObject prefab = (GameObject)Resources.Load ("Prefabs/01");
		//GameObject instance = Instantiate(Resources.Load("enemy", typeof(GameObject))) as GameObject;
	
	}
	
	// Update is called once per frame
	void Update () {
		movToHand ();
	}
	int moveScale = 3;
	void movToHand(){

		clone.transform.SetParent (clone.transform.parent);
		Transform handTrans = MyCardsHolder.transform;
		float dummyX = clone.transform.position.x;
		float dummyY = clone.transform.position.y;
		if (dummyX <= handTrans.position.x) {
			//print (EchildGameobjects[fightE].transform.position.x + moveScale);
			dummyX += moveScale;

		}
		if (dummyY >= handTrans.position.y) {
			//EchildGameobjects[fightE].transform.position.y += moveScale;
			dummyY -= moveScale;
		}
		
		//print ("cardX = " + cardX + " lostCardsE.transform.position.x =" + lostCardsE.transform.position.x);
		//print ("cardY = " + cardY + " lostCardsE.transform.position.y =" + lostCardsE.transform.position.y);
		
		clone.transform.position = new Vector2 (dummyX, dummyY);
		//EchildGameobjects [fightE].transform.position.x = (float)cardX;
		//EchildGameobjects [fightE].transform.position.y = (float)cardY;
/*		
		if (lostCardsE.transform.position.x >= EchildGameobjects [fightE].transform.position.x && lostCardsE.transform.position.y <= EchildGameobjects [fightE].transform.position.y) {
			defeat = false;
			EchildGameobjects[fightE].transform.SetParent(lostCardsE.transform);
			if (EchildGameobjects[fightE] == EchildGameobjects[0]) {
				youWin();
			}
			listIndex ++;
			glowTheFight(listIndex);

		}
		*/
	}

}
