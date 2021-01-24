    public partial class Test
    {
        Dictionary<int, double[]> dictionary = new Dictionary<int, double[]>();
       private void btnCalculate_Click(object sender, EventArgs e)
       {
           int start = txtStart.Text;
           int end = Convert.ToInt32(txtEnd.Text)+1;
           int[] ag = Enumerable.Range(start, end - start).ToArray();
           foreach (int a in ag)
           {
               if(!dictionary.ContainsKey(a))
                   dictionary.Add(a, new double[] { a*10, a*15, a*20 });
           }
       }
    }
