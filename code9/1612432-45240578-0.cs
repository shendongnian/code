    private void libHT_SelectedIndexChanged(object sender, EventArgs e) {
        libMonth.SelectedIndices.Clear();
        foreach (int indx in libHT.SelectedIndices)
            libMonth.SelectedIndices.Add(indx);
    }
