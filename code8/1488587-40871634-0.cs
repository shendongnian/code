        public static void ClearAllSelections(this ToolStrip toolStrip)
        {
            // Call private method using reflection
            MethodInfo method = typeof(ToolStrip).GetMethod("ClearAllSelections", BindingFlags.NonPublic | BindingFlags.Instance);
            method.Invoke(toolStrip, null);
        }
