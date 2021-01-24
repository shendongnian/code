        public override void Add (object list)
        {
            IEnumerable castList = list as IEnumerable;
            if (castList != null)
            {
                IEnumerable<T> typedList = castList.OfType<T>();
                this.ReturnedData.AddRange(typedList);
            }
        }
