using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Migrations;
using DhWeb.Models;

namespace DhWeb.Migrations
{
    internal sealed class Configurations : DbMigrationsConfiguration<adminDatabaseEntities>
    {
        public Configurations()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(adminDatabaseEntities context)
        {
            base.Seed(context);
        }
    }
}