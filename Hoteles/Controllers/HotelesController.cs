using Hoteles.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace Hoteles.Controllers
{
    public class HotelesController : Controller
    {
        private readonly HotelesContext _context = new HotelesContext();

        public ActionResult Index() // Vista Index, donde se mostrarán todos los objetos en base de datos.
        {
            var hotel = _context.Hoteles.Include(habitacion => habitacion.Habitaciones); // Consulta de objetos registrados en BD.
            return View(_context.Hoteles.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(); // Retorno de vista para creación de Hotel
        }

        [HttpPost]
        public ActionResult Create(Hotel hotel) // Metodo para creación de hotel
        {
            if (ModelState.IsValid) // Recibe un modelo, y se valida si el modelo es valido.
            {
                try
                {
                    // Se añade el modelo al contexto de los hoteles.
                    _context.Hoteles.Add(hotel);
                    _context.SaveChanges();
                    return RedirectToAction("Index"); // Se redirigue a la página de la lista de hoteles.
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
        public ActionResult Edit(int id) // Metodo para retornar vista de edición de hotel.
        {
            Hotel hotel = _context.Hoteles.Find(id); // Se busca el hotel por el ID dado.
            if (hotel == null) // En caso de error, se retorna la vista con mensaje erroneo.
            {
                ViewBag.Info = ("Ha ocurrido un error, el hotel no ha sido encontrado.");
                return View();
            }
            return View(hotel); // Se retorna la vista con el formulario para edición.
        }

        [HttpPost]
        public ActionResult Edit(Hotel hotel) // Metodo para guardar la información editada.
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Entry(hotel).State = EntityState.Added; // Se realiza el cambio del registro a través del modelo
                    _context.SaveChanges(); // Se genera la transacción en Base de datos
                    return RedirectToAction("Index"); // Redirige a la página de todos los registros.
                }
                catch (Exception ex) // En caso de error, se retorna la vista con un mensaje.
                {
                    if (ex.InnerException
                        != null)
                    {
                        ViewBag.ErrorMessage = "Ha ocurrido un error en la edición del hotel (" + hotel.Nombre + ") Error: " + ex.Message;
                        return View(hotel);
                    }
                }
            }
            return View(hotel);
        }

        [HttpGet]
        public ActionResult Delete(int? id) // Metodo para retornar vista de eliminación del registro
        {
            Hotel hotel = _context.Hoteles.Find(id); // Se busca el registro por el ID dado.
            if (hotel == null) // En caso de no encontrar el ID, se retorna con mensaje de error.
            {
                ViewBag.Info = ("Error, el hotel no ha sido encontrado.");
                return View();
            }
            return View(hotel);
        }

        [HttpPost]
        public ActionResult Delete(int id) // Metodo para eliminar el objeto del contexto.
        {
            Hotel hotel = _context.Hoteles.Find(id); // Se busca el registro por el ID dado.
            if (hotel != null)
            {
                try
                {
                    _context.Hoteles.Remove(hotel); // se realiza la eliminacion del registro
                    _context.SaveChanges(); // guardar cambios
                    return RedirectToAction("Index"); // redireccionamiento
                }
                catch (Exception ex) // En caso de error, retornamos a la misma vista con mensaje de error.
                {
                    ViewBag.ErrorMessage = "Ocurrió un error procesando la petición de eliminación... Error:" + ex;
                    return View(hotel);
                }
            }
            return View(hotel);
        }

        [HttpGet]
        public ActionResult Details(int? id) // Metodo para retornar vista del objeto dado por el ID
        {
            if (id != null)
            {
                Hotel hotel = _context.Hoteles.Find(id);
                return View(hotel);
            }
            return View();
        }

        // Metodo para gestionar la conexión con la base de datos
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