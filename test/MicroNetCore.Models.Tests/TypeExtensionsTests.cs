using System;
using MicroNetCore.Models.Exceptions;
using MicroNetCore.Models.Extensions;
using Xunit;

namespace MicroNetCore.Models.Tests
{
    public sealed class TypeExtensionsTests
    {
        private sealed class ClassOne : IEntityModel
        {
            public long Id { get; } = 1;
        }

        private sealed class ClassTwo : IEntityModel
        {
            public long Id { get; } = 1;
        }

        private sealed class ClassRelation : IRelationModel<ClassOne, ClassTwo>
        {
            public long Entity1Id { get; set; }
            public long Entity2Id { get; set; }
            public ClassOne Entity1 { get; set; }
            public ClassTwo Entity2 { get; set; }
        }

        [Fact]
        public void GetRelationPropertyWithInvalidType()
        {
            var exception = Assert.Throws<NotRelationModelTypeException>((Action) Action);
            Assert.Equal(exception.Type, typeof(ClassOne));

            void Action()
            {
                typeof(ClassOne).GetRelationProperty(typeof(ClassTwo));
            }
        }

        [Fact]
        public void GetRelationPropertyWithValidType()
        {
            Assert.Equal("Entity1", typeof(ClassRelation).GetRelationProperty(typeof(ClassTwo)).Name);
        }

        [Fact]
        public void GetRelationTypeWithInvalidType()
        {
            var exception = Assert.Throws<NotRelationModelTypeException>((Action) Action);
            Assert.Equal(exception.Type, typeof(ClassOne));

            void Action()
            {
                typeof(ClassOne).GetRelationType(typeof(ClassTwo));
            }
        }

        [Fact]
        public void GetRelationTypeWithValidType()
        {
            Assert.Equal(typeof(ClassOne), typeof(ClassRelation).GetRelationType(typeof(ClassTwo)));
        }
    }
}