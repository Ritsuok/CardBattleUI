﻿using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler {

	public Draggable.Slot typeOfItem = Draggable.Slot.INVENTORY;



	public void OnPointerEnter(PointerEventData eventData){
		if (eventData .pointerDrag == null) {
			return;
		}
		Draggable d = eventData.pointerDrag.GetComponent<Draggable> ();
		if (d != null) {

			d.placeholderParent = this.transform;

		}
	}

	public void OnPointerExit(PointerEventData eventData){
		if (eventData .pointerDrag == null) {
			return;
		}
		Draggable d = eventData.pointerDrag.GetComponent<Draggable> ();
		if (d != null && d.placeholderParent == this.transform) {
			
			d.placeholderParent = d.parentToReturnTo;


		}
	}

	public void OnDrop(PointerEventData eventData){
		//Debug.Log (eventData.pointerDrag.name + "was dropped to " + gameObject.name);

		Draggable d = eventData.pointerDrag.GetComponent<Draggable> ();
		if (d != null) {
			if(typeOfItem == d.typeOfItem || typeOfItem == Draggable.Slot.INVENTORY){
				d.parentToReturnTo = this.transform;


			}
		}
	}
}
