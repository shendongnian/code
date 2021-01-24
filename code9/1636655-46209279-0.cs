        private string saveValueName = "";
        public string GetText()
        {
            return this.saveValueName;
        }
        public void SetText(string output)
        {
            if (!string.Equals(output, saveValueName))
            {
                this.saveValueName = output;
            }
        }
