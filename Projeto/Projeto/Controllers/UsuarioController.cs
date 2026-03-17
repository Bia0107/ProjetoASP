using Microsoft.AspNetCore.Mvc;
using Projeto.Models;
using Projeto.Repositorio;
using Projeto.Repositorio.Contrato;

namespace Projeto.Controllers
{
    public class UsuarioController : Controller
    {
        private IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }
        public IActionResult Index()
        {
            return View(_usuarioRepositorio.ObterTodosUsuarios());
        }


        [HttpGet]
        public IActionResult CadastrarUsuario()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CadastrarUsuario(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _usuarioRepositorio.Cadastrar(usuario);
            }
            return View();
        }

        public IActionResult ExcluirUsuario(int Id)
        {
            _usuarioRepositorio.Excluir(Id);
            return RedirectToAction(nameof(Index));
        }

    }
}
