Entity Framework - Database Intializer Experiment
==============
This project is for testing the Database Initializer which automatically run after the entity framework connection to database was made.

Prerequisite
----------------
1. Visual Studio on Windows
2. Know how to implement Entity Framework Code First
3. You want to know how to use `MigrateDatabaseToLatestVersion` *Database Initializer*

Before Getting Started
---------------
There are serveral pre-defined database intializer from Microsoft:
1. `CreateDatabaseIfNotExists` *(Default)*
2. `DropCreateDatabaseAlways`
3. `DropCreateDatabaseIfModelChanges`
4. `MigrateDatabaseToLatestVersion`

If the above database initializer isn't suited you, can use *Custom Database Initializer* (Interface `IDatabaseInitializer<T>`) instead.

So, in this project, I'm using `MigrateDatabaseToLatestVersion`. Let's start the real implementation below.

Let's Start!
------------
First, use `enable-migrations` in your project to make a folder *Migrations* (folder `ef\Data\Migrations` in the source code) and `Configuration` class in the folder.

Second, we need to tell our `DbContext` to use specified *Database Initializer*, you need to use `Database.SetInitializer<TestContext>(new MigrateDatabaseToLatestVersion<TestContext, Migrations.Configuration>());` in its constructor, for an example:

```c#
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace ef.Data
{
    public class TestContext : DbContext
    {
        public DbSet<MainTable> MainTables { get; set; }
        public DbSet<SubTable> SubTables { get; set; }

        public TestContext() : base("Test")
        {
            Database.SetInitializer<TestContext>(new MigrateDatabaseToLatestVersion<TestContext, Migrations.Configuration>()); // This line tell the DbContext to use migrate to latest version
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
```
Third, try to make your database have older version from your latest migration or just revert its to the `$InitialVersion` and see how it's worked.

License
-------
No license, you can use this code without my permission.