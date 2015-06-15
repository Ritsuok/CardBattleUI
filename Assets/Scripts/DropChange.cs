using UnityEngine;
using System.Collections;

using UnityEngine.EventSystems;
//using UnityEngine.UI;

// NEXT STEP! make draggable obeject'S return place(parent) to be more simple!

public class DropChange : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler {
	
	public Draggable.Slot typeOfItem = Draggable.Slot.INVENTORY;
	GameObject target;

	public bool childIs = false;

	//HorizontalLayoutGroup layoutLock;

	void Awake(){
		print("DropChange Start");
		foreach(Transform child in transform) {
			//Debug.Log(child.name + ":" + child.localPosition);
			target = child.gameObject;
			//Debug.Log("layoutLock.enabled = " + layoutLock.enabled);
			//layoutLock.enabled = false;
			if(target != null){
				childIs = true;
				Debug.Log(target.name + " is " + childIs);
			}else{
				childIs = false;
				Debug.Log(target.name + " is " + childIs);
			}
			
		}
	}
	void Update(){
	}
	
	public void OnPointerEnter(PointerEventData eventData){
		if (eventData .pointerDrag == null) {
			return;
		}
		Draggable d = eventData.pointerDrag.GetComponent<Draggable> ();

		if (d != null) {
			//find child objects of this
			foreach(Transform child in transform) {
				//Debug.Log(child.name + ":" + child.localPosition);
				target = child.gameObject;
				//Debug.Log("layoutLock.enabled = " + layoutLock.enabled);
				//layoutLock.enabled = false;
				if(target != null){
					childIs = true;
					Debug.Log("OnPointerEnter child is " + childIs);
				}else{
					childIs = false;
					Debug.Log("OnPointerEnter child is " + childIs);
				}

			}
		}

	}
	
	public void OnPointerExit(PointerEventData eventData){
		if (eventData .pointerDrag == null) {
			return;
		}
		Draggable d = eventData.pointerDrag.GetComponent<Draggable> ();
		if (d != null && d.placeholderParent == this.transform) {
			//layoutLock.enabled = true;
			//target.transform.SetParent(this.transform);
			d.placeholderParent = d.parentToReturnTo;

			childIs =false;
			Debug.Log("OnPointerExit child is " + childIs);
		}
		if(target != null){
			target.transform.SetParent(this.transform);

			childIs = true;
			Debug.Log("OnPointerExit child is " + childIs);
		}

	}
	
	public void OnDrop(PointerEventData eventData){
		//Debug.Log (eventData.pointerDrag.name + "was dropped to " + gameObject.name);
		
		Draggable d = eventData.pointerDrag.GetComponent<Draggable> ();
		if (d != null) {
			if(typeOfItem == d.typeOfItem || typeOfItem == Draggable.Slot.INVENTORY){
				// placeholder's parent will be changed to this object
				d.placeholderParent = this.transform;
				//layoutLock.enabled = true;


				//d.parentToReturnTo = this.transform;
				d.transform.SetParent(this.transform);

				childIs = true;
				Debug.Log("OnPointerExit child is " + childIs);
			}
		}
		if(target != null){
			target.transform.SetParent(d.parentToReturnTo);

			childIs =false;
			Debug.Log("OnPointerExit child is " + childIs);
		}
	}
}