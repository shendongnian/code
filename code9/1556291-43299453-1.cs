	public GameObject TargetObject { get; private set; }
	public override void OnPointerEnter(GameObject targetObject, Vector3 intersectionPosition,
	  Ray intersectionRay, bool isInteractive) {
	#if UNITY_HAS_GOOGLEVR && (UNITY_ANDROID || UNITY_EDITOR)
		TargetObject = targetObject;
		PointerIntersection = intersectionPosition;
		PointerIntersectionRay = intersectionRay;
	IsPointerIntersecting = true;
	#endif  // UNITY_HAS_GOOGLEVR && (UNITY_ANDROID || UNITY_EDITOR)
	}
	public override void OnPointerExit(GameObject targetObject) {
	#if UNITY_HAS_GOOGLEVR && (UNITY_ANDROID || UNITY_EDITOR)
		TargetObject = null;
		PointerIntersection = Vector3.zero;
		PointerIntersectionRay = new Ray();
		IsPointerIntersecting = false;
	#endif  // UNITY_HAS_GOOGLEVR && (UNITY_ANDROID || UNITY_EDITOR)
	}
