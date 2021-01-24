    using MongoDB.Bson.IO;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace Fishing.MongoDB.Serializers
    {
        public class InternalJsonWriterContext
        {
            // private fields
            private InternalJsonWriterContext _parentContext;
            private ContextType _contextType;
            private string _indentation;
            private bool _hasElements = false;
    
            // constructors
            internal InternalJsonWriterContext(InternalJsonWriterContext parentContext, ContextType contextType, string indentChars)
            {
                _parentContext = parentContext;
                _contextType = contextType;
                _indentation = (parentContext == null) ? indentChars : parentContext.Indentation + indentChars;
            }
    
            // internal properties
            internal InternalJsonWriterContext ParentContext
            {
                get { return _parentContext; }
            }
    
            internal ContextType ContextType
            {
                get { return _contextType; }
            }
    
            internal string Indentation
            {
                get { return _indentation; }
            }
    
            internal bool HasElements
            {
                get { return _hasElements; }
                set { _hasElements = value; }
            }
        }
    }
