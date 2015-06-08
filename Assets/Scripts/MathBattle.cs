using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MathBattle : MonoBehaviour {

	private GameObject E_DP_Field;
	private Text E_DP_Text;
	private GameObject H_AP_Field;
	private Text H_AP_Text;
	private GameObject answerField;
	private Text answerText;

	private GameObject number0;
	private GameObject number1;
	private GameObject number2;
	private GameObject number3;
	private GameObject number4;
	private GameObject number5;
	private GameObject number6;
	private GameObject number7;
	private GameObject number8;
	private GameObject number9;

	private int answerNumber;




	// Use this for initialization
	void Start () {
		// Find GameObjects
		E_DP_Field = GameObject.Find ("EnemyPanel");
		//E_DP_Text = E_DP_Field.transform.GetChild (0).gameObject;
		//Debug.Log ("text of E DP is " + E_DP_Text.text);
		H_AP_Field = GameObject.Find ("HomePanel");
		//H_AP_Text = H_AP_Field.transform.GetChild (0).gameObject;
		//Debug.Log ("text of H AP is " + H_AP_Text.text);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
