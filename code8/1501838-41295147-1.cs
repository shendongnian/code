    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.EventSystems;
    using UnityEngine.UI;
    public class Button2 : Button
    {
        public bool PreventPropagationOnLongPress;
        public override void OnPointerClick(PointerEventData eventData)
        {
            var longPress = GetComponent<LongPressButton>();
            if (longPress == null)
            {
                base.OnPointerClick(eventData);
            }
            if(false == longPress.WasLongPressTriggered)
            {
                base.OnPointerClick(eventData);
            }
        }
    }
