    SimpleSheet sSheet = new SimpleSheet(new System.Collections.Generic.List<string>() { "option1", "option2" });
    				sSheet.Selected += (selectedValue) => {
    					Console.WriteLine("SelectedValue = "+selectedValue);
    				};
    				sSheet.Show(this.View);
