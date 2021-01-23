    public interface IPointerCounterHandler : IEventSystemHandler
    {
        void OnPointerCounterChanged(int touchCount);
        void OnPointerCounterChanged(PointerCounterEventData touchCountData);
    }
