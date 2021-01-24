    public interface IReleaseSetupScript
    {
    	ReleaseSetupData SetupData { set; }
    	KfxReturnValue OpenScript();
    	KfxReturnValue CloseScript();
    	KfxReturnValue RunUI();
    	KfxReturnValue ActionEvent(KfxActionValue Action, string strData1, string strData2);
    }
