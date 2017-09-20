using System.Collections.Generic;

namespace MicroNetCore.Models.Collections
{
    public sealed class ModelList : List<IModel>, IModelList
    {
        public ModelList(IEnumerable<IModel> models)
            : base(models)
        {
        }
    }
}