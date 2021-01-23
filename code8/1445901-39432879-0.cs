        private int CountChecks(IEnumerable controls)
        {
            var result = 0;
            foreach (Control xControl in controls)
            {
                
                if (xControl.HasChildren) result += CountChecks(xControl.Controls);
                if (!(xControl is CheckBox)) continue;
                if (!(xControl as CheckBox).Checked) continue;
                result++;
            }
            return result;
        }
