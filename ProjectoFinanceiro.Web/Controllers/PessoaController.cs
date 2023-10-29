using Microsoft.AspNetCore.Mvc;
using ProjectoFinanceiro.Web.Models.Dtos;

namespace ProjectoFinanceiro.Web.Controllers
{
    public class PessoaController : Controller
    {
        private static List<PessoaDto> _pessoas = null;

        public PessoaController() 
        {
            if(_pessoas == null)    
            CarregarPessoas();
        }

        private void CarregarPessoas()
        {
            _pessoas = new List<PessoaDto>();
            PessoaDto pessoa1 = new PessoaDto
            {
                Id = Guid.NewGuid().ToString(),
                Nome = "Amancio Ubisse Junior",
                Email = "amancioubissejrr@gmail.com"
            };
            _pessoas.Add(pessoa1);


            PessoaDto pessoa2 = new PessoaDto
            {
                Id = Guid.NewGuid().ToString(),
                Nome = "Adelia Ubisse",
                Email = "adeliamargarida@gmail.com"
            };
            _pessoas.Add(pessoa2);


            PessoaDto pessoa3 = new PessoaDto
            {
                Id = Guid.NewGuid().ToString(),
                Nome = "Amelia Ubisse",
                Email = "ameliarodrigues@gmail.com"
            };
            _pessoas.Add(pessoa3);
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Listar()
        {
            return View(_pessoas);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("Nome, Email")] PessoaDto pessoa)
        {
            try
            {
                pessoa.Id = Guid.NewGuid().ToString();
                _pessoas.Add(pessoa);
                return RedirectToAction("Listar");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public IActionResult Delete(string id)
        {
            PessoaDto pessoa = _pessoas.FirstOrDefault(p => p.Id.Equals(id));
            return View(pessoa);
        }

        [HttpPost]
        public IActionResult Delete2(string id)
        {
           PessoaDto pessoa = _pessoas.FirstOrDefault(p => p.Id.Equals(id));
            if (pessoa != null) 
                _pessoas.Remove(pessoa);
            return RedirectToAction("Listar");
        }


        [HttpGet]
        public IActionResult Edit(string id)
        {
            PessoaDto pessoa = _pessoas.FirstOrDefault(p => p.Id.Equals(id));
            return View(pessoa);
        }

        [HttpPost]
        public IActionResult Edit([Bind("Id, Nome, Email")] PessoaDto pessoa)
        {
            PessoaDto pessoaPesquisa = _pessoas.FirstOrDefault(p => p.Id.Equals(pessoa.Id));
            if (pessoaPesquisa != null)
            {
                _pessoas.Remove(pessoaPesquisa);
                _pessoas.Add(pessoa);
            }
            return RedirectToAction("Listar");
        }

        [HttpGet]
        public IActionResult Details(string id)
        {
            PessoaDto pessoa = _pessoas.FirstOrDefault(p => p.Id.Equals(id));
            return View(pessoa);
        }


    }
}
