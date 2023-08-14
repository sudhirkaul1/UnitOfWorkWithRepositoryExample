﻿using Microsoft.EntityFrameworkCore;
using UnitOfWorkWithRepository.Models;

namespace UnitOfWorkWithRepository.Data
{
    public class AppDbContext : DbContext
    {
       
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
        public DbSet<Customer> Customer { get; set; }

    }

}
