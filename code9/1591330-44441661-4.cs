    private void dpDataEmissao_KeyUp(object sender, KeyEventArgs e)
    {
        if (new int[] { 2, 5 }.Contains(dpDataEmissao.Text.Length))
        {
            InputSimulator.SimulateTextEntry("/");
        }
    }
