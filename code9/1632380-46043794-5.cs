    public  void RollDices()
        {
            //this is not necessary but if you want to keep a sum of dices keep 
            //it
            var count = 0;
            foreach (var die in dices)
            {
                count += die.Indexer;
            }
            //pictureboxes 2-7 are guess boxes and button1 is guess btn
            if(textBox2.Text.Equals(dices[0].Indexer.ToString()))
                pictureBox1.Image = Image.FromFile(dices[0].PhotoPath);
            if (textBox3.Text.Equals(dices[1].Indexer.ToString()))
                pictureBox2.Image = Image.FromFile(dices[1].PhotoPath);
            if (textBox4.Text.Equals(dices[2].Indexer.ToString()))
                pictureBox3.Image = Image.FromFile(dices[2].PhotoPath);
            if (textBox5.Text.Equals(dices[3].Indexer.ToString()))
                pictureBox4.Image = Image.FromFile(dices[3].PhotoPath);
            if (textBox6.Text.Equals(dices[4].Indexer.ToString()))
                pictureBox5.Image = Image.FromFile(dices[4].PhotoPath);
            if (textBox7.Text.Equals(dices[5].Indexer.ToString()))
                pictureBox6.Image = Image.FromFile(dices[5].PhotoPath);    
        }
