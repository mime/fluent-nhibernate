using System;
using FluentNHibernate.Utils;
using FluentNHibernate.Visitors;

namespace FluentNHibernate.MappingModel
{
    [Serializable]
    public class PropertyMapping : ColumnBasedMappingBase
    {
        public PropertyMapping()
            : this(new AttributeStore())
        {}

        public PropertyMapping(AttributeStore underlyingStore)
            : base(underlyingStore)
        {}

        public override void AcceptVisitor(IMappingModelVisitor visitor)
        {
            visitor.ProcessProperty(this);

            foreach (var column in columns)
                visitor.Visit(column);
        }

        public Type ContainingEntityType { get; set; }

        public string Name
        {
            get { return attributes.Get("Name"); }
            set { attributes.Set("Name", value); }
        }

        public string Access
        {
            get { return attributes.Get("Access"); }
            set { attributes.Set("Access", value); }
        }

        public bool Insert
        {
            get { return attributes.Get<bool>("Insert"); }
            set { attributes.Set("Insert", value); }
        }

        public bool Update
        {
            get { return attributes.Get<bool>("Update"); }
            set { attributes.Set("Update", value); }
        }

        public string Formula
        {
            get { return attributes.Get("Formula"); }
            set { attributes.Set("Formula", value); }
        }

        public bool Lazy
        {
            get { return attributes.Get<bool>("Lazy"); }
            set { attributes.Set("Lazy", value); }
        }

        public bool OptimisticLock
        {
            get { return attributes.Get<bool>("OptimisticLock"); }
            set { attributes.Set("OptimisticLock", value); }
        }

        public string Generated
        {
            get { return attributes.Get("Generated"); }
            set { attributes.Set("Generated", value); }
        }

        public TypeReference Type
        {
            get { return attributes.Get<TypeReference>("Type"); }
            set { attributes.Set("Type", value); }
        }

        public Member Member { get; set; }

        public bool Equals(PropertyMapping other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) &&
                Equals(other.ContainingEntityType, ContainingEntityType) &&
                Equals(other.Member, Member);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof(PropertyMapping)) return false;
            return Equals((PropertyMapping)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((ContainingEntityType != null ? ContainingEntityType.GetHashCode() : 0) * 397) ^ (Member != null ? Member.GetHashCode() : 0);
            }
        }
    }
}