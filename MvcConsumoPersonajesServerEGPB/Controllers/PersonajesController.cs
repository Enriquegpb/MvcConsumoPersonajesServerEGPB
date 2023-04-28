using Microsoft.AspNetCore.Mvc;
using MvcConsumoPersonajesServerEGPB.Models;
using MvcConsumoPersonajesServerEGPB.Services;

namespace MvcConsumoPersonajesServerEGPB.Controllers
{
    public class PersonajesController : Controller
    {
        private ServiceCrudPersonajes service;
        public PersonajesController(ServiceCrudPersonajes service)
        {
            this.service = service;
        }

        public async Task<IActionResult> Index()
        {
            List<Personaje> personajes = await this.service.GetPersonajesAsync();
            return View(personajes);
        }
        public async Task<IActionResult> Details(int id)
        {
            Personaje personaje = await this.service.FindPersonajeAsync(id);
            return View(personaje);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(int idpersonaje, string NombrePersonaje, string imagen, int idserie)
        {
            await this.service.InsertNuevoPersonajeAsync(idpersonaje, NombrePersonaje, imagen, idserie);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Edit(int idpersonaje)
        {
            Personaje personaje = await this.service.FindPersonajeAsync(idpersonaje);
            return View(personaje);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int idpersonaje, string NombrePersonaje, string imagen, int idserie)
        {
            await this.service.UpdatePersonajeAsync(idpersonaje, NombrePersonaje, imagen, idserie);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeletePersonaje(int idpersonaje)
        {
            await this.service.DeletePersonajeAsync(idpersonaje);
            return RedirectToAction("Index");
        }
    }
}
