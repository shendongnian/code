    IConsoleBuilder { // actual implementation write to console
        RegisterCommand(string command, Func<string[], string> action); 
    }
    
    InventoryConsoleBuilder : ConsoleBuilderClient { 
        InventoryConsoleBuilder(IConsoleWriter writer){ _writer = writer; } 
    
        public override void Show(IInventory inventory) { 
            writer.RegisterCommand(inventoryComposed) ; 
        }
    }
