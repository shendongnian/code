            int numElements = 0;
            int.TryParse(textBox1.Text, out numElements);
            if(numElements >100){
                MessageBox.Show("No. Of Elements Must be Less Then 100");
            }
