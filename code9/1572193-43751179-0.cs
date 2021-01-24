    private void Start_Describestack()
    {
        //method making use of timer to call 
        _timer = new System.Timers.Timer(15000);
        _timer.Elapsed += new ElapsedEventHandler(_timer_Elapsed);
        _timer.Enabled = true;
    }
    private void _timer_Elapsed(object sender, ElapsedEventArgs e)
    {
        Invoke((MethodInvoker)describeStack);
    }
    private void describeStack()
    {
        var client = new cloudclient();
        var request2 = new StacksRequest();
        request2.Cloudstackname = stackid;
        try
        {
            var response = client.DescribeCloudStacks(request2);
            foreach (var stack in response.Stacks)
            {
                stackStatus.Text = stack.StackStatus;
                stackStatus.Refresh();
                describeevents();
            }
        }
        catch (Exception)
        {
            stackStatus.Text = "Stack not found/Deleted";
        }
        describeevents();
    }
