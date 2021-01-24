    public void setColor(string col){
        if (Enum.GetNames(typeof(Color)).Contains(col)) {
            color = (Color)Enum.Parse(typeof(Color), col);
        }
    }
