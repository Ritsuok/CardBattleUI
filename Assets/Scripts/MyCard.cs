using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MyCard : MonoBehaviour {

	public GameObject card01;
	public GameObject MyCardsHolder;

	public List<GameObject> cards;
	public int maxCards = 20;

	public List<string> availableCards;
	public List<string> cardsInDeck;

	// Use this for initialization
	void Start () {
		//Random rand = new Random();
		MyCardsHolder = GameObject.Find ("Hand");
		print ("MyCardsHolder is " + MyCardsHolder.name);

		availableCards = new List<string>(){"Prefabs/Card01","Prefabs/Card02","Prefabs/Card03","Prefabs/Card04","Prefabs/Card05"};
		cardsInDeck = new List<string> ();
		for (int i = 0; i < maxCards; i++) {
			int rand = Random.Range(0,availableCards.Count);
			cardsInDeck.Add(availableCards[rand]);
		}

		for (int i = 0; i < 5; i++) {
			GameObject prefab = (GameObject)Resources.Load (availableCards[i]);
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
	
	}
}
