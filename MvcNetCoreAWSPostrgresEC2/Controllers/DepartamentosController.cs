using Microsoft.AspNetCore.Mvc;
using MvcNetCoreAWSPostrgresEC2.Models;
using MvcNetCoreAWSPostrgresEC2.Repositories;

namespace MvcNetCoreAWSPostrgresEC2.Controllers
{
    public class DepartamentosController : Controller
    {
        private RepositoryHospital repo;
        public DepartamentosController(RepositoryHospital repo)
        {
            this.repo = repo;
        }
        public async Task<IActionResult> Index()
        {
            List<Departamento> departamentos = await this.repo.GetDepartamentosAsync();
            return View(departamentos);
        }
        public async Task<IActionResult> Details
            (int id)
        {
            Departamento departamento =
                await this.repo.FindDepartamentoAsync(id);
            return View(departamento);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create
            (Departamento dept)
        {
            await this.repo.InsertDepartamentoAsync(dept.IdDepartamento, dept.Nombre, dept.Localidad);
            return RedirectToAction("Index");
        }
    }
}
