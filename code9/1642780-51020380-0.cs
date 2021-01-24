        private void Reset()
        {
            if (this.GetType() == typeof(ContextElement))
            {
                Debug.LogError("ContextElement Can't add itself on GameObject!");
                DestroyImmediate( this );
            }
        }
