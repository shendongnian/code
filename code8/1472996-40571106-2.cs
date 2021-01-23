    public class PointerCounterEventData : BaseEventData
    {
        //The callback with int parameter 
        public static readonly ExecuteEvents.EventFunction<IPointerCounterHandler> counterChangedV1Delegate
        = delegate (IPointerCounterHandler handler, BaseEventData data)
        {
            //var casted = ExecuteEvents.ValidateEventData<PointerCounterEventData>(data);
            handler.OnPointerCounterChanged(touchCount);
        };
    
        //The callback with PointerCounterEventData parameter
        public static readonly ExecuteEvents.EventFunction<IPointerCounterHandler> counterChangedV2Delegate
        = delegate (IPointerCounterHandler handler, BaseEventData data)
        {
            var casted = ExecuteEvents.ValidateEventData<PointerCounterEventData>(data);
            handler.OnPointerCounterChanged(casted);
        };
    
        public static int touchCount = 0;
        public PointerCounterInfo touchCountData = new PointerCounterInfo();
        public static List<int> touchID = new List<int>(6); //6 touches limit
    
        //Constructor with the int parameter 
        public PointerCounterEventData(
                               EventSystem eventSystem,
                               int tempTouchId,
                               PointerState pointerStat
                               )
                              : base(eventSystem)
        {
            //Process the Input event
            processTouches(pointerStat, tempTouchId, null, CallBackType.TouchCountOnly);
        }
    
    
        //Constructor with the PointerEventData parameter
        public PointerCounterEventData(
                          EventSystem eventSystem,
                           PointerEventData eventData,
                           PointerState pointerStat,
                           GameObject target
                           )
                          : base(eventSystem)
        {
            //Process the Input event
            processTouches(pointerStat, eventData.pointerId, eventData, CallBackType.CounterData);
    
            //Create new PointerCounterInfo for the OnPointerCounterChanged(PointerCounterEventData eventData) function
            PointerCounterInfo pcInfo = createPointerInfo(eventData,
    target, pointerStat);
            //Update touchCountData       
            touchCountData = pcInfo;
        }
    
    
        void processTouches(PointerState pointerStat, int tempTouchId, PointerEventData touchCountData, CallBackType cbType)
        {
            if (pointerStat == PointerState.DOWN)
            {
                //Check If PointerId exist, if it doesn't add to list
                if (touchID.Contains(tempTouchId))
                {
                    //eventData.eventData
                    return; //Exit if PointerId exist
                }
    
                //PointerId does not exist, add it to the list then increment touchCount
                touchID.Add(tempTouchId);
                touchCount++;
            }
    
            if (pointerStat == PointerState.UP)
            {
                //Check If PointerId exist, if it exist remove it from list then decrement touchCount
                if (touchID.Contains(tempTouchId))
                {
                    touchID.Remove(tempTouchId);
                    touchCount--;
                    return;
                }
            }
        }
    
        public static void notifyPointerDown(EventSystem eventSystem, PointerEventData eventData,
            GameObject target)
        {
            PointerState pointerStat = PointerState.DOWN;
            notifyfuncs(eventSystem, eventData, target, pointerStat);
        }
    
        public static void notifyPointerUp(EventSystem eventSystem, PointerEventData eventData,
            GameObject target)
        {
            PointerState pointerStat = PointerState.UP;
            notifyfuncs(eventSystem, eventData, target, pointerStat);
        }
    
        private static void notifyfuncs(EventSystem eventSystem, PointerEventData eventData,
            GameObject target, PointerState pointerStat)
        {
            //////////////////////Call the int parameter//////////////////////
            PointerCounterEventData eventParam1 = new PointerCounterEventData(
                           eventSystem,
                           eventData.pointerId,
                           pointerStat);
    
            ExecuteEvents.Execute<IPointerCounterHandler>(
                                    target,
                                    eventParam1,
                                    PointerCounterEventData.counterChangedV1Delegate);
    
            //////////////////////Call the PointerCounterEventData parameter//////////////////////
            PointerCounterEventData eventParam2 = new PointerCounterEventData(
                   eventSystem,
                   eventData,
                   pointerStat,
                   target);
            ExecuteEvents.Execute<IPointerCounterHandler>(
                                         target,
                                         eventParam2,
                                         PointerCounterEventData.counterChangedV2Delegate);
        }
    
        //Creates PointerCounterInfo for the OnPointerCounterChanged(PointerCounterEventData eventData) function
        private static PointerCounterInfo createPointerInfo(PointerEventData eventData,
            GameObject target, PointerState pointerStat)
        {
            PointerCounterInfo pointerCounterInfo = new PointerCounterInfo();
            pointerCounterInfo.pointerId = eventData.pointerId;
            pointerCounterInfo.touchCount = touchCount;
            pointerCounterInfo.eventData = eventData;
            pointerCounterInfo.pointerState = pointerStat;
            pointerCounterInfo.target = target;
            return pointerCounterInfo;
        }
    
        public enum CallBackType
        {
            TouchCountOnly, CounterData
        }
    }
    
    public enum PointerState { NONE, DOWN, UP }
    
    public class PointerCounterInfo
    {
        public int pointerId = 0;
        public int touchCount = 0;
        public PointerEventData eventData;
        public PointerState pointerState;
        public GameObject target;
    }
