    public class Widget
    {
        public string Name;
        Widget(string widgetName)
        {
            if (widgetName != "")
                Name = widgetName;
            else
                throw new ArgumentException("Name must be provided for widget.");
        }
    }
