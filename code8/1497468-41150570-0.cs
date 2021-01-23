    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    
    namespace _41150122
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void btn_Go_Click(object sender, EventArgs e)
            {
                MakeItHappen();
            }
    
            private void MakeItHappen()
            {
                List<Customer> customerList = new List<Customer>();//initialize your List<Customer>
                customerList.Add(new Customer { Name = txtbx_Name.Text, Address1 = txtbx_Address1.Text, Age = int.Parse(txtbx_Age.Text) });//add a record to it
            }
        }
    
    
    
        public class Customer
        {
            private string name;
            private Int32 age;
            private string address1;
            private string address2;
            private string address3;
    
    
            public string Name
            {
                get
                {
                    return name;
                }
    
                // if name is blank throw argument asking user for input
    
                set
                {
                    if (name == "")
                    {
                        throw new ArgumentException("Please enter your name");
                    }
                    else
                    {
                        name = value;
                    }
                }
            }
    
            public Int32 Age
            {
                get
                {
                    return age;
                }
    
                set
                {
                    age = value;
                }
            }
    
    
            // get/set address
    
            public string Address1
            {
                get
                {
                    return address1;
                }
    
                set
                {
                    if (address1 == "")
                    {
                        throw new ArgumentException("Please enter your address");
                    }
                    else
                    {
                        address1 = value;
                    }
                }
            }
    
            public string Address2
            {
                get
                {
                    return address2;
                }
    
                set
                {
                    if (address2 == "")
                    {
                        throw new ArgumentException("Please enter your adress");
                    }
                    else
                    {
                        address2 = value;
                    }
                }
            }
    
            public string Address3
            {
                get
                {
                    return address3;
                }
    
    
                set
                {
                    if (address3 == "")
                    {
                        throw new ArgumentException("Please enter your adress");
                    }
                    else
                    {
                        address3 = value;
                    }
                }
            }
    
    
        }
    }
