                int dept;
                dept = Convert.ToInt32(textBoxDept.Text);
                double cont;
                cont = Convert.ToDouble(textBoxCont.Text);
                //textBoxDept.Text = "";
                //textBoxCont.Text = "";
                //textBoxDonor.Text = "";
                labelOutput.Text = "Printing Contribution Table \n dept          amount          donor";
                for (int i = 0; i < deptArray.Length; i = i + 1)
                {
                    nameArray[i] = textBoxDonor.Text;
                    labelOutput.Text += String.Format("\n {0}          {1}          {2} ", deptArray[i], contArray[i].ToString("C"), nameArray[i]);
                
         }
