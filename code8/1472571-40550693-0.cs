    public class Screen : MonoSingleton<Screen>, IPointerClickHandler, IDragHandler, IBeginDragHandler, IEndDragHandler, IPointerDownHandler, IPointerUpHandler, IScrollHandler {
        private bool holding = false;
        private PointerEventData lastPointerEventData;
        #region Events
        public delegate void PointerEventHandler(PointerEventData data);
        static public event PointerEventHandler OnPointerClick = delegate { };
        static public event PointerEventHandler OnPointerDown = delegate { };
        /// <summary> Dont use delta data as it will be wrong. If you are going to use delta, use OnDrag instead. </summary>
        static public event PointerEventHandler OnPointerHold = delegate { };
        static public event PointerEventHandler OnPointerUp = delegate { };
        static public event PointerEventHandler OnBeginDrag = delegate { };
        static public event PointerEventHandler OnDrag = delegate { };
        static public event PointerEventHandler OnEndDrag = delegate { };
        static public event PointerEventHandler OnScroll = delegate { };
        #endregion
        #region Interface Implementations
        void IPointerClickHandler.OnPointerClick(PointerEventData e) {
            lastPointerEventData = e;
            OnPointerClick(e);
        }
        
        // And other interface implementations, you get the point
        #endregion
        void Update() {
            if (holding) {
                OnPointerHold(lastPointerEventData);
            }
        }
    }
