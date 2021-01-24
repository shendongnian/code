    Queue<string> qbox = new Queue<string>
    {
        "0x330D9838", "0x33015AB0"
    };
    Queue<string> qwc = new Queue<string>
    {
        "0x331397E4", "0x33075BF4"
    };
    private void btn_ConvertMode_Click(object sender, EventArgs e)
    {
        qbox.Enqueue(box);
        box = qbox.Dequeue();
       qwc.Enqueue(wc);
        wc= qbox.Dequeue();
    }
