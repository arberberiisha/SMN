using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SMN.Data.Entities;

namespace SMN.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Lenda> Lenda { get; set; }
        public DbSet<Ligjerata> Ligjerata { get; set; }
        public DbSet<Mungesat> Mungesa { get; set; }
        public DbSet<Nota> Nota { get; set; }
        public DbSet<Orari> Orari { get; set; }
        public DbSet<Paralelja> Paralelja { get; set; }

        public DbSet<Post> Post { get; set; }

        public DbSet<SmnUser> SmnUser { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
