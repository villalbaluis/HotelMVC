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

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            Habitacion habitacion = _context.Habitaciones.Find(id);
            if (habitacion == null)
            {
                ViewBag.ErrorMessage = "Ocurrió un error consultando la habitación.";
                ViewBag.IdHotel = new SelectList(_context.Hoteles, "IdHotel", "Nombre", habitacion.IdHotel);
                return View();
            }
            ViewBag.IdHotel = new SelectList(_context.Hoteles, "IdHotel", "Nombre", habitacion.IdHotel);
            return View(habitacion);
        }

        [HttpPost]
        public ActionResult Edit(Habitacion habitacion)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Entry(habitacion).State = EntityState.Modified;
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    if (ex.InnerException != null)
                    {
                        ViewBag.ErrorMessage = "Falló en edición de la habitación, error: (" + ex.InnerException.Message + ").";
                        ViewBag.IdHotel = new SelectList(_context.Hoteles, "IdHotel", "Nombre", habitacion.IdHotel);
                        return View(habitacion);
                    }
                }
            }
            ViewBag.IdHotel = new SelectList(_context.Hoteles, "IdHotel", "Nombre", habitacion.IdHotel);
            return View(habitacion);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Habitacion habitacion = _context.Habitaciones.Find(id);
            if (habitacion == null)
            {
                ViewBag.ErrorMessage = "Error, la habitación no ha podido ser encontrado.";
                return View();
            }
            return View(habitacion);
        }

        [HttpPost]
        public ActionResult Delete(int? id)
        {
            Habitacion habitacion = _context.Habitaciones.Find(id);
            if (habitacion != null)
            {
                try
                {
                    _context.Habitaciones.Remove(habitacion);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ViewBag.ErrorMessage = "Error, imposible eliminar la habitación, código de error: (" + ex.InnerException.Message + ").";
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return View();
            }
            Habitacion habitacion = _context.Habitaciones.Find(id);
            return View(habitacion);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }
    }

}