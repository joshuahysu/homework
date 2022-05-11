using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using homework.Models;

namespace homework.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<homework.Models.Movie> Movie { get; set; }
        public DbSet<homework.Models.Movie1> Movie1 { get; set; }
        public DbSet<homework.Models.DappertestModel> DappertestModel { get; set; }
    }
}
