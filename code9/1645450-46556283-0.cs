        public void setGPA()
        {
            string stuGPAString;
            if (!Double.TryParse(stuGPAString, out stuGpa))
            {
                throw new FormatException("Invalid student gpa");
            };
        }
