using UnityEngine;
using UnityEngine.UI;
using System.Collections;
//to use Events
using UnityEngine.EventSystems;

//need to handlers to be implemant
public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

	public Transform parentToReturnTo = null;
	public Transform placeholderParent = null;

	GameObject placeholder = null;

	public enum Slot{ WEAPON, HEAD, CHEST, LEGS, FEET, INVENTORY };
	public Slot typeOfItem = Slot.WEAPON;

	//when this GameObject is begining drag
	public void OnBeginDrag(PointerEventData eventData){

		placeholder = new GameObject ();
		placeholder.transform.SetParent (this.transform.parent);
		LayoutElement le = placeholder.AddComponent<LayoutElement> ();
		le.preferredWidth = this.GetComponent<LayoutElement> ().preferredWidth;
		le.preferredHeight = this.GetComponent<LayoutElement> ().preferredHeight;
		le.flexibleWidth = 0;
		le.flexibleHeight = 0;

		//Change the index number of Hierarchy
		placeholder.transform.SetSiblingIndex (this.transform.GetSiblingIndex ());

		//Debug.Log ("OnBeginDrag");
		parentToReturnTo = this.transform.parent;
		placeholderParent = parentToReturnTo;
		this.transform.SetParent (this.transform.parent.parent);

		GetComponent<CanvasGroup> ().blocksRaycasts = false;
	}

	//when this GameObject is dragging
	public void OnDrag(PointerEventData eventData){
		//Debug.Log ("OnDrag");
		this.transform.position = eventData.position;

		if (placeholder.transform.parent != placeholderParent) {
			placeholder.transform.SetParent (placeholderParent);
		}

		int newSiblingIndex = placeholderParent.childCount;

		for (int i = 0; i < placeholderParent.childCount; i++) {
			if (this.transform.position.x < placeholderParent.GetChild (i).position.x) {

				newSiblingIndex = i;
				if (placeholder.transform.GetSiblingIndex () < newSiblingIndex)
					newSiblingIndex -= 1;
				//Debug.Log ( "In if placeholder's index is " + newSiblingIndex);
				break;






			}

		}
		placeholder.transform.SetSiblingIndex (newSiblingIndex);
		//Debug.Log ( "placeholder's index is " + newSiblingIndex);

	}

	public void OnEndDrag(PointerEventData eventData){
		//Debug.Log ("OnEndDrag");
		this.transform.SetParent (placeholderParent);
		//Get the index number of Hiearchy of the placeHolder and set this there
		this.transform.SetSiblingIndex (placeholder.transform.GetSiblingIndex ());

		GetComponent<CanvasGroup> ().blocksRaycasts = true;

		Destroy (placeholder);
	}
}
