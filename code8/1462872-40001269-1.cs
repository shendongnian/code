    // Easiest, but not thread safe
    private static Random random = new Random();
    private static void FillBox(ListBox box, int count = 10) {
      box.Items.Clear();
      box.Items.AddRange(Enumerable
        .Range(0, count)
        .Select(x => (Object) random.Next(20))
        .ToArray());
    }
    private static int SumBox(ListBox box) {
      return box.Items
        .OfType<Object>()
        .Sum(x => Convert.ToInt32(x));
    }
    ...
    FillBox(listBox1);
    FillBox(listBox2);
    if (SumBox(listBox1) > SumBox(listBox2)) {
      ...
    }
