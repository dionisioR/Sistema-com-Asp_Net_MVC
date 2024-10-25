using Sistema.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Sistema.Context {
    public class LojaContext : DbContext {

        // Fazendo a associação com o modelo Produto
        public DbSet<Produto> Produto { get; set; }
    }
}