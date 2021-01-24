    public string ShowCounts()
        {
            string display = string.Empty;
            if (this.Count1 > 0)
            {
                display = $"{this.Count1} Count1";
            }
            if (this.Count2 > 0)
            {
                if( !string.IsNullOrEmpty(display) ) display += "\n";
                display += $"{this.Count2} Count2";
            }
            if (this.Count3 > 0)
            {
                if( !string.IsNullOrEmpty(display) ) display += "\n";
                display += $"{this.Count3} Count3";
            }
            return display;
        }
