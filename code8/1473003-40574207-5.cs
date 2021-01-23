    using UnityEngine;
    using System.Collections.Generic;
    using System.Linq;
    public class MultiTouchTest : MonoBehaviour {
        public Vector2 rectSize = Vector2.one * 2;
        public Vector2 skewedRectSize = Vector2.one;
        public Vector2 rectPos = Vector2.zero;
        public List<Vector3> Fingers = new List<Vector3>();
        void Start() {
            var h = GetComponent<MultitouchHandler>();
            h.OnFingerAdded += OnGestureStart;
        }
        private void OnGestureStart(int touchCount, MultitouchHandler sender) {
            if (touchCount != 4) return;
            var fc = sender.GetFingerCombination(0, 1, 2, 3);
            fc.OnChange += OnGesture;
        }
        private void OnGesture(MultitouchHandler.Gesture gesture, MultitouchHandler.FingerCombination sender) {
            rectSize *= gesture.SizeDelta;
            Fingers = sender.Fingers.Select(x => Camera.main.ScreenToWorldPoint(x.Data.position)).ToList();
            var tan = Mathf.Tan(gesture.Angle * Mathf.Deg2Rad);
            skewedRectSize = new Vector2(rectSize.x / tan, rectSize.y * tan);
            rectPos += gesture.CenterDelta / 50;
        }
        public void OnDrawGizmos() {
            Gizmos.color = Color.red;
            Gizmos.DrawCube(rectPos, skewedRectSize);
            Gizmos.color = Color.blue;
            foreach (var finger in Fingers) Gizmos.DrawSphere(finger + Vector3.forward, 0.5f);
        }
    }
