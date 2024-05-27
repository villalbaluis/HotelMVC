using System.Data.Entity.Migrations;

namespace Hoteles.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<Hoteles.Models.HotelesContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "Hoteles.Models.HotelesContext";
        }

        protected override void Seed(Hoteles.Models.HotelesContext context)
        { }
    }
}
