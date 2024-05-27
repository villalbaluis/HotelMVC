using Hoteles.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace Hoteles.Controllers
{
    public class HabitacionesController : Controller
    {
        //Objeto de tipo context para acceder al opciones del ORM
        private readonly HotelesContext _context = new HotelesContext();

        public ActionResult Index() // Vista Index, donde se mostrarán todos los objetos en base de datos.
        {
            var habitacion = _context.Hoteles.Include(h => h.IdHotel); // Consulta de objetos registrados en BD
            return View(_context.Habitaciones.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.IdHotel = new SelectList(_context.Hoteles, "IdHotel", "Nombre");
            return View(); // Retorno de vista para creación del Objeto
        }

        [HttpPost]
        public ActionResult Create(Habitacion habitacion)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Habitaciones.Add(habitacion);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    if (ex.InnerException != null)
                    {
                        ViewBag.ErrorMessage = "Error creando la habitación, error: " + ex.InnerException.Message;
                        ViewBag.IdHotel = new SelectList(_context.Hoteles, "IdHotel", "Nombre", habitacion.IdHotel);
                        return View(habitacion);
                    }
                }
            }
            ViewBag.IdHotel = new SelectList(_context.Hoteles, "IdHotel", "Nombre", habitacion.IdHotel);
            return View(habitacion);
        }
    }

}