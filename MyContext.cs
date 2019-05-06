using Microsoft.EntityFrameworkCore;

namespace TestMySqlDataMissingAutoIncrementAnnotation {
    public class Foo {
        public int FooId { get; set; }
        public Baz Baz { get; set; }
    }

    public class Bar {
        public Baz Baz { get; set; }
        public int BarId { get; set; }
    }

    public class Baz {
        public int Data { get; set; }
    }

    public class MyContext : DbContext {
        public DbSet<Foo> Foos { get; set; }
        public DbSet<Bar> Bars { get; set; }

        public MyContext() { }

        public MyContext(DbContextOptions<MyContext> options)
            : base(options) {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            if (!optionsBuilder.IsConfigured) {
                optionsBuilder.UseMySql(
                    "Host=localhost",
                    o => {
                        o.MigrationsAssembly("TestMySqlDataMissingAutoIncrementAnnotation");
                    });
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            {
                var etb = modelBuilder.Entity<Foo>();
                etb.Property(e => e.FooId);
                etb.HasKey(e => e.FooId);
                etb.OwnsOne(e => e.Baz, rob => rob.Property(e => e.Data));
            }
            {
                var etb = modelBuilder.Entity<Bar>();
                etb.Property(e => e.BarId);
                etb.HasKey(e => e.BarId);
                etb.OwnsOne(e => e.Baz, rob => rob.Property(e => e.Data));
            }
        }
    }
}
