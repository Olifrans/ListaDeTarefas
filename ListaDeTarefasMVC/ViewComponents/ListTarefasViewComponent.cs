using ListaDeTarefasMVC.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ListaDeTarefasMVC.ViewComponents
{
    public class ListTarefasViewComponent : ViewComponent
    {
        private readonly ContextoTarefas _context;
        public ListTarefasViewComponent(ContextoTarefas context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(string date)
        {
            return View(await _context.Tarefas
                .OrderBy(x => x.Horario)
                .Where(f => f.Data == date)
                .ToListAsync());
        }
    }
}
