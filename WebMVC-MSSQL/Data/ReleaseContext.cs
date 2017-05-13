using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebMVC_MSSQL.Models;

    public class ReleaseContext : DbContext
    {
        public ReleaseContext (DbContextOptions<ReleaseContext> options)
            : base(options)
        {
        }

        public DbSet<WebMVC_MSSQL.Models.Release> Release { get; set; }
        public DbSet<WebMVC_MSSQL.Models.ReleaseNote> ReleaseNotes { get; set; }
}
