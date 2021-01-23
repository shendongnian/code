    private void button_Click(object sender, EventArgs e)
	{
		var task = Task.Run<int>(
                () => this.TestSynchronous());
		
		task.Wait();
		
		MessageBox.Show(task.Result.ToString());
	}
