    private static void MultiplyBoxes(TextBox a, TextBox b, TextBox c) {
        if (!int.TryParse(a.Text, var out ia)) {
            ia = 0;
        }
        if (!int.TryParse(b.Text, var out ib)) {
            ib = 0;
        }
        c.Text = (ia*ib).ToString();
    }
