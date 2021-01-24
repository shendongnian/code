    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    namespace divideSquare
    {
        public partial class Form1 : Form
        {
            public ChildSquare root = new ChildSquare();
            public Form1()
            {
                InitializeComponent();
                this.Load += new EventHandler(Form1_Load);
            }
            private void square_Click(object sender, EventArgs e)
            {
                ChildSquare  oldButton = sender as ChildSquare;
                oldButton.topLeftSquare.Click += new EventHandler(topLeftSquare_Click);
                //topRightSquare.Click += new EventHandler(topRightSquare_Click);
                //bottomLeftSquare.Click += new EventHandler(bottomLeftSquare_Click);
                //bottomRightSquare.Click += new EventHandler(bottomRightSquare_Click);
                oldButton.topLeftSquare.Size = new System.Drawing.Size(oldButton.centerSquare.Height / 2, oldButton.centerSquare.Width / 2);
                oldButton.topRightSquare.Size = new System.Drawing.Size(oldButton.centerSquare.Height / 2, oldButton.centerSquare.Width / 2);
                oldButton.bottomLeftSquare.Size = new System.Drawing.Size(oldButton.centerSquare.Height / 2, oldButton.centerSquare.Width / 2);
                oldButton.bottomRightSquare.Size = new System.Drawing.Size(oldButton.centerSquare.Height / 2, oldButton.centerSquare.Width / 2);
                oldButton.topLeftSquare.Location = new Point(0, 0);
                oldButton.topRightSquare.Location = new Point(50, 0);
                oldButton.bottomLeftSquare.Location = new Point(0, 50);
                oldButton.bottomRightSquare.Location = new Point(50, 50);
                oldButton.topLeftSquare.BackColor = Color.Red;
                oldButton.topRightSquare.BackColor = Color.Red;
                oldButton.bottomLeftSquare.BackColor = Color.Red;
                oldButton.bottomRightSquare.BackColor = Color.Red;
                this.Controls.Add(oldButton.topLeftSquare);
                this.Controls.Add(oldButton.topRightSquare);
                this.Controls.Add(oldButton.bottomLeftSquare);
                this.Controls.Add(oldButton.bottomRightSquare);
                oldButton.centerSquare.Dispose();
            }
            private void topLeftSquare_Click(object sender, EventArgs e)
            {
                ChildSquare childTopLeftSquare = sender as ChildSquare;
                childTopLeftSquare.topLeftSquare.Click += new EventHandler(topLeftSquare_Click);
                //topRightSquare.Click += new EventHandler(topRightSquare_Click);
                //bottomLeftSquare.Click += new EventHandler(bottomLeftSquare_Click);
                //bottomRightSquare.Click += new EventHandler(bottomRightSquare_Click);
                childTopLeftSquare.topLeftSquare.Size = new System.Drawing.Size(childTopLeftSquare.topLeftSquare.Height / 2, childTopLeftSquare.topLeftSquare.Width / 2);
                childTopLeftSquare.topRightSquare.Size = new System.Drawing.Size(childTopLeftSquare.topLeftSquare.Height / 2, childTopLeftSquare.topLeftSquare.Width / 2);
                childTopLeftSquare.bottomLeftSquare.Size = new System.Drawing.Size(childTopLeftSquare.topLeftSquare.Height / 2, childTopLeftSquare.topLeftSquare.Width / 2);
                childTopLeftSquare.bottomRightSquare.Size = new System.Drawing.Size(childTopLeftSquare.topLeftSquare.Height / 2, childTopLeftSquare.topLeftSquare.Width / 2);
                childTopLeftSquare.topLeftSquare.Location = new Point(0, 0);
                childTopLeftSquare.topRightSquare.Location = new Point(10, 0);
                childTopLeftSquare.bottomLeftSquare.Location = new Point(0, 10);
                childTopLeftSquare.bottomRightSquare.Location = new Point(10, 10);
                childTopLeftSquare.topLeftSquare.BackColor = Color.Red;
                childTopLeftSquare.topRightSquare.BackColor = Color.Red;
                childTopLeftSquare.bottomLeftSquare.BackColor = Color.Red;
                childTopLeftSquare.bottomRightSquare.BackColor = Color.Red;
                childTopLeftSquare.Controls.Add(childTopLeftSquare.topLeftSquare);
                childTopLeftSquare.Controls.Add(childTopLeftSquare.topRightSquare);
                childTopLeftSquare.Controls.Add(childTopLeftSquare.bottomLeftSquare);
                childTopLeftSquare.Controls.Add(childTopLeftSquare.bottomRightSquare);
            }
            private void Form1_Load(object sender, EventArgs e)
            {
                root.Click += new EventHandler(square_Click);
                root.Size = new System.Drawing.Size(50, 50);
                root.BackColor = Color.Red;
                this.Controls.Add(root);
            }
        }
        public class ChildSquare : Button
        {
            public Button centerSquare = new Button();
            public Button topLeftSquare = new Button();
            public Button topRightSquare = new Button();
            public Button bottomLeftSquare = new Button();
            public Button bottomRightSquare = new Button();
        }
    }
