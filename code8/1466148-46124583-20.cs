     /// <inheritdoc />
    /// <summary>
    /// Model Binder Provider, it inspects
    /// any model when the request is triggered
    /// </summary>
    public class FormFileModelBinderProvider : IModelBinderProvider
    {
        /// <inheritdoc />
        ///  <summary>
        ///  Inspects a Model for any CommonFile class or Collection with
        ///  same class if exist the FormFileModelBinder initiates
        ///  </summary>
        ///  <param name="context">Model provider context</param>
        ///  <returns>a new Instance o FormFileModelBinder if type is found otherwise null</returns>
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));
            if (!context.Metadata.IsComplexType) return null;
            var isSingleCommonFile = IsSingleCommonFile(context.Metadata.ModelType);
            var isCommonFileCollection = IsCommonFileCollection(context.Metadata.ModelType);
            if (!isSingleCommonFile && !isCommonFileCollection) return null;
            return new FormFileModelBinder();
        }
        /// <summary>
        /// Checks if object type is a CommonFile Collection
        /// </summary>
        /// <param name="modelType">Context Meta data ModelType</param>
        /// <returns>If modelType is a collection of CommonFile returns true otherwise false</returns>
        private static bool IsCommonFileCollection(Type modelType)
        {
            if (typeof(ICommonFileCollection).IsAssignableFrom(modelType))
            {
                return true;
            }
            var hasCommonFileArguments = modelType.GetGenericArguments()
                .AsParallel().Any(t => typeof(ICommonFile).IsAssignableFrom(t));
            if (typeof(IEnumerable).IsAssignableFrom(modelType) && hasCommonFileArguments)
            {
                return true;
            }
            if (typeof(IAsyncEnumerable<object>).IsAssignableFrom(modelType) && hasCommonFileArguments)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Checks if object type is CommonFile or an implementation of ICommonFile
        /// </summary>
        /// <param name="modelType"></param>
        /// <returns></returns>
        private static bool IsSingleCommonFile(Type modelType)
        {
            if (modelType == typeof(ICommonFile) || modelType.GetInterfaces().Contains(typeof(ICommonFile)))
            {
                return true;
            }
            return false;
        }
    }
