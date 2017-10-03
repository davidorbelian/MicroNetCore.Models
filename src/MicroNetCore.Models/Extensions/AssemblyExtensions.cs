using System.Linq;
using System.Reflection;
using MicroNetCore.Collections;

namespace MicroNetCore.Models.Extensions
{
    public static class AssemblyExtensions
    {
        public static TypeBundle<IModel> GetModelsTypeBundle(this Assembly assembly)
        {
            return new TypeBundle<IModel>(assembly.GetTypes().Where(t => t.IsModel()));
        }
    }
}