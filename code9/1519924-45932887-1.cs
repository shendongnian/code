	public class Pan : MonoBehaviour
	{
		public float Speed;
		Vector3 startDragPosition;
		public void BeginDrag ()
		{
			startDragPosition = Input.mousePosition;
		}
		public void Drag ()
		{
			transform.localPosition += (Input.mousePosition - startDragPosition) * Speed;
			startDragPosition = Input.mousePosition;
			ValidatePosition ();
		}
		public void ValidatePosition ()
		{
			var temp = transform.localPosition;
			var width = ((RectTransform)transform).sizeDelta.x;
			var height = ((RectTransform)transform).sizeDelta.y;
			var MaxX = width * Mathf.Max (0, transform.localScale.x - 1) / 2;
			var MaxY = height * Mathf.Max (0, transform.localScale.y - 1) / 2;
			if (temp.x < -MaxX)
				temp.x = -MaxX;
			else if (temp.x > MaxX)
				temp.x = MaxX;
			if (temp.y < -MaxY)
				temp.y = -MaxY;
			else if (temp.y > MaxY)
				temp.y = MaxY;
			transform.localPosition = temp;
		}
	}
