using ListaDeTarefasMVC.Data;
using ListaDeTarefasMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ListaDeTarefasMVC.Controllers
{
    public class TarefasController : Controller
    {        
        private readonly ContextoTarefas _context;
        public TarefasController(ContextoTarefas context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(GetDatas());
        }

        private List<ViewDataModels> GetDatas()
        {
            DateTime dateAtual= DateTime.Now;
            DateTime limiteTempo= DateTime.Now.AddDays(5);

            int quantDias = 0;
            ViewDataModels tempo;

            List<ViewDataModels> listarTempo= new List<ViewDataModels>();

            while (dateAtual < limiteTempo)
            {
                tempo= new ViewDataModels();
                tempo.Datas = dateAtual.ToShortDateString();
                tempo.RefIndentifica = "collapse" + dateAtual.ToShortDateString().Replace("/", "");
                listarTempo.Add(tempo);
                quantDias = quantDias + 1;
                dateAtual = DateTime.Now.AddDays(quantDias);
            }
            return listarTempo;
        }



        [HttpGet]
        public IActionResult InserirTarefa(string getTarefa)
        {
            TarefaModel tarefa = new TarefaModel
            {
                Data = getTarefa,
            };
            return View(tarefa);
        }
       


        [HttpPost]
        public async Task<IActionResult> InserirTarefa(TarefaModel insertTarefa)
        {
            if (ModelState.IsValid)
            {
                _context.Tarefas.Add(insertTarefa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(insertTarefa);
        }



        [HttpGet]
        public async Task<IActionResult> AlterarTarefa(int tarefaId)
        {
            TarefaModel tarefa = await _context.Tarefas.FindAsync(tarefaId);

            if (tarefa == null)
                return NotFound();

            return View(tarefa);
        }


        [HttpPost]
        public async Task<IActionResult> AlterarTarefa(TarefaModel tarefa)
        {
            if (ModelState.IsValid)
            {
                _context.Update(tarefa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tarefa);
        }

        
        [HttpPost]
        public async Task<JsonResult> RemoverTarefa(int id)
        {
            TarefaModel tarefa = await _context.Tarefas.FindAsync(id);
            _context.Tarefas.Remove(tarefa);
            await _context.SaveChangesAsync();
            return Json(true);
        }
        
    }
}