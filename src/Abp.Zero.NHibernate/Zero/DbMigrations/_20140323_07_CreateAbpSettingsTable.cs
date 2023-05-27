using Abp.Data.Migrations.FluentMigrator;
using FluentMigrator;

namespace Abp.Zero.DbMigrations
{
    [Migration(2014032307)]
    public class _20140323_07_CreateAbpSettingsTable : AutoReversingMigration
    {
        public override void Up()
        {
            Create.Table("AbpSettings")
                .WithColumn("Id").AsInt64().NotNullable().PrimaryKey().Identity()
                .WithTenantIdAsNullable()
                .WithNullableUserId()
                .WithColumn("Name").AsAnsiString(128).NotNullable()
                .WithColumn("Value").AsString().NotNullable()
                .WithAuditColumns();
        }
    }
}