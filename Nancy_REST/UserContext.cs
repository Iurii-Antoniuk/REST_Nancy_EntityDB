using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace Nancy_REST
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(@"Data Source=LOCALHOST\SQLEXPRESS;Initial Catalog=Nancy_REST;Integrated Security=True; MultipleActiveResultSets=True");
        }
    }
}
