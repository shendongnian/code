    // Simplest, but not thread safe
    static Random s_Gen = new Random();
    private static string Solution(int all, int c1, int c2, int c3) {
      return string.Join(",", new[] {
        Enumerable.Repeat("C1", c1),
        Enumerable.Repeat("C2", c2),
        Enumerable.Repeat("C3", c3),
        Enumerable.Repeat("C4", all - c1 - c2 - c3), }
      .SelectMany(item => item)
      .OrderBy(item => s_Gen.NextDouble()));  
    }
    protected void BtnGenerate_Click(object sender, EventArgs e) {
      lblRandomNumbers.Text = Solution(27, 10, 5, 3);
    }
