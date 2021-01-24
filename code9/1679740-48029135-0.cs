    using UnityEngine;
    using UnityEngine.UI;
    using UnityEngine.EventSystems;
    
    public class DragHandler : MonoBehaviour,
        IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        public void OnDrag(PointerEventData eventData)
        {
            CanvasScaler scaler = GetComponentInParent<CanvasScaler>();
            Vector3 i_scale = itemBeingDragged.transform.localScale;
            RectTransform rt = itemBeingDragged.GetComponent<RectTransform>();
            Rect r = rt.rect;
            /**
             * Explanation: to center the object we need its width+height:
             * Resize width to the current scale = r.width * i_scale.x 
             * Divide by 2 to get the center we have: (r.width * i_scale.x / 2)
             * Same for y.
             * 
             * Calculate the coords of the mouse proportional to the screen scale:
             */
            rt.anchoredPosition = new Vector2(
                (Input.mousePosition.x * scale_x) - (r.width * i_scale.x / 2),
                (Input.mousePosition.y * scale_y) - (r.height * i_scale.y / 2));
            // everybody tells me to apply this but it doesn't work:
            // itemBeingDragged.GetComponent<CanvasGroup>().blocksRaycasts = true;
        }
    
    }
