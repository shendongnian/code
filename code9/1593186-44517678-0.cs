    public class UIDraggable : MonoBehaviour, IDragHandler {
	#region IDragHandler implementation
	public void OnDrag (PointerEventData eventData)
	{
		this.transform.position += (Vector3)eventData.delta;
	}
	#endregion
    }
