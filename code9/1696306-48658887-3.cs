     class Program
    {
        public static object GetProperty(object obj, string memberName, object[] objParam)
        {
            return InvokeMember(obj, memberName, BindingFlags.GetProperty, objParam);
        }
        public static object SetProperty(object obj, string memberName, object[] objParam)
        {
            return InvokeMember(obj, memberName, BindingFlags.SetProperty, objParam);
        }
        public static void SetProperty(object obj, string sProperty, object oValue)
        {
            object[] oParam = new object[1];
            oParam[0] = oValue;
           obj.GetType().InvokeMember(sProperty, BindingFlags.SetProperty, null, obj, oParam);
        }
        public static object InvokeMethod(object obj, string memberName, object[] objParam)
        {
            return InvokeMember(obj, memberName, BindingFlags.InvokeMethod, objParam);
        }
        public static object InvokeMember(object obj, string memberName, BindingFlags flag, object[] objParam)
        {
            try
            {
                return obj.GetType().InvokeMember(memberName, flag, null, obj, objParam);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static  object InvokeMethod(object obj, string sProperty, object oValue)
        {
            object[] oParam = new object[1];
            oParam[0] = oValue;
            return obj.GetType().InvokeMember
            (sProperty, BindingFlags.InvokeMethod, null, obj, oParam);
        }
        public static  object GetProperty(object obj, string sProperty, object oValue)
        {
            object[] oParam = new object[1];
            oParam[0] = oValue;
            return obj.GetType().InvokeMember
                (sProperty, BindingFlags.GetProperty, null, obj, oParam);
        }
        public static object GetProperty(object obj, string sProperty)
        {
            return obj.GetType().InvokeMember
            (sProperty, BindingFlags.GetProperty, null, obj, null);
        }
        static void Main(string[] args)
        {
            Application oWord = new Application();
            try
            {
                Document oDoc;
               
                oWord.Visible = true;
                object oMissing = System.Reflection.Missing.Value;
                object oEndOfDoc = "\\endofdoc"; /* \endofdoc is a predefined bookmark */
                oDoc = oWord.Documents.Add(ref oMissing, ref oMissing,
                   ref oMissing, ref oMissing);
                Range wrdRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
                object outerTables = GetProperty(wrdRng, "Tables");
                object oTable = InvokeMethod(outerTables, "Add", new object[] { wrdRng, 3, 3, oMissing, oMissing });
              
                var outerBorders = GetProperty(oTable, "Borders");
              
                SetProperty(outerBorders, "OutsideLineStyle", WdLineStyle.wdLineStyleSingle);
                SetProperty(outerBorders, "OutsideColor", WdColor.wdColorBlack);
                SetProperty(oTable, "TableDirection",WdTableDirection.wdTableDirectionLtr );
                SetProperty(outerBorders, "InsideLineStyle", WdLineStyle.wdLineStyleSingle);
                SetProperty(outerBorders, "InsideColor", WdColor.wdColorBlack);
                object oDocTables = oDoc.Tables;
                object oOuterTable = InvokeMethod(oDocTables, "Add", new object[] { wrdRng, 3, 3, oMissing, oMissing });
                object objCell = InvokeMethod(oTable, "Cell", new object[] { 2, 2 });
                object objTR = GetProperty(objCell, "Range", null);
                object Start = GetProperty(objTR, "Start", null);
               InvokeMethod(wrdRng, "SetRange", new object[] { Start, Start });
                object innerTables = GetProperty(wrdRng, "Tables", null);
              
                object iTable = InvokeMethod(innerTables, "Add", new object[] { wrdRng, 2, 2, oMissing, oMissing });
                var  innerBorders = GetProperty(iTable, "Borders");
                var  iTableDirection = GetProperty(iTable, "TableDirection");
                SetProperty(innerBorders, "OutsideLineStyle", WdLineStyle.wdLineStyleSingle);
                SetProperty(innerBorders, "OutsideColor", WdColor.wdColorBlack);
                SetProperty(iTable, "TableDirection", WdTableDirection.wdTableDirectionLtr);
                SetProperty(innerBorders, "InsideLineStyle", WdLineStyle.wdLineStyleSingle);
                SetProperty(innerBorders, "InsideColor", WdColor.wdColorBlack);
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
               // oWord.Quit();
            }
        }
    }
