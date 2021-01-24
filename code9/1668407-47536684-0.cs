     private async void button1_Click_1(object sender, EventArgs e)
        {
            button1.Text = "Work started.";
            Task myTask = new Task(DoWork);
            myTask.Start();
            await myTask;
            button1.Text = "Work done.";
        }
     private void DoWork()
        {
            this.SetMessageText("Step 1");
            Thread.Sleep(2000); // --> you can replace it with your actual method
            this.SetMessageText("Step 2");
            Thread.Sleep(2000); // --> you can replace it with your actual method
            this.SetMessageText(" ");
        }
 
