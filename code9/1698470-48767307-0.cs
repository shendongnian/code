	using UnityEngine;
	using UnityEngine.EventSystems;
	public class ScaleExample : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
		private Vector2 startPosition;
		private float scalingFactor = .01f;
		private bool isObjectAlreadyScaled = false;
		public void OnBeginDrag(PointerEventData eventData) {
			startPosition = Vector2.zero;
		}
		public void OnDrag(PointerEventData eventData) {
			if (!isObjectAlreadyScaled) {
				startPosition += eventData.delta;
				var scalingAmount = new Vector2(Mathf.Abs(startPosition.x), Mathf.Abs(startPosition.y));
				transform.localScale = (Vector3)scalingAmount * scalingFactor;
			}
		}
		public void OnEndDrag(PointerEventData eventData) {
			isObjectAlreadyScaled = true;
		}
	}
