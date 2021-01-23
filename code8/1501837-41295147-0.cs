    using UnityEngine;
    using UnityEngine.Events;
    using UnityEngine.EventSystems;
    using System.Collections;
    using UnityEngine.UI;
    public class LongPressButton : UIBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
    {
        [Tooltip("How long must pointer be down on this object to trigger a long press")]
        public float durationThreshold = 1.0f;
        public UnityEvent onLongPress = new UnityEvent(); 
        private bool isPointerDown = false;
        private bool longPressTriggered = false;
        private float timePressStarted;
        public bool WasLongPressTriggered
        {
            get;
            protected set;
        }
        private void Update()
        {
            if (isPointerDown && false == longPressTriggered)
            {
                if (Time.time - timePressStarted > durationThreshold)
                {
                    longPressTriggered = true;
                    WasLongPressTriggered = true;
                    onLongPress.Invoke();
                }
            }
        }
        public void OnPointerDown(PointerEventData eventData)
        {
            timePressStarted = Time.time;
            isPointerDown = true;
            longPressTriggered = false;
            WasLongPressTriggered = false;
        }
        public void OnPointerUp(PointerEventData eventData)
        {
            isPointerDown = false;
        }
        public void OnPointerExit(PointerEventData eventData)
        {
            isPointerDown = false;
        }
    }
