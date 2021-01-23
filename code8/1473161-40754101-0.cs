    public abstract class AggregateRoot<T> where T : AggregateRoot<T>
    {
        internal UpdateDefinition<T> UpdateDefinition { get; internal set; }
        internal void Aggregate(UpdateDefinition<T> component)
        {
            if (component == null)
            {
                throw new ArgumentNullException("component");
            }
            if (this.UpdateDefinition == null)
            {
                this.UpdateDefinition = component;
            }
            else
            {
                this.UpdateDefinition = Builders<T>.Update.Combine
                    (this.UpdateDefinition, component);
            }
        }
    }
