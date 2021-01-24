    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    namespace proj1
    {
        public partial class WebForm1 : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
            }
            protected void Button1_Click(object sender, EventArgs e)
            {
                string str = TextBox1.Text;
                Label1.Text = ("Result");
                Label2.Text = ("You have Entered");
                Label5.Text = (":");
                Label8.Text = str.ToString();
                string str1 = str.Replace(" ", "").Replace("`", "").Replace("~", "").Replace("!", "")
                                .Replace("@", "").Replace("#", "").Replace("$", "").Replace("%", "").Replace("^", "")
                                .Replace("&", "").Replace("*", "").Replace("(", "").Replace(")", "").Replace("-", "")
                                .Replace("_", "").Replace("=", "").Replace("+", "").Replace("{", "").Replace("}", "")
                                .Replace("|", "").Replace("[", "").Replace("]", "").Replace(":", "").Replace(";", "")
                                .Replace("'", "").Replace(",", "").Replace(".", "").Replace("/", "").Replace("?", "")
                                .Replace(">", "").Replace("<", "").Replace("1", "").Replace("2", "").Replace("3", "")
                                .Replace("4", "").Replace("5", "").Replace("6", "").Replace("7", "").Replace("8", "")
                                .Replace("9", "").Replace("0", "");
                string str2 = str1.ToUpper();
                string str3 = str2.Replace("A", "1").Replace("B", "2").Replace("C", "3").Replace("D", "4").Replace("E", "5").Replace("F", "8")
                                 .Replace("G", "3").Replace("H", "5").Replace("I", "1").Replace("J", "1").Replace("K", "2").Replace("L", "3")
                                 .Replace("M", "4").Replace("N", "5").Replace("O", "7").Replace("P", "8").Replace("Q", "1").Replace("R", "2")
                                 .Replace("S", "3").Replace("T", "4").Replace("U", "6").Replace("V", "6").Replace("W", "6").Replace("X", "5")
                                 .Replace("Y", "1").Replace("Z", "7");
                string word1 = str3.ToString();
                string a = word1.Select(c => c - '0').Sum().ToString();
                Label3.Text = ("Sum Of Charecters");
                Label6.Text = (":");
                Label9.Text = a.ToString();
                string w = Label9.ToString();
                string s = w.ToString();
                string b = a.Select(c => c - '0').Sum().ToString();
                for (int i = 0; i < b.Length; i++)
                {
                    string p = b.Select(c => c - '0').Sum().ToString();
                    Label10.Text = p.ToString();
                }
                Label4.Text = ("Summed Value");
                Label7.Text = (":");
            }
            }
        }
        
