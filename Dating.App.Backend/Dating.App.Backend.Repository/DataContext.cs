﻿using Dating.App.Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Dating.App.Backend.Repository
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options) { }

        public DbSet<Value> Values { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Photo> Photos { get; set; }
    }
}
