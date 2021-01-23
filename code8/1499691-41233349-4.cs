    public static class Navigator {
        public static WithViewHelper<TView> WithView<TView>()
                where TView : new() => new WithViewHelper<TView>();
        public struct WithViewHelper<TView> where TView : new() { }
    }
    public static class NavigatorExtensions {
        public static void Navigate<TView, T0, T1>(this Navigator.WithViewHelper<TView> withViewHelper, T0 arg0, T1 arg1)
                where TView : ViewBase<T0, T1>, new() {
            var view = new TView();
            view.Initialize(arg0, arg1);
        }
    }
