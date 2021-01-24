        public double NewCalculatedColumn 
        { 
            get 
            {
                // you can provide a dynamic expression which contains col1, col2 and col3
                //TODO: add exception handling
                var e = new Expression($"(col1 * col2)/{col3}");
                e.Parameters["col1"] = Column1;
                e.Parameters["col2"] = Column2;
                e.Parameters["col3"] = Column3;
                return e.Evaluate();
            }
        }   
