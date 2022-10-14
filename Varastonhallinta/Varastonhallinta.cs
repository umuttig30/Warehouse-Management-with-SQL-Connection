using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore; // Tietokantaa varten, asenna nuget packagesta


namespace Varastonhallinta
{
    public class Varastonhallintaa : DbContext
    {
        public DbSet<Tuote>? Tuotteet { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connection = "Data Source=.;" +
                "Initial Catalog=Varastonhallinta;" +
                "Integrated Security=true;" +
                "MultipleActiveResultSets=true;";

            //Tässä otetaan yhteys tietokantaan
            optionsBuilder.UseSqlServer(connection);
        }


    }
}
