using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Data.Entity.Migrations.Infrastructure;
using System.Linq;

namespace ef.Data
{
    public class TestDbInitializer : CreateDatabaseIfNotExists<TestContext>
    {
        public override void InitializeDatabase(TestContext context)
        {
            if (!context.Database.Exists() || !context.Database.CompatibleWithModel(false))
            {
                bool isSeed = context.Database.CreateIfNotExists();
                var configuration = new Migrations.Configuration();
                var migrator = new DbMigrator(configuration);
                migrator.Configuration.TargetDatabase = new DbConnectionInfo(context.Database.Connection.ConnectionString, "System.Data.SqlClient");
                var migrations = migrator.GetPendingMigrations();
                if (migrations.Any())
                {
                    var scriptor = new MigratorScriptingDecorator(migrator);
                    var script = scriptor.ScriptUpdate(null, migrations.Last());

                    if (!string.IsNullOrEmpty(script))
                    {
                        context.Database.ExecuteSqlCommand(script);
                    }
                }

                if (isSeed)
                {
                    Seed(context);
                }
            }
        }

        protected override void Seed(TestContext context)
        {
            base.Seed(context);
        }
    }
}