    public static class ColorItemExtension
    {
        public static bool Register(this ColorItem colorItem)
        {
            if (colorItem.Color == null) return false;
            Assembly assembly = typeof(ColorPicker).Assembly;
            Type colorUtilityType = assembly.GetType("Xceed.Wpf.Toolkit.Core.Utilities.ColorUtilities");
            if (colorUtilityType == null) return false;
            FieldInfo fieldInfo = colorUtilityType.GetField("KnownColors");
            if (fieldInfo == null) return false;
            Dictionary<string, Color> knownColors = fieldInfo.GetValue(null) as Dictionary<string, Color>;
            if (knownColors == null) return false;
            if (knownColors.ContainsKey(colorItem.Name)) return false;
            knownColors.Add(colorItem.Name, (Color) colorItem.Color);
            return true;
        }
    }
