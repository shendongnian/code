        [Range(typeof(bool), "true", "true", ErrorMessage = "The field Email must be informed.")]
        public bool IsEmailInformed
        {
            get
            {
                return (string.IsNullOrEmpty(Home.Address) == false ||
                        string.IsNullOrEmpty(Work.Address) == false ||
                        string.IsNullOrEmpty(Other.Address) == false);
            }
        }
