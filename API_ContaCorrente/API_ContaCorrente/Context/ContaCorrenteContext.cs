using API_ContaCorrente.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_ContaCorrente.Context
{
    public class ContaCorrenteContext : DbContext
    {
        public ContaCorrenteContext(DbContextOptions<ContaCorrenteContext>options)
            : base(options)
        {
        }


        public DbSet<ContaCorrente> contaCorrentes { get; set; }
    }
}
