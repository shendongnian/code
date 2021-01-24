        private void Reset()
        {
            if (this.GetType() == typeof(MyCustomClass))
            {
                DestroyImmediate( this );
            }
        }
