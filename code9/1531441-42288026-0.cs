    // Using Statements.
    
    namespace MyNameSpace
    {
        public class MyControl : TableLayoutPanel
        {
            // Declare instances of the controls you need.
            CustomDataGridView myDataGridControl;
            Button button1;
            Button button2;
            // etc...
            public MyControl()
            {
                // Define TableLayoutPanel properties here,
                // e.g. columns, rows, sizing...
                
                myDataGridControl = new CustomDataGridView();
                // Define your custom DataGridView here.
                button1 = new Button();
                // First button properties.
                button2 = new Button();
                // Second button properties.
                // Assign these controls to TableLayoutPanel
                // in the specified cells.
                Controls.Add(myDataGridControl, 0, 0);
                Controls.Add(button1, 0, 1);
                Controls.Add(button2, 1, 1);
            }
            // Methods etc...
        }
    }
