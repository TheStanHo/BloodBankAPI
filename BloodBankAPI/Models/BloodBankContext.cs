using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BloodBankAPI.Models
{
    public class BloodBankContext :  DbContext
    {

        public BloodBankContext(DbContextOptions <BloodBankContext> options) :base(options) { }

        protected override void OnModelCreating(ModelBuilder builder )
        {
            base.OnModelCreating(builder);
         
        }

        public DbSet<BloodDB> BloodDB { get; set; }
    }
}
