    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Events;
    using UnityEngine.EventSystems;
    public class TouchEventTrigger : MonoBehaviour, IPointerClickHandler,   IPointerDownHandler, IPointerUpHandler {
	public TouchEvent onClick;
	public TouchEvent onDown;
	public TouchEvent onUp;
	public void OnPointerClick(PointerEventData e) {
		onClick.Invoke(e);
	}
	public void OnPointerDown(PointerEventData e) {
		onDown.Invoke(e);
	}
	public void OnPointerUp(PointerEventData e) {
		onUp.Invoke(e);
	}
    }
    [System.Serializable]
    public class TouchEvent : UnityEvent<PointerEventData> {}
