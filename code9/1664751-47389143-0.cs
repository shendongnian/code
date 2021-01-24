    public override bool Equals(Book otherBook)
        {
            bool result;
            if (this.ISBN == otherBook.ISBN)
            {
                result = true;
            }
            else
            {
                result = false;
            }
    
            return result;
        }
