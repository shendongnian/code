        TileSelect _selectedTile;
        public TileSelect selectedTile
        {
            get { return _selectedTile; }
            set 
            {  
                //unhighlight the previous selected tile
                _selectedTile = value;
                //highlight the newly selected tile
            }
        }
        ...
    }
