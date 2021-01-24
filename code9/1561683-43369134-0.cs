        public string GetControlName(string userInput)
        {
            var hashCode = userInput.GetHashCode();
            string controlName;
            if (hashCode < 0)
            {
                controlName = String.Concat("uc_", -hashCode);
            }
            else
            {
                controlName = String.Concat("uc", hashCode);
            }
            return controlName;
        }
