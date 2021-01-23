        public OperationResult Update2(MyThing thing)
        {
            var original = _repository.GetOtherThing(thing.Id);
            if (original == null)
            {
                return OperationResult.FromError("Invalid or ID not found of the thing update.");
            }
 
            var result = new OperationResult() { Success = true };
            if (AnyPropertyDiffers(thing, original))
            {
                result.Merge(UpdateThing(thing, original));
                if (!result.HasChanges) return result;
            }
 
            result.Merge(UpdateThingChildren(thing));
            if (!result.HasChanges) return result;
 
            result.Merge(_repository.Recalculate(thing));
            return result;
        }
