    Task ts =new Task(new Action(()=>{
    //your code here
    }
    ));
    ts.Start();//start task
    //here we wait until task completed
    while (!ts.IsComplete)//check until task is finished
    {
    //pervent UI freeze
    Application.DoEvents();
    }
    //Task Completed
    //Continue with ...
    textBox.Text = ts.Result;
