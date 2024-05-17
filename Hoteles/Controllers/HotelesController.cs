using Hoteles.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace Hoteles.Controllers
{
    public class HotelesController : Controller
    {
        private HotelesContext db = new HotelesContext();

        public ActionResult Index()
        {
            var hotel = db.Hoteles.Include(habitacion => habitacion.Habitaciones);
            return View(db.Hoteles.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Hotel hotel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Hoteles.Add(hotel);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    if (ex.InnerException.InnerException.Message.Contains("IndexNombre"))
                    {
                        ViewBag.ErrorMessage = "Error ya existe un hotel con el nombre: " + hotel.Nombre;
                        return View(hotel);
                    }
                }
            }
            return View(hotel);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Hotel hotel = db.Hoteles.Find(id);
            if (hotel != null)
            {
                return View(hotel);
            }
            else
            {
                ViewBag.Info = ("El hotel no ha sido encontrado.");
                return View();
            }
        }

        [HttpPost]
        public ActionResult Edit(Hotel hotel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(hotel).State = EntityState.Modified; // se realiza el cambio del registro
                    db.SaveChanges(); // guardar cambios
                    return RedirectToAction("Index"); // redireccionamiento
                }
                catch (Exception ex)
                {
                    if (ex.InnerException != null && ex.InnerException.InnerException != null
                        && ex.InnerException.InnerException.Message.Contains("IndexNombre"))
                    {
                        ViewBag.ErrorMessage = "Error ya existe un Hotel con el nombre: " + hotel.Nombre;
                        return View(hotel);
                    }
                }
            }
            return View(hotel);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            Hotel hotel = db.Hoteles.Find(id);
            if (hotel != null)
            {
                return View(hotel);
            }
            else
            {
                ViewBag.Info = ("Hotel no encontrado...");
                return View();
            }
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            Hotel hotel = db.Hoteles.Find(id);
            if (hotel != null)
            {
                try
                {
                    db.Hoteles.Remove(hotel); // se realiza la eliminacion del registro
                    db.SaveChanges(); // guardar cambios
                    return RedirectToAction("Index"); // redireccionamiento
                }
                catch (Exception ex)
                {
                    ViewBag.ErrorMessage = "Error, el Hotel no se ha eliminado... " + ex;

                }
            }
            return View(hotel);
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id != null)
            {
                Hotel hotel = db.Hoteles.Find(id);
                return View(hotel);
            }
            return View();
        }

        // Metodo para gestionar la conexión con la base de datos
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}