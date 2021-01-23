      public  Control[] FlattenHierachy(Control root)
        {
            List<Control> list = new List<Control>();
            list.Add(root);
            if (root.HasControls())
            {
                foreach (Control control in root.Controls)
                {
                    list.AddRange(FlattenHierachy(control));
                }
            }
            return list.ToArray();
        }
