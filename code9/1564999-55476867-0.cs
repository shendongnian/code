        static IXLStyle CreateEmptyStyle()
        {
            var t = typeof(ClosedXML.Excel.XLConstants).Assembly.GetType("ClosedXML.Excel.XLStyle");                        
            MethodInfo m = t?.GetMethod("CreateEmptyStyle", BindingFlags.Static | BindingFlags.NonPublic);
            var o = m?.Invoke(null, null);
            return o as IXLStyle;
        }
