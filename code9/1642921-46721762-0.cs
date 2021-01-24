    public override void OnCancel(IDialogInterface dialog)
    {
        base.OnCancel(dialog);
        ViewModel?.ViewDestroy();
    }
    public override void DismissAllowingStateLoss()
    {
        base.DismissAllowingStateLoss();
        ViewModel?.ViewDestroy();
    }
    public override void Dismiss()
    {
        base.Dismiss();
        ViewModel?.ViewDestroy();
    }
