using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessCardAPI.Models
{
    public class BusinessCardContext:DbContext
    {
        public BusinessCardContext(DbContextOptions<BusinessCardContext> options) 
        :base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<BusinessCard> businessCards { get; set; }
    }
}
