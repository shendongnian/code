    using UnityEngine;
    using UnityEngine.EventSystems;
    using System.Linq;
    using System.Collections.Generic;
    public class MultitouchHandler : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler {
        public List<Finger> Fingers = new List<Finger>();
        public List<FingerCombination> FingerCombinations = new List<FingerCombination>();
        public FingerCombination GetFingerCombination(params int[] fingerIndices) {
            var fc = FingerCombinations.Find(x => x.IDs.Count == fingerIndices.Length && fingerIndices.All(y => x.IDs.Contains(Fingers[y].ID)));
            if (fc != null) return fc;
            fc = new FingerCombination() {
                Fingers = fingerIndices.Select(x => Fingers[x]).ToList()
            };
            fc.IDs = fc.Fingers.Select(x => x.ID).ToList();
            fc.Data = Fingers.Select(x => x.Data).ToList();
            fc.PreviousData = Fingers.Select(x => x.Data).ToList();
            FingerCombinations.Add(fc);
            return fc;
        }
        public delegate void MultitouchEventHandler(int touchCount, MultitouchHandler sender);
        public event MultitouchEventHandler OnFingerAdded;
        public event MultitouchEventHandler OnFingerRemoved;
        public void OnDrag(PointerEventData eventData) {
            var finger = Fingers.Find(x => x.ID == eventData.pointerId);
            var fcs = FingerCombinations.Where(x => x.IDs.Contains(eventData.pointerId));
            finger.PreviousData = finger.Data;
            finger.Data = eventData;
            foreach (var fc in fcs) {
                fc.PreviousData = fc.Data;
                fc.Data = fc.Fingers.Select(x => x.Data).ToList();
                fc.PreviousGesture = fc.Gesture;
                fc.Gesture = new Gesture() {
                    Center = fc.Center,
                    Size = fc.Size,
                    Angle = fc.Angle,
                    SizeDelta = 1
                };
                if (fc.PreviousGesture != null) {
                    fc.Gesture.CenterDelta = fc.Center - fc.PreviousGesture.Center;
                    fc.Gesture.SizeDelta = fc.Size / fc.PreviousGesture.Size;
                    fc.Gesture.AngleDelta = fc.Angle - fc.PreviousGesture.Angle;
                }
                fc.Changed();
            }
        }
        public void OnPointerDown(PointerEventData eventData) {
            var finger = new Finger() { ID = eventData.pointerId, Data = eventData };
            Fingers.Add(finger);
            if (OnFingerAdded != null)
                OnFingerAdded(Fingers.Count, this);
        }
        public void OnPointerUp(PointerEventData eventData) {
            Fingers.RemoveAll(x => x.ID == eventData.pointerId);
            if (OnFingerRemoved != null)
                OnFingerRemoved(Fingers.Count, this);
            var fcs = FingerCombinations.Where(x => x.IDs.Contains(eventData.pointerId));
            foreach (var fc in fcs) {
                fc.Finished();
            }
            FingerCombinations.RemoveAll(x => x.IDs.Contains(eventData.pointerId));
        }
        public class Finger {
            public int ID;
            public PointerEventData Data;
            public PointerEventData PreviousData;
        }
        public class FingerCombination {
            public List<int> IDs = new List<int>();
            public List<Finger> Fingers;
            public List<PointerEventData> PreviousData;
            public List<PointerEventData> Data;
            public delegate void GestureEventHandler(Gesture gesture, FingerCombination sender);
            public event GestureEventHandler OnChange;
            public delegate void GestureEndHandler(FingerCombination sender);
            public event GestureEndHandler OnFinish;
            public Gesture Gesture;
            public Gesture PreviousGesture;
            public Vector2 Center
            {
                get { return Data.Aggregate(Vector2.zero, (x, y) => x + y.position) / Data.Count; }
            }
            public float Size
            {
                get
                {
                    if (Data.Count == 1) return 0;
                    var magnitudeSum = 0f;
                    for (int i = 1; i < Data.Count; i++) {
                        var dif = (Data[i].position - Data[0].position);
                        magnitudeSum += dif.magnitude;
                    }
                    return magnitudeSum / (Data.Count - 1);
                }
            }
            public float Angle
            {
                get
                {
                    if (Data.Count == 1) return 0;
                    var angleSum = 0f;
                    for (int i = 1; i < Data.Count; i++) {
                        var dif = (Data[i].position - Data[0].position);
                        angleSum += Mathf.Atan2(dif.y, dif.x) * Mathf.Rad2Deg;
                    }
                    return angleSum / (Data.Count - 1);
                }
            }
            internal void Changed() {
                if (OnChange != null)
                    OnChange.Invoke(Gesture, this);
            }
            internal void Finished() {
                if (OnFinish != null)
                    OnFinish.Invoke(this);
            }
        }
        public class Gesture {
            public Vector2 Center;
            public float Size;
            public float Angle;
            public Vector2 CenterDelta;
            public float SizeDelta;
            public float AngleDelta;
        }
    }
