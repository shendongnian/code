        /// <summary>
        /// Extenders of Freezable call this to set in a new value for internal
        /// properties or other embedded values that themselves are DependencyObjects.
        /// This method insures that the appropriate context pointers are set up for
        ///  the old and the new Dependency objects.
        ///
        /// In this version the property is set to be null since
        /// it is not explicitly specified.
        ///
        /// </summary>
        /// <param name="oldValue">The previous value of the property.</param>
        /// <param name="newValue">The new value to set into the property</param>
        protected void OnFreezablePropertyChanged(
            DependencyObject oldValue,
            DependencyObject newValue
            )
        {
            OnFreezablePropertyChanged(oldValue, newValue, null);
        }
 
        /// <summary>
        /// Extenders of Freezable call this to set in a new value for internal
        /// properties or other embedded values that themselves are DependencyObjects.
        /// This method insures that the appropriate context pointers are set up for
        /// the old and the new DependencyObject objects.
        /// </summary>
        /// <param name="oldValue">The previous value of the property.</param>
        /// <param name="newValue">The new value to set into the property</param>
        /// <param name="property">The property that is being changed or null if none</param>
        protected void OnFreezablePropertyChanged(
            DependencyObject oldValue,
            DependencyObject newValue,
            DependencyProperty property
            )
        {
            // NTRAID#Longhorn-1023842 -4/27/2005-Microsoft
            //
            //    We should ensure dispatchers are consistent *before* modifying
            //    changed handlers, otherwise we will leave the freezable in an
            //    inconsistent state.
            //
            if (newValue != null)
            {
                EnsureConsistentDispatchers(this, newValue);
            }
 
            if (oldValue != null)
            {
                RemoveSelfAsInheritanceContext(oldValue, property);
            }
 
            if (newValue != null)
            {
                ProvideSelfAsInheritanceContext(newValue, property);
            }
        }
