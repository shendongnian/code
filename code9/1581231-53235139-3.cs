    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Reflection.Emit;
    using System.IO;
    namespace ConsoleCommon
    {
    public interface IBaseObject
    {
        IEmptyObject AddPassThroughCtors(Type parentType);
    }
    public interface IEmptyObject
    {
        IAfterProperty AddProperty(string name, Type type);
    }
    public interface IAfterProperty : IEmptyObject, IFinishBuild
    {
        IAfterAttribute AddPropertyAttribute(Type attrType, Type[] ctorArgTypes, params object[] ctorArgs);
    }
    public interface IAfterAttribute : IEmptyObject, IFinishBuild
    {
    }
    public interface IFinishBuild
    {
        Type FinishBuildingType();
        Type FinishBuildingAndSaveType(string assemblyFileName);
    }
    public static class DynamicTypeCreator
    {
        public static IBaseObject Create(string className)
        {
            return new DynamicTypeCreatorBase().Create(className);
        }
        public static IBaseObject Create(string className, string dir)
        {
            return new DynamicTypeCreatorBase().Create(className, dir);
        }
    }
    public class PropertyBuilding
    {
        public PropertyBuilding(PropertyBuilder propertyBuild, MethodBuilder getBuild, MethodBuilder setBuild)
        {
            propertyBuilder = propertyBuild;
            getBuilder = getBuild;
            setBuilder = setBuild;
        }
        public PropertyBuilder propertyBuilder { get; }
        public MethodBuilder getBuilder { get; }
        public MethodBuilder setBuilder { get; }
    }
    public class DynamicTypeCreatorBase : IBaseObject, IEmptyObject, IAfterProperty, IAfterAttribute
    {
        TypeBuilder _tBuilder;
        List<PropertyBuilding> _propBuilds = new List<PropertyBuilding>();
        AssemblyBuilder _aBuilder;
        /// <summary>
        /// Begins creating type using the specified name.
        /// </summary>
        /// <param name="className">Class name for new type</param>
        /// <returns></returns>
        public IBaseObject Create(string className)
        {
            return Create(className, "");
        }
        /// <summary>
        /// Begins creating type using the specified name and saved in the specified directory.
        /// Use this overload to save the resulting .dll in a specified directory.
        /// </summary>
        /// <param name="className">Class name for new type</param>
        /// <param name="dir">Directory path to save .dll in</param>
        /// <returns></returns>
        public IBaseObject Create (string className, string dir)
        {
            //Define type
            AssemblyName _name = new AssemblyName(className);
            if (string.IsNullOrWhiteSpace(dir))
            {
                _aBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(_name, AssemblyBuilderAccess.RunAndSave);
            }
            else _aBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(_name, AssemblyBuilderAccess.RunAndSave, dir);
            ModuleBuilder _mBuilder = _aBuilder.DefineDynamicModule(_name.Name, _name.Name + ".dll");
            _tBuilder = _mBuilder.DefineType(className, TypeAttributes.Public | TypeAttributes.Class, typeof(ParamsObject));
            return this;
        }
        /// <summary>
        /// Adds constructors to new type that match all constructors on base type.
        /// Parameters are passed to base type.
        /// </summary>
        /// <param name="parentType">Type of base class. Use object if none</param>
        /// <returns></returns>
        public IEmptyObject AddPassThroughCtors(Type parentType)
        {
            foreach(ConstructorInfo _ctor in parentType.GetConstructors(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
            {
                ParameterInfo[] _params = _ctor.GetParameters();
                Type[] _paramTypes = _params.Select(p => p.ParameterType).ToArray();
                Type[][] _reqModifiers = _params.Select(p => p.GetRequiredCustomModifiers()).ToArray();
                Type[][] _optModifiers = _params.Select(p => p.GetOptionalCustomModifiers()).ToArray();
                ConstructorBuilder _ctorBuild = _tBuilder.DefineConstructor(MethodAttributes.Public, _ctor.CallingConvention, _paramTypes, _reqModifiers, _optModifiers);
                for (int i = 0; i < _params.Length; i++)
                {
                    ParameterInfo _param = _params[i];
                    ParameterBuilder _prmBuild = _ctorBuild.DefineParameter(i + 1, _param.Attributes, _param.Name);
                    if (((int)_param.Attributes & (int)ParameterAttributes.HasDefault) != 0) _prmBuild.SetConstant(_param.RawDefaultValue);
                    foreach(CustomAttributeBuilder _attr in GetCustomAttrBuilders(_param.CustomAttributes))
                    {
                        _prmBuild.SetCustomAttribute(_attr);
                    }
                }
                //ConstructorBuilder _cBuilder = _tBuilder.DefineConstructor(MethodAttributes.Public, CallingConventions.Any, argTypes);
                ILGenerator _ctorGen = _ctorBuild.GetILGenerator();
                _ctorGen.Emit(OpCodes.Nop);
                //arg0=new obj, arg1-arg3=passed params. Push onto stack for call to base class
                _ctorGen.Emit(OpCodes.Ldarg_0);
                for (int i = 1; i <= _params.Length; i++) _ctorGen.Emit(OpCodes.Ldarg, i);
                _ctorGen.Emit(OpCodes.Call, _ctor);
                _ctorGen.Emit(OpCodes.Ret);
            }
            return this;
        }
        /// <summary>
        /// Adds a new property to type with specified name and type.
        /// </summary>
        /// <param name="name">Name of property</param>
        /// <param name="type">Type of property</param>
        /// <returns></returns>
        public IAfterProperty AddProperty(string name, Type type)
        {
            //base property
            PropertyBuilder _pBuilder = _tBuilder.DefineProperty(name, PropertyAttributes.None, type, new Type[0] { });
            //backing field
            FieldBuilder _fBuilder = _tBuilder.DefineField($"m_{name}", type, FieldAttributes.Private);
            
            //get method
            MethodAttributes _propAttrs = MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.HideBySig;
            MethodBuilder _getBuilder = _tBuilder.DefineMethod($"get_{name}", _propAttrs, type, Type.EmptyTypes);
            ILGenerator _getGen = _getBuilder.GetILGenerator();
            _getGen.Emit(OpCodes.Ldarg_0);
            _getGen.Emit(OpCodes.Ldfld, _fBuilder);
            _getGen.Emit(OpCodes.Ret);
            //set method
            MethodBuilder _setBuilder = _tBuilder.DefineMethod($"set_{name}", _propAttrs, null, new Type[] { type });
            ILGenerator _setGen = _setBuilder.GetILGenerator();
            _setGen.Emit(OpCodes.Ldarg_0);
            _setGen.Emit(OpCodes.Ldarg_1);
            _setGen.Emit(OpCodes.Stfld, _fBuilder);
            _setGen.Emit(OpCodes.Ret);
            _propBuilds.Add(new PropertyBuilding(_pBuilder, _getBuilder, _setBuilder));
            return this;
        }
        /// <summary>
        /// Adds an attribute to a property just added.
        /// </summary>
        /// <param name="attrType">Type of attribute</param>
        /// <param name="ctorArgTypes">Types of attribute's cstor parameters</param>
        /// <param name="ctorArgs">Values to pass in to attribute's cstor. Must match in type and order of cstorArgTypes parameter</param>
        /// <returns></returns>
        public IAfterAttribute AddPropertyAttribute(Type attrType, Type[] ctorArgTypes, params object[] ctorArgs)
        {
            if (ctorArgTypes.Length != ctorArgs.Length) throw new Exception("Type count must match arg count for attribute specification");
            ConstructorInfo _attrCtor = attrType.GetConstructor(ctorArgTypes);
            for (int i = 0; i < ctorArgTypes.Length; i++)
            {
                CustomAttributeBuilder _attrBuild = new CustomAttributeBuilder(_attrCtor, ctorArgs);
                _propBuilds.Last().propertyBuilder.SetCustomAttribute(_attrBuild);
            }
            return this;
        }
        /// <summary>
        /// Completes building type, compiles it, and returns the resulting type
        /// </summary>
        /// <returns></returns>
        public Type FinishBuildingType()
        {
            foreach(var _pBuilder in _propBuilds)
            {
                _pBuilder.propertyBuilder.SetGetMethod(_pBuilder.getBuilder);
                _pBuilder.propertyBuilder.SetSetMethod(_pBuilder.setBuilder);
            }
            
            Type _paramsType = _tBuilder.CreateType();
            return _paramsType;
        }
        /// <summary>
        /// Completes building type, compiles it, saves it, and returns the resultying type.
        /// Assembly is saved in the calling assembly's directory or in the dir specified in the Create method.
        /// </summary>
        /// <param name="assemblyFileName">Filename of the assembly</param>
        /// <returns></returns>
        public Type FinishBuildingAndSaveType(string assemblyFileName)
        {
            Type _newType = FinishBuildingType();
            Save(assemblyFileName);
            return _newType;
        }
        #region Helpers
        private CustomAttributeBuilder[] GetCustomAttrBuilders(IEnumerable<CustomAttributeData> customAttributes)
        {
            return customAttributes.Select(attribute => {
                object[] attributeArgs = attribute.ConstructorArguments.Select(a => a.Value).ToArray();
                PropertyInfo[] namedPropertyInfos = attribute.NamedArguments.Select(a => a.MemberInfo).OfType<PropertyInfo>().ToArray();
                object[] namedPropertyValues = attribute.NamedArguments.Where(a => a.MemberInfo is PropertyInfo).Select(a => a.TypedValue.Value).ToArray();
                FieldInfo[] namedFieldInfos = attribute.NamedArguments.Select(a => a.MemberInfo).OfType<FieldInfo>().ToArray();
                object[] namedFieldValues = attribute.NamedArguments.Where(a => a.MemberInfo is FieldInfo).Select(a => a.TypedValue.Value).ToArray();
                return new CustomAttributeBuilder(attribute.Constructor, attributeArgs, namedPropertyInfos, namedPropertyValues, namedFieldInfos, namedFieldValues);
            }).ToArray();
        }
        /// <summary>
        /// Requires admin privileges. 
        /// To save in a specified dir, use the Create overload that requires a 'dir' parameter.
        /// </summary>
        /// <param name="assemblyFileName"></param>
        private void Save(string assemblyFileName)
        {
            string _assemblyName = assemblyFileName;
            if (!Path.HasExtension(assemblyFileName) || Path.GetExtension(assemblyFileName).ToLower() != ".dll")
                _assemblyName += ".dll";
            _aBuilder.Save(_assemblyName);
        }
        #endregion
    }
    }
