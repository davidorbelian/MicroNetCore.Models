using System;
using System.Linq;
using System.Reflection;
using MicroNetCore.Models.Exceptions;

namespace MicroNetCore.Models.Extensions
{
    public static class TypeExtensions
    {
        public static bool IsModel(this Type type)
        {
            return typeof(IModel).IsAssignableFrom(type);
        }

        public static bool IsEntityModel(this Type type)
        {
            return typeof(IEntityModel).IsAssignableFrom(type);
        }

        public static bool IsRelationModel(this Type type)
        {
            return typeof(IRelationModel).IsAssignableFrom(type);
        }

        public static Type GetRelationType(this Type relationType, Type originalType)
        {
            var generics = relationType.GetRelationModelGenericArguments();
            return generics[0] == originalType ? generics[1] : generics[0];
        }

        public static PropertyInfo GetRelationProperty(this Type relationType, Type originalType)
        {
            var generics = relationType.GetRelationModelGenericArguments();
            return relationType.GetProperty(generics[0] == originalType ? "Entity2" : "Entity1");
        }

        private static Type[] GetRelationModelGenericArguments(this Type relationType)
        {
            var arguments = relationType
                .GetInterfaces()
                .SingleOrDefault(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IRelationModel<,>))
                ?.GetGenericArguments();

            if (arguments == null || arguments.Length != 2)
                throw new NotRelationModelTypeException(relationType);

            return arguments;
        }
    }
}