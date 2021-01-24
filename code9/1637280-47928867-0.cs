            /// <summary>
            /// Order data by given <see cref="propertyName"/>. Note that this is used mainly for following filtering queries and due to firebase implementation
            /// the data may actually not be ordered.
            /// </summary>
            /// <param name="child"> The child. </param>
            /// <param name="propertyName"> The property name. </param>
            /// <returns> The <see cref="OrderQuery"/>. </returns>
            public static OrderQuery OrderBy(this ChildQuery child, string propertyName)
            {
                return child.OrderBy(() => propertyName);
            }
