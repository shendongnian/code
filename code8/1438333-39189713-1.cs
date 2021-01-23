        public Dto Dto;
        private void textBox2_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (this.Dto != null)
            {
                this.Dto.Text = textBox2.Text;
            }
        }
