    using UnityEngine;
    using UnityEngine.EventSystems;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace TFTM.Event
    {
    	public enum EventExecuteType
    	{
    		PointerEnter,
    		PointerExit,
    		PointerDown,
    		PointerUp,
    		PointerDrag,
    	}
    
    	public abstract class OverlapEventTrigger : EventTrigger, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler, IDragHandler
	    {
		public virtual void MouseDown(PointerEventData eventData){}
		public virtual void MouseUp(PointerEventData eventData){}
		public virtual void MouseEnter(PointerEventData eventData){}
		public virtual void MouseExit(PointerEventData eventData){}
		public virtual void MouseDrag(PointerEventData eventData){}
		List<GameObject> ObjectsInCollider = new List<GameObject>();
		public List<RaycastResult> lastTotalRaycastResult = new List<RaycastResult>();
		public override void OnPointerDown(PointerEventData eventData)
		{
			Debug.Log("Down: " + eventData.pointerCurrentRaycast.gameObject.name);
			MouseDown(eventData);
			rethrowRaycast(eventData, eventData.pointerCurrentRaycast.gameObject, EventExecuteType.PointerDown);
		}
		public override void OnPointerUp(PointerEventData eventData)
		{
			Debug.Log("Up: " + eventData.pointerCurrentRaycast.gameObject.name);
			MouseUp(eventData);
			rethrowRaycast(eventData, eventData.pointerCurrentRaycast.gameObject, EventExecuteType.PointerUp);
		}
		public override void OnPointerEnter(PointerEventData eventData)
		{
			if (IsPointerInsideCollider(eventData) && ObjectsInCollider.Contains(gameObject))
				return;
			Debug.Log("Enter: " + eventData.pointerCurrentRaycast.gameObject.name);
			MouseEnter(eventData);
			ObjectsInCollider.Add(gameObject);
		}
		public override void OnPointerExit(PointerEventData eventData)
		{
			//Debug.Log("Is " + gameObject.name + " inside his respective collider : " + IsPointerInsideCollider(eventData));
			if (IsPointerInsideCollider(eventData))
				return;
			Debug.Log("Exit: " + gameObject.name);
			MouseExit(eventData);
			ObjectsInCollider.Remove(gameObject);
		}
		public override void OnDrag(PointerEventData eventData)
		{
			//Debug.Log("Drag: " + eventData.pointerCurrentRaycast.gameObject.name);
			MouseDrag(eventData);
			rethrowRaycast(eventData, eventData.pointerCurrentRaycast.gameObject, EventExecuteType.PointerDrag);
		}
		bool IsPointerInsideCollider(PointerEventData eventData)
		{
			PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
			pointerEventData.position = eventData.position;
			List<RaycastResult> raycastResult = new List<RaycastResult>();
			EventSystem.current.RaycastAll(pointerEventData, raycastResult);
			for (int i = 0; i < raycastResult.Count; i++)
			{
				if (raycastResult[i].gameObject == gameObject)
				{
					return true;
				}
			}
			return false;
		}
		void rethrowRaycast(PointerEventData eventData, GameObject excludeGameObject, EventExecuteType eventType)
		{
			PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
			pointerEventData.position = eventData.pressPosition;
			//pointerEventData.position = eventData
			//Where to store Raycast Result
			List<RaycastResult> raycastResult = new List<RaycastResult>();
			//Rethrow the raycast to include everything regardless of their Z position
			EventSystem.current.RaycastAll(pointerEventData, raycastResult);
			//Debug.Log("Other GameObject hit");
			for (int i = 0; i < raycastResult.Count; i++)
			{
				//Debug.Log(raycastResult[i].gameObject.name);
				//Don't Rethrow Raycayst for the first GameObject that is hit
				if (excludeGameObject != null && raycastResult[i].gameObject != excludeGameObject || eventType == EventExecuteType.PointerDrag)
				{
					//Re-simulate OnPointerDown on every Object hit
					simulateCallbackFunction(raycastResult[i].gameObject, eventType);
				}
			}
		}
		//This causes functions such as OnPointerDown to be called again
		void simulateCallbackFunction(GameObject target, EventExecuteType eventType)
		{
			PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
			//pointerEventData.ra
			RaycastResult res = new RaycastResult();
			res.gameObject = target;
			pointerEventData.pointerCurrentRaycast = res;
			pointerEventData.position = Input.mousePosition;
			switch (eventType) {
				case EventExecuteType.PointerDown:
					ExecuteEvents.Execute(target, pointerEventData, ExecuteEvents.pointerDownHandler);
					break;
				case EventExecuteType.PointerUp:
					ExecuteEvents.Execute(target, pointerEventData, ExecuteEvents.pointerUpHandler);
					break;
				case EventExecuteType.PointerDrag:
					ExecuteEvents.Execute(target, pointerEventData, ExecuteEvents.dragHandler);
					break;
				default:
					break;
			}
		}
	
    }
