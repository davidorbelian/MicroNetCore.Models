namespace MicroNetCore.Models
{
    public interface IRelationModel : IModel
    {
        long Entity1Id { get; set; }
        long Entity2Id { get; set; }
    }

    public interface IRelationModel<T1, T2> : IRelationModel
        where T1 : class, IEntityModel
        where T2 : class, IEntityModel
    {
        T1 Entity1 { get; set; }
        T2 Entity2 { get; set; }
    }
}