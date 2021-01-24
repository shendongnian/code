    public static class StaticData
    {
        public static Dictionary<GuiAction, Dictionary<string, bool>> dict = new Dictionary<GuiAction, Dictionary<string, bool>>
            {
                {
                    GuiAction.FlowView, new Dictionary<string, bool>
                    {
                        {"Runnable", false},
                        {"Path", false}
                    }
                },
                {
                    GuiAction.FlowEdit, new Dictionary<string, bool>
                    {
                        {"Runnable", true}
                    }
                }
            };
    }
