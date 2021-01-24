     private void button1_Click(object sender, EventArgs e)
            {
                var ultimateResult = string.Empty;
                var cusrPosition = richTextBox1.SelectionStart;
                var currentStr = string.Empty;
                var strDic = new Dictionary<string,int>();
                var spPosition = new List<int>();
                var textArr = richTextBox1.Text.ToCharArray();
                for (var i = 0; i < textArr.Count(); i++)
                {
                    if (textArr[i] != ';')
                        currentStr = currentStr + textArr[i];
                    else
                    {
                        strDic.Add(currentStr,i);
                        currentStr = string.Empty;
                        spPosition.Add(i);
                    }
                }
                ultimateResult = strDic.First(item => item.Value >= cusrPosition).Key;
                textBox1.Text = ultimateResult;
    
            }
