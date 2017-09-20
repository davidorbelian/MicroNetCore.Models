using System;
using System.Collections.Generic;
using System.Linq;

namespace MicroNetCore.Models.Collections
{
    public sealed class ModelTypeList : List<Type>, IModelTypeList
    {
        public ModelTypeList(IEnumerable<Type> types)
            : base(ValidateTypes(types))
        {
        }

        private static IEnumerable<Type> ValidateTypes(IEnumerable<Type> types)
        {
            return types.Where(IsDataModelType);
        }

        private static bool IsDataModelType(Type type)
        {
            return typeof(IModel).IsAssignableFrom(type);
        }
    }
}