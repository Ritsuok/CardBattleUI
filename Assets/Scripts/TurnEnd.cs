using UnityEngine;
using System.Collections;

public class TurnEnd : MonoBehaviour {
	// BattlClass
	Battle battle;

	private GameObject H1;
	
	// Use this for initialization
	void Start () {
		// Find H1
		H1 = GameObject.Find ("TabletopH1");
		Debug.Log ("H1 = " + H1.name);
		// Get BattleClass
		battle = H1.GetComponent<Battle> ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// do when this is clicked
	public void isClicked(){
		Debug.Log ("I'm Clicked");
		battle.attack ();
	}

}
