    public void button5_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < threadCount; i++)
        {
            new Thread(new ParameterizedThreadStart(threadJob)).Start(i);
        }
    }
    private void threadJob(object o)
    {
        int threadNumber = (int)o;
        int count = txtSearchTerms.Lines.Length / threadCount;
        int start = threadNumber * count;
        int end = threadNumber != threadCount - 1 ? start + count : txtSearchTerms.Lines.Length;
        for (int i = start; i < end; i++)
        {
            Console.WriteLine(txtSearchTerms.Lines[i]);
        }
    }
