using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace satisfaction
{
    public class SatisfactionContext : DbContext
    {
        public SatisfactionContext() : base("name=SatisfactionConnectionString")
        {

        }
        public DbSet<Rating> Ratings { get; set; }
    }
}
