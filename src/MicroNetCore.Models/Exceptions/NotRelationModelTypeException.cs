using System;

namespace MicroNetCore.Models.Exceptions
{
    public sealed class NotRelationModelTypeException : Exception
    {
        public NotRelationModelTypeException(Type type) : base($"{type.Name} is not a RelationModel.")
        {
            Type = type;
        }

        public Type Type { get; }
    }
}