    public static T GetForm<T>() where T : Form
    {
        for (int i = 0; i < Application.OpenForms.Count; i++)
        {
            if (Application.OpenForms[i] is T)
                return (T)Application.OpenForms[i];
        }
        return null;
    }
