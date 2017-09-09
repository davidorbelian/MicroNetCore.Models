using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using MicroNetCore.Models.Markup.Attributes;

namespace MicroNetCore.Models.Markup.Extensions
{
    public static class TypeExtensions
    {
        public static IEnumerable<PropertyInfo> GetAddProperties(this Type type)
        {
            return type.GetTypeInfo().GetProperties().Where(p => p.HasAttribute<AddAttribute>());
        }

        public static IEnumerable<PropertyInfo> GetEditProperties(this Type type)
        {
            return type.GetTypeInfo().GetProperties().Where(p => p.HasAttribute<EditAttribute>());
        }

        public static IEnumerable<PropertyInfo> GetShowProperties(this Type type)
        {
            return type.GetTypeInfo().GetProperties().Where(p => p.HasAttribute<ShowAttribute>());
        }

        public static bool HasAttribute<TAttribute>(this Type type)
            where TAttribute : Attribute
        {
            return type.GetTypeInfo().GetCustomAttributes<TAttribute>().Any();
        }

        public static bool HasAttribute<TAttribute>(this PropertyInfo property)
            where TAttribute : Attribute
        {
            return property.GetCustomAttributes<TAttribute>().Any();
        }
    }
}