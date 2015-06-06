using UnityEngine;
using System.Collections;

using UnityEngine.EventSystems;
//using UnityEngine.UI;

// NEXT STEP! make draggable obeject'S return place(parent) to be more simple!

public class DropChange : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler {
	
	public Draggable.Slot typeOfItem = Draggable.Slot.INVENTORY;
	GameObject target;

	//HorizontalLayoutGroup layoutLock;

/*	void Sart(){
		//layoutLock = GetComponent<HorizontalLayoutGroup> ();
		//layoutLock.enabled = false;

	}
*/
	
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


		}
		if(target != null){
			target.transform.SetParent(this.transform);
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
			}
		}
		if(target != null){
			target.transform.SetParent(d.parentToReturnTo);
		}
	}
}