    public class MyViewRenderer : ViewRenderer<MyView, SomeNativeView>
    {
        private void METHOD_CALLED_BY_EVENT(string param)
        {
            Element.RaiseEvent(param);
        }
    }
