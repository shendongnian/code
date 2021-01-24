    Usings:
    using System;
    using System.IO;
    using System.Windows.Forms;
    Forms code:
    public partial class Form1 : Form
    {
        private string _filePath = @"c:\Users\Admin\Desktop\logins.txt";
        private int encryptNumber = 32;
        public Form1()
        {
            InitializeComponent();
        }
        private string Encrypt(string value)
        {
            var result = string.Empty;
            char[] arr = value.ToCharArray();
            for(int i=0;i< arr.Length;i++)
            {
                result += (char)(arr[i] + encryptNumber);
            }
            return result;
        }
        private string Decrypt(string value)
        {
            var result = string.Empty;
            char[] arr = value.ToCharArray();
            for (int i = 0; i < arr.Length; i++)
            {
                result +=(char)(arr[i] - encryptNumber);
            }
            return result;
        }
    
        private void SignUpBtn_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(loginTxtBox.Text) || string.IsNullOrEmpty(passTxtBox.Text))
            {
                MessageBox.Show("Invalid login/password");
                return;
            }
            if (CheckLogPass(_filePath))
                MessageBox.Show("Invalid login/password");
            else
            {
                File.AppendAllText(_filePath, "\r\n" + Encrypt(loginTxtBox.Text + "|" + passTxtBox.Text));
                MessageBox.Show("Successful SignUp, now you can SignIn");
            }
        }
    
        private void SignInBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(loginTxtBox.Text) || string.IsNullOrEmpty(passTxtBox.Text))
            {
                MessageBox.Show("Invalid login/password");
                return;
            }
            if(CheckLogPass(_filePath))
                MessageBox.Show("Successfully SignIn");
            else
                MessageBox.Show("Invalid login/password");
        }
    
        private bool CheckLogPass(string path)
        {
            if (!File.Exists(_filePath))
            {
                File.Create(_filePath);
            }
            using (var fs = File.OpenText(_filePath))
            {
                while (!fs.EndOfStream)
                {
                    string line = fs.ReadLine();
                    string decrypted = Decrypt(line);
                    if (decrypted.Contains(loginTxtBox.Text + "|" + passTxtBox.Text))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
