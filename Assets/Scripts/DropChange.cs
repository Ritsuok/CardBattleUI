using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropChange : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler {
	
	public Draggable.Slot typeOfItem = Draggable.Slot.INVENTORY;
	GameObject target;
	Transform parentReturnTable = null;
	HorizontalLayoutGroup layoutLock;

	void Sart(){
		layoutLock = GetComponent<HorizontalLayoutGroup> ();
	}

	
	public void OnPointerEnter(PointerEventData eventData){
		if (eventData .pointerDrag == null) {
			return;
		}
		parentReturnTable = this.transform.parent;
		Draggable d = eventData.pointerDrag.GetComponent<Draggable> ();
		if (d != null) {
			foreach(Transform child in transform) {
				Debug.Log(child.name + ":" + child.localPosition);
				target = child.gameObject;
				layoutLock.enabled = false;
			}

			d.placeholderParent = this.transform;
			
		}
	}
	
	public void OnPointerExit(PointerEventData eventData){
		if (eventData .pointerDrag == null) {
			return;
		}
		Draggable d = eventData.pointerDrag.GetComponent<Draggable> ();
		if (d != null && d.placeholderParent == this.transform) {
			target.transform.SetParent(parentReturnTable);
			d.placeholderParent = d.parentToReturnTo;
			layoutLock.enabled = true;
		}
	}
	
	public void OnDrop(PointerEventData eventData){
		//Debug.Log (eventData.pointerDrag.name + "was dropped to " + gameObject.name);
		
		Draggable d = eventData.pointerDrag.GetComponent<Draggable> ();
		if (d != null && target != null) {
			if(typeOfItem == d.typeOfItem || typeOfItem == Draggable.Slot.INVENTORY){
				layoutLock.enabled = true;
				target.transform.SetParent(d.parentToReturnTo);
				d.parentToReturnTo = this.transform;
			}
		}
	}
}