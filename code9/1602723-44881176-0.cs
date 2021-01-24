     Public class addWinForm : Form
        {
         ... 
          public string Answer { get { return answer;}}
          private string answer;
         
          private void btnOK_Click(object sender, EventArgs e)
            {
                //this is supposed
                answer = "1111";
                Close();
            }
        }
    public class MainForm : Form
    {
        ....
        private AddWinForm addWinForm = null;    
        private void btAdd_Click(object sender, EventArgs e)
            {    
                addWinForm = new AddWinForm();
        
                addWinForm.ShowDialog();
                string answerAfterButtonOk = addWinForm.Answer;
                addWinForm.Dispose();
                addWinForm = null;
            }
    }
    
       
