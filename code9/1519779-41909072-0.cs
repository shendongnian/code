    public class DragMe : MonoBehaviour, IBeginDragHandler, IPointerUpHandler
    {
    	private bool isDragging = false;
    
    
    	public void OnBeginDrag(PointerEventData data)
    	{
    		this.isDragging = true;
    	}
        public void OnPointerUp(PointerEventData eventData)
        {
           if(this.isDragging == false){ Invoke();}
           this.isDragging = false;
        }
    }
