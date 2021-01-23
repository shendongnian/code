        // We a scope class shared by all services, 
        // we don't need to create a result or decide what result to use. 
        // It is more whether it worked or didn't 
        public void UpdateWithScope(MyThing thing)
        { 
            var original = _repository.GetOtherThing(thing.Id);
            if (_workScope.HasErrors) return;
            if (original == null)
            {
                _workScope.AddError("Invalid or ID not found of the thing update.");
                return;
            }
            if (AnyPropertyDiffers(thing, original))
            {
                UpdateThing(thing, original);
                if (_workScope.HasErrors) return;
            }
            UpdateThingChildren(thing);
            if (_workScope.HasErrors) return;
            _repository.Recalculate(thing);
        }
		
