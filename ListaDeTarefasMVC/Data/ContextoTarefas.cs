using ListaDeTarefasMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace ListaDeTarefasMVC.Data
{
    public class ContextoTarefas : DbContext
    {
        public ContextoTarefas(DbContextOptions<ContextoTarefas> options) :base(options) 
        {
        }
        public DbSet<TarefaModel> Tarefas { get; set; }
    }
}
