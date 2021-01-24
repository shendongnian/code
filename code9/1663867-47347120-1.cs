    int factProg;
    public void factArray(int[] arr, int len)
    {   
      factProg = arr[0];
      for (int i = 1; i <= len; i++)
      {
        factProg = factProg * arr[i];
      }
    }
    int[] arr = {1,2,3,4,5};
    for (int i = 0; i < arr.Length; i++)
    {
      factArray(arr, i);
      textBox1.Text += Convert.ToString(factProg);
      textBox1.Text += Environment.NewLine;
    }
