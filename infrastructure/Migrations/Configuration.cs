using Infrastructure.Controller;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Text;

internal sealed class Configuration : DbMigrationsConfiguration<ControllersContext>
{
    public Configuration()
    {
        AutomaticMigrationsEnabled = false;
    }

    protected override void Seed(ControllersContext context)
    {
        //  This method will be called after migrating to the latest version.

        //  You can use the DbSet<T>.AddOrUpdate() helper extension method
        //  to avoid creating duplicate seed data.
    }
}
