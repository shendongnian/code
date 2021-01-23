    public Form GetActiveForm()
    {
        Form activeForm = Form.ActiveForm;
        if (activeForm.IsMdiContainer && activeForm.ActiveMdiChild != null)
        {
            activeForm = activeForm.ActiveMdiChild;
        }
        return activeForm;
    }
