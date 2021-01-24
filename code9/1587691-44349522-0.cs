    public static bool set_never_hide_column(DataGridView dgv, int[] col)
        {
            try
            {
                foreach (DataGridViewColumn x in dgv.Columns)
                {
                    if (col.Contains(dgv.Columns.IndexOf(x)))
                    {
                        x.Tag = true;
                    }
                    else
                    {
                        x.Tag = false;
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool set_hide_column (DataGridView dgv, int[] col)
        {
            try
            {
                foreach (DataGridViewColumn x in dgv.Columns)
                {
                    if (col.Contains(dgv.Columns.IndexOf(x)) && (bool)x.Tag == false)
                    {
                        x.Visible = false;
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
