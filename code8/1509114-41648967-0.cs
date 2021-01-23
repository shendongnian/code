    public void UpdateData(Pair pair, double d)
    {
            Action action = () =>
            {
                var pd = pairList.First((x) => x.pair == pair);
                pd.UpdateDiff(d);
            };
            if (listBox1.InvokeRequired)
            {
                listBox1.Invoke(action);
            }
            else
            {
                action();
            }
    }
