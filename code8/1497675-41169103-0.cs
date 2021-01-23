    public static class Extensions
    {
    	public static IObservable<DialogResult> ShowDialogObservable(this Form form)
    	{
    		return Observable.Create<DialogResult>(o =>
    		{
    			o.OnNext(form.ShowDialog());
    			return Disposable.Empty;
    		});
    	}
    }
