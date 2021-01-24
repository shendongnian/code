    Xpcom.Initialize("Firefox64");
    PromptFactory.PromptServiceCreator = () => new FilteredPromptService();
---------------------------------------------------------------------
    
    public class FilteredPromptService : nsIPromptService2, nsIPrompt
    {   
        void nsIPromptService2.Alert(nsIDOMWindow aParent, string aDialogTitle, string aText)
        {
           
        }
        void nsIPromptService2.AlertCheck(nsIDOMWindow aParent, string aDialogTitle, string aText, string aCheckMsg, ref bool aCheckState)
        {
            
        }
        bool nsIPromptService2.Confirm(nsIDOMWindow aParent, string aDialogTitle, string aText)
        {
             throw new NotImplementedException();
        }
        bool nsIPromptService2.ConfirmCheck(nsIDOMWindow aParent, string aDialogTitle, string aText, string aCheckMsg, ref bool aCheckState)
        {
             throw new NotImplementedException();
        }
        int nsIPromptService2.ConfirmEx(nsIDOMWindow aParent, string aDialogTitle, string aText, uint aButtonFlags, string aButton0Title, string aButton1Title, string aButton2Title, string aCheckMsg, ref bool aCheckState)
        {
             throw new NotImplementedException();
        }
        bool nsIPromptService2.Prompt(nsIDOMWindow aParent, string aDialogTitle, string aText, ref string aValue, string aCheckMsg, ref bool aCheckState)
        {
             throw new NotImplementedException();
        }
        bool nsIPromptService2.PromptUsernameAndPassword(nsIDOMWindow aParent, string aDialogTitle, string aText, ref string aUsername, ref string aPassword, string aCheckMsg, ref bool aCheckState)
        {
             throw new NotImplementedException();   
        }
        bool nsIPromptService2.PromptPassword(nsIDOMWindow aParent, string aDialogTitle, string aText, ref string aPassword, string aCheckMsg, ref bool aCheckState)
        {
             throw new NotImplementedException();
        }
        bool nsIPromptService2.Select(nsIDOMWindow aParent, string aDialogTitle, string aText, uint aCount, IntPtr[] aSelectList, ref int aOutSelection)
        {
             throw new NotImplementedException();
        }
        bool nsIPromptService2.PromptAuth(nsIDOMWindow aParent, nsIChannel aChannel, uint level, nsIAuthInformation authInfo, string checkboxLabel, ref bool checkValue)
        {
             throw new NotImplementedException();
        }
        nsICancelable nsIPromptService2.AsyncPromptAuth(nsIDOMWindow aParent, nsIChannel aChannel, nsIAuthPromptCallback aCallback, nsISupports aContext, uint level, nsIAuthInformation authInfo, string checkboxLabel, ref bool checkValue)
        {
             throw new NotImplementedException();
        }
        void nsIPromptService.Alert(nsIDOMWindow aParent, string aDialogTitle, string aText)
        {
             
        }
        void nsIPromptService.AlertCheck(nsIDOMWindow aParent, string aDialogTitle, string aText, string aCheckMsg, ref bool aCheckState)
        {
            
        }
        bool nsIPromptService.Confirm(nsIDOMWindow aParent, string aDialogTitle, string aText)
        {
             throw new NotImplementedException();
        }
        bool nsIPromptService.ConfirmCheck(nsIDOMWindow aParent, string aDialogTitle, string aText, string aCheckMsg, ref bool aCheckState)
        {
             throw new NotImplementedException();
        }
        int nsIPromptService.ConfirmEx(nsIDOMWindow aParent, string aDialogTitle, string aText, uint aButtonFlags, string aButton0Title, string aButton1Title, string aButton2Title, string aCheckMsg, ref bool aCheckState)
        {
             throw new NotImplementedException();
        }
        bool nsIPromptService.Prompt(nsIDOMWindow aParent, string aDialogTitle, string aText, ref string aValue, string aCheckMsg, ref bool aCheckState)
        {
             throw new NotImplementedException();
        }
        bool nsIPromptService.PromptUsernameAndPassword(nsIDOMWindow aParent, string aDialogTitle, string aText, ref string aUsername, ref string aPassword, string aCheckMsg, ref bool aCheckState)
        {
             throw new NotImplementedException();
        }
        bool nsIPromptService.PromptPassword(nsIDOMWindow aParent, string aDialogTitle, string aText, ref string aPassword, string aCheckMsg, ref bool aCheckState)
        {
             throw new NotImplementedException();
        }
        bool nsIPromptService.Select(nsIDOMWindow aParent, string aDialogTitle, string aText, uint aCount, IntPtr[] aSelectList, ref int aOutSelection)
        {
             throw new NotImplementedException();
        }
        void nsIPrompt.Alert(string dialogTitle, string text)
        {
             
        }
        void nsIPrompt.AlertCheck(string dialogTitle, string text, string checkMsg, ref bool checkValue)
        {
            
        }
        bool nsIPrompt.Confirm(string dialogTitle, string text)
        {
            throw new NotImplementedException();
        }
        bool nsIPrompt.ConfirmCheck(string dialogTitle, string text, string checkMsg, ref bool checkValue)
        {
             throw new NotImplementedException();
        }
        int nsIPrompt.ConfirmEx(string dialogTitle, string text, uint buttonFlags, string button0Title, string button1Title, string button2Title, string checkMsg, ref bool checkValue)
        {
             throw new NotImplementedException();
        }
        bool nsIPrompt.Prompt(string dialogTitle, string text, ref string value, string checkMsg, ref bool checkValue)
        {
             throw new NotImplementedException();
        }
        bool nsIPrompt.PromptPassword(string dialogTitle, string text, ref string password, string checkMsg, ref bool checkValue)
        {
             throw new NotImplementedException();
        }
        bool nsIPrompt.PromptUsernameAndPassword(string dialogTitle, string text, ref string username, ref string password, string checkMsg, ref bool checkValue)
        {
             throw new NotImplementedException();
        }
        bool nsIPrompt.Select(string dialogTitle, string text, uint count, IntPtr[] selectList, ref int outSelection)
        {
             throw new NotImplementedException();
        }
    }
