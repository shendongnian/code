	void IDialogStack.Call<R>(IDialog<R> child, ResumeAfter<R> resume)
	{
	    var callRest = ToRest(child.StartAsync);
	    if (resume != null)
	    {
	        var doneRest = ToRest(resume);
	        this.wait = this.fiber.Call<DialogTask, object, R>(callRest, null, doneRest);
	    }
	    else
	    {
	        this.wait = this.fiber.Call<DialogTask, object>(callRest, null);
	    }
	}
	async Task IDialogStack.Forward<R, T>(IDialog<R> child, ResumeAfter<R> resume, T item, CancellationToken token)
	{
	    IDialogStack stack = this;
	    stack.Call(child, resume);
	    await stack.PollAsync(token);
	    IPostToBot postToBot = this;
	    await postToBot.PostAsync(item, token);
	}
