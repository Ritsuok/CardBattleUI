using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Points : MonoBehaviour {

	public Text costText;
	public Text attackText;
	public Text defenceText;
	
	public int costPoint = 3;
	public int attackPoint = 8;
	public int defencePoint = 10;



	// Use this for initialization
	void Start () {
		//costText = GameObject.Find ("costpoint");

		costText.text = costPoint.ToString();
		attackText.text = attackPoint.ToString();
		defenceText.text = defencePoint.ToString();
		/*
		costText.GetComponents<TextMesh> ().text = costPoint;
		attackText.GetComponents<TextMesh> ().text = attackPoint;
		defenceText.GetComponents<TextMesh> ().text = defencePoint;
*/
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void setPointonCard(){
		costText.text = costPoint.ToString();
		attackText.text = attackPoint.ToString();
		defenceText.text = defencePoint.ToString();
	}
}
