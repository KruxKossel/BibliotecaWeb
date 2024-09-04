using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BibliotecaWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaWeb.Database
{
    public class BibliotecaDbContext(DbContextOptions<BibliotecaDbContext> options) : DbContext(options)
    {
        public DbSet<Livro> Livros { get; set; }
    }
}