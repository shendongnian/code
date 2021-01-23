    for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
    {
        if (Application.OpenForms[i].Name != "Form1")
        {
            Application.OpenForms[i].Close();
        }
    }
