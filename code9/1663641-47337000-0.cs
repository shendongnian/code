    Regex regMail = new Regex(@"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$");
    if (regMail.IsMatch(mailID.Text))
    {
        Email email = new Email();
        string emailAdd = mailID.Text;
        string phone =    phoneBox.Text;
        string messageEmail = email.Text;
        System.IO.StreamWriter file = new System.IO.StreamWriter(@"D:\Lia\mail.txt", true);
        file.WriteLine(emailAdd + phone + messageEmail);
        file.Close();
    }
    else
    {
        MessageBox.Show("Invalid Email ID, Please enter \nvalid Email ID.");
    }
