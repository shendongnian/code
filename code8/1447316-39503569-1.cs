        // Summary:
        //     Enters the text in the textbox. The text would be cleared first. This is
        //     not as good performing as the BulkText method. This does raise all keyboard
        //     events - that means that your string will consist of letters that match the
        //     letters of your string but in current input language.
        public virtual string Text { get; set; }
