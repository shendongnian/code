     Private void ReadProButton(Object context) {           
            Controls.Button btnClicked = Nothing            
            btnClicked = CType(context, System.Windows.Controls.Button)
            processName = btnClicked.Name
            ...
     }
