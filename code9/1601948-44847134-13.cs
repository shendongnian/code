    public List<ControllerBlock> GetControllerBlocks()
    {
        //Set ActionActive herem, if necessary
        List<ControllerAction> homeActions = new List<ControllerAction>() {
            new ControllerAction { ActionName = "Index" },
            new ControllerAction {  ActionName = "DashBoard" },
            new ControllerAction { ActionName = "Chart" }
        };
        List<ControllerAction> hrActions = new List<ControllerAction>() {
            new ControllerAction { ActionName = "Leave" },
            new ControllerAction { ActionName = "Loan" },
            new ControllerAction { ActionName = "NoticeBoard" }
            };
        List<ControllerAction> payRollActions = new List<ControllerAction>() {
            new ControllerAction { ActionName = "View" },
            new ControllerAction {  ActionName = "Edit" },
            new ControllerAction { ActionName = "Process" }
            };
        List<ControllerBlock> actionBlocks = new List<ControllerBlock>()
        {
            new ControllerBlock(){ControllerName = "Home", ControllerActions = homeActions},
            new ControllerBlock(){ControllerName = "HR",  ControllerActions =  hrActions},
            new ControllerBlock(){ControllerName = "PayRoll",  ControllerActions =  payRollActions}
        };
        return actionBlocks;
    }
