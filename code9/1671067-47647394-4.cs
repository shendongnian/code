    private void btn_ConvertMode_Click(object sender, EventArgs e)
    {
        qbox.Enqueue(box);
        box = qbox.Dequeue();
        qwc.Enqueue(wc); //puts wc value to the back of the queue
        wc= qbox.Dequeue(); //removes first value from a queue and puts it in wc variable
    }
