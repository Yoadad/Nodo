namespace Nodo.Entities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class NodoModel : DbContext
    {
        public NodoModel()
            : base("name=NdModel")
        {
        }

        public virtual DbSet<Node> Nodes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Node>()
                .HasMany(e => e.Node1)
                .WithMany(e => e.Nodes)
                .Map(m => m.ToTable("Relation").MapLeftKey("ParentId").MapRightKey("ChildId"));
        }
    }
}
