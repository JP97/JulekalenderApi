using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JulekalenderApi.Models;

namespace JulekalenderApi.Data
{
    public class JulekalenderApiContext : DbContext
    {
        public JulekalenderApiContext (DbContextOptions<JulekalenderApiContext> options)
            : base(options)
        {
        }

        public DbSet<Tipp> Tipps { get; set; }
    }
}
