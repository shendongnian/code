    int total = SumTextBoxesInPanel(pnlMyTextBoxes);
    resultado.Text = determinantes.detGrado3(total).ToString();
    public int SumTextBoxesInPanel(Panel pnl)
    {
      int total = 0;
      foreach(TextBox txt in pnl.Controls.FindAll((ctrl) => ctrl is TextBox))
      {
         total += determinantes.aEntero(txt.Text)
      }
      return total;
    }
