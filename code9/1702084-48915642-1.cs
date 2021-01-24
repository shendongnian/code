    public class FocusTriggerAction : TriggerAction<VisualElement>
    {
        public Color TextColor { get; set; }
        protected override void Invoke(VisualElement visual)
        {
            var view = visual as Picker;
            if (view == null) return;
            if (TextColor != null) view.TextColor = TextColor;
            Debug.WriteLine(visual.IsFocused ? "Focused" : "Unfocused");
        }
    }
