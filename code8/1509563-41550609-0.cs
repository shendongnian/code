    using UnityEngine.EventSystems;    
      public class ColorPicker : MonoBehaviour, IPointerClickHandler{
    
      public GameObject Cube;
    
      void OnPointerClick(PointerEventData eventData)
      {
         //eventData.position
         //Vector3 localPosition = transform.InverseTransformPoint(eventData.pressPosition);
         //ignore z coordinate
      }
    }
