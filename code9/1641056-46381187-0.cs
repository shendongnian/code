    public static class MyExtensions {
        public static IEnumerable<Control> GetAllControls(this Control control)
        {
            foreach (Control c in control.Controls)
            {
                yield return c;
                foreach (Control c1 in c.GetAllControls())
                    yield return c1;
            }
        }
    }
