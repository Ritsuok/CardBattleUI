using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MathBattle : MonoBehaviour {
	// Field TurnEnd Class
	TurnEnd turnend;


	private GameObject E_DP_Field;
	private GameObject E_DP_TextObj;
	private Text E_DP_Text;
	private GameObject H_AP_Field;
	private Text H_AP_Text;
	private GameObject H_AP_TextObj;
	private GameObject answerField;
	private GameObject answerTextObj;
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

	public string numAll = "";


	// Use this for initialization
	void Start () {

		turnend = new TurnEnd ();
		// Find GameObjects
		E_DP_Field = GameObject.Find ("EnemyPanel");
		Debug.Log ("E_DP_Field name is " + E_DP_Field.name);
		/*
		Text target = null;
		foreach (Transform child in E_DP_Field.transform){
			if(child.name == "Text"){
				target = child.gameObject.GetComponent<Text>();
				target.text = "AA";
			} else if (child.name == "Sub Title") {
				target = child.gameObject.GetComponent<Text>();
				target.text = "BBBBBBB";
			}
		}
*/
		//E_DP_TextObj = E_DP_TextObj.transform.GetChild (0).gameObject;
		E_DP_TextObj = E_DP_Field.transform.FindChild ("Text").gameObject;
		E_DP_Text = E_DP_TextObj.GetComponent<Text>();
		E_DP_Text.text = "AA";
		Debug.Log ("text of E DP is " + E_DP_Text.text);

		H_AP_Field = GameObject.Find ("HomePanel");
		H_AP_TextObj = H_AP_Field.transform.FindChild ("Text").gameObject;
		H_AP_Text = H_AP_TextObj.GetComponent<Text>();
		H_AP_Text.text = "BB";
		//Debug.Log ("text of H AP is " + H_AP_Text.text);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
/*	void getE_DPText(){
		E_DP_Field = GameObject.Find ("EnemyPanel");
		E_DP_TextObj = E_DP_Field.transform.FindChild ("Text").gameObject;
		E_DP_Text = E_DP_TextObj.GetComponent<Text>();
	}
*/
	void getAnswerText(){
		answerField = GameObject.Find ("AnswerPanel");
		answerTextObj = answerField.transform.FindChild ("Text").gameObject;
		answerText = answerTextObj.GetComponent<Text>();
	}

	public void inputDPAP(int DP, int AP){
		E_DP_Field = GameObject.Find ("EnemyPanel");
		E_DP_TextObj = E_DP_Field.transform.FindChild ("Text").gameObject;
		E_DP_Text = E_DP_TextObj.GetComponent<Text>();
		E_DP_Text.text = DP.ToString();

		H_AP_Field = GameObject.Find ("HomePanel");
		H_AP_TextObj = H_AP_Field.transform.FindChild ("Text").gameObject;
		H_AP_Text = H_AP_TextObj.GetComponent<Text>();
		H_AP_Text.text = AP.ToString();

		numAll = "";
	}

	public void inputAnswer(string touchedNum){
		print ("touchedNum is " + touchedNum);

		getAnswerText ();

		if (answerText.text == "00") {
			numAll = "";
		} else {
			numAll = answerText.text;
		}
		numAll = numAll + touchedNum;
		answerText.text = numAll;
		print ("answerText.text = " + answerText.text);
	}

	public void enterBtn(){
		getAnswerText ();
		print("enterBtn numAll = " + answerText.text);
		//getE_DPText ();
		print ("enterBtn E_DP_Text.text = " + E_DP_Text.text);
		print ("enterBtn H_AP_Text.text = " + H_AP_Text.text);

		if (int.Parse(answerText.text) == int.Parse(E_DP_Text.text) - int.Parse(H_AP_Text.text)) {
			print ("GOOD!");
			turnend.firstBattle(true);
		} else {
			print ("Wrong!");
			turnend.firstBattle(false);
		}
	}

	public void testMethod(string A){
		Debug.Log (A);
	}
}
