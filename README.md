# A "MySQL:AutoIncrement" anotation is missing from the generated migration code if an owned property in the model precedes a key

## Description

The model "Bar" has an owned entity "Baz" and a key "BarId" :

```csharp
public class Bar {
    public Baz Baz { get; set; } // the first property is an owned property
    public int BarId { get; set; } // the second property is a key
}

public class Baz {
    public int Data { get; set; }
}

public class MyContext : DbContext {
    public DbSet<Bar> Bars { get; set; }

    public MyContext() { }
    public MyContext(DbContextOptions<MyContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        bas.OnModelCreating(modelBuilder);
        var etb = modelBuilder.Entity<Bar>();
        etb.Property(e => e.BarId);
        etb.HasKey(e => e.BarId);
        etb.OwnsOne(e => e.Baz, rob => rob.Property(e => e.Data));
    }
}
```

Running "<code>dotnet ef migrations add InitialCreate</code>" generates the floowing code:

```csharp
public partial class InitialCreate : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Bars",
            columns: table => new
            {
                Baz_Data = table.Column<int>(nullable: false),
                BarId = table.Column<int>(nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Bars", x => x.BarId);
            });
    }
    // (snip)
}
```

But it is wrong because the "BarId" column should have a "MySQL:AutoIncrement" annotation.  What I expected is that:

```csharp
public partial class InitialCreate : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Bars",
            columns: table => new
            {
                Baz_Data = table.Column<int>(nullable: false),
                BarId = table.Column<int>(nullable: false)
                    .Annotation("MySQL:AutoIncrement", true) // here!
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Bars", x => x.BarId);
            });
    }
    // (snip)
}
```

On the contrary, the "MySQL:AutoIncrement" annotation is generated correctly if the first property is a key and the second property is an owned property.

FYI: Pomelo.EntityFrameworkCore.MySql generates a migration with an appropriate annotation.

## How to repeat

An complete reprodusable source is here: https://github.com/ganaware/TestMySqlDataMissingAutoIncrementAnnotation

1. Clone: https://github.com/ganaware/TestMySqlDataMissingAutoIncrementAnnotation
2. Remove: "Migrations" directory
3. Run: <code>dotnet ef migrations add InitialCreate</code>
4. Examine: Migrations/*_InitialCreate.cs

FYI: the generated migration code by Pomelo.EntityFrameworkCore.MySql is here: https://github.com/ganaware/TestMySqlDataMissingAutoIncrementAnnotation/tree/pomelo