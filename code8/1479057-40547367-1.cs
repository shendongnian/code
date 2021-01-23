    using System;
    using System.Windows.Forms;
    namespace Test {
        internal class Program {
            private static void Main(string[] args) {
                MessageBox.Show("This program adds two integers.");
                var n1 = ReadInt("Enter n1: ");
                var n2 = ReadInt("Enter n2: ");
                var total = n1 + n2;
                MessageBox.Show(string.Format("The total is {0}.", total));
            }
            private static int ReadInt(string message) {
                var sInt = Microsoft.VisualBasic.Interaction.InputBox(message);
                int ret;
                if (int.TryParse(sInt, out ret)) {
                    return ret;
                }
                throw new Exception("You must enter a valid number!");
            }
        }
    }
