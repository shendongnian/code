    using UnityEngine;
    using System.Collections;
    using UnityEngine.EventSystems;
    using UnityEngine.UI;
    using System.Collections.Generic;
    
    public class ButtonDownRelease : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        List<ButtonInfo> buttonInfo = new List<ButtonInfo>();
    
        public delegate void ButtonActionChange(ButtonAction buttonAction);
        public static event ButtonActionChange OnButtonActionChanged;
    
        // Update is called once per frame
        void Update()
        {
            //Send Held Button Down events
            for (int i = 0; i < buttonInfo.Count; i++)
            {
                if (buttonInfo[i].buttonPresed == ButtonAction.DecreaseButtonDown)
                {
                    dispatchEvent(ButtonAction.DecreaseButtonDown);
                }
    
                else if (buttonInfo[i].buttonPresed == ButtonAction.IncreaseButtonDown)
                {
                    dispatchEvent(ButtonAction.IncreaseButtonDown);
                }
            }
        }
    
        void dispatchEvent(ButtonAction btAction)
        {
            if (OnButtonActionChanged != null)
            {
                OnButtonActionChanged(btAction);
            }
        }
    
        public void OnPointerDown(PointerEventData eventData)
        {
            //Debug.Log("Button Down!");
            ButtonInfo bInfo = new ButtonInfo();
            bInfo.uniqueId = eventData.pointerId;
            if (eventData.pointerCurrentRaycast.gameObject.CompareTag("increase"))
            {
                bInfo.buttonPresed = ButtonAction.IncreaseButtonDown;
                addButton(bInfo);
            }
            else if (eventData.pointerCurrentRaycast.gameObject.CompareTag("decrease"))
            {
                bInfo.buttonPresed = ButtonAction.DecreaseButtonDown;
                addButton(bInfo);
            }
        }
    
        public void OnPointerUp(PointerEventData eventData)
        {
            //Debug.Log("Button Down!" + eventData.pointerCurrentRaycast);
            removeButton(eventData.pointerId);
        }
    
        void addButton(ButtonInfo bInfo)
        {
            buttonInfo.Add(bInfo);
        }
    
        void removeButton(int unqID)
        {
            for (int i = 0; i < buttonInfo.Count; i++)
            {
                if (unqID == buttonInfo[i].uniqueId)
                {
                    //Send Release Button Up events
                    if (buttonInfo[i].buttonPresed == ButtonAction.DecreaseButtonDown)
                    {
                        dispatchEvent(ButtonAction.DecreaseButtonUp);
                    }
    
                    else if (buttonInfo[i].buttonPresed == ButtonAction.IncreaseButtonDown)
                    {
                        dispatchEvent(ButtonAction.IncreaseButtonUp);
                    }
                    buttonInfo.RemoveAt(i);
                }
            }
    
        }
    
        public struct ButtonInfo
        {
            public int uniqueId;
            public ButtonAction buttonPresed;
        }
    }
    
    public enum ButtonAction
    {
        None,
        IncreaseButtonDown, IncreaseButtonUp,
        DecreaseButtonDown, DecreaseButtonUp
    }
