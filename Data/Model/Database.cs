using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    public class Database : DbContext
    {
        public DbSet<Reciept> Reciepts {get;set;}
    }
}
