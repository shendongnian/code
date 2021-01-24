    using System.Linq;
    ...
    private void Form1_Load(object sender, EventArgs e) {
      Label[] nmr = Enumerable
        .Range(0, 10)
        .Select(i => new Label() {
           Text = $"label {i}",
           Left = 20 + i * 20, // <- please, notice Left computation
           Parent = this, })
        .ToArray();
    }
