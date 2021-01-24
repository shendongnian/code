    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Windows.Forms;
    
    namespace WindowsForms {
       public partial class Form1 : Form {
    
          object key = new object();
          private List<string> items;
          public Form1() {
    
             InitializeComponent();
             items = new List<string>();
             for( int i = 0; i < 100000; i++ ) {
                this.items.Add( i.ToString() );
             }
             this.listBox1.DataSource = this.items;
          }
    
          private void Read() {
    
             foreach( var thisItem in this.items ) {
                if (thisItem.ToString() == "100000" ) {
                   MessageBox.Show( "Found" );
                }
                else {
                   Thread.Sleep( 100 );
                }
             }
          }
    
          private void buttonStation2_Click(object sender, EventArgs e) {
             lock( this.key ) {
                var copy = new List<string>( this.items );
                copy.Add( "1000001" );
                this.items = copy;
             }
          }
    
          private void Form1_Shown(object sender, EventArgs e) {
             Thread reader = new Thread( Read );
             reader.Start();
          }
       }
    }
