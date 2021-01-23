    public class OperationResult
    {
        public bool Success { get; set; }
        public List<string> Errors { get; set;  } = new List<string>();
    }
    public class Thing { public string Id { get; set; } }
    public class OperationException : Exception
    {
        public OperationException(string error = null)
        {
            if (error != null)
                Errors.Add(error);
        }
    
        public List<string> Errors { get; set; } = new List<string>();
    }
    
    public class Operation
    {
        public OperationResult Update(Thing thing)
        {
            var result = new OperationResult { Success = true };
            try
            {
                UpdateInternal(thing);
            }
            catch(OperationException e)
            {
                result.Success = false;
                result.Errors = e.Errors;
            }
    
            return result;
        }
    
        private void UpdateInternal(Thing thing)
        {
            if (thing.Id == null)
                throw new OperationException("Could not find ID of the thing update.");
    
            var original = _repository.GetOtherThing(thing.Id);
            if (original == null)
                return;
    
            if (AnyPropertyDiffers(thing, original))
                result.Merge(UpdateThing(thing, original));
    
            result.Merge(UpdateThingChildren(thing));
    
            if (result.HasChanges)
                _repository.Recalculate(thing);
        }
    }
