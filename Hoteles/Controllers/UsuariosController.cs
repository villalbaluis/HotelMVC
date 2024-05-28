using Hoteles.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace Hoteles.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly HotelesContext _context = new HotelesContext();

        public ActionResult Index()
        {
            var rol = _context.Roles.Include(r => r.IdRol); // Consulta de objetos registrados  y asociados en BD
            return View(_context.Usuarios.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                ViewBag.ErrorMessage = "Error recibiendo la petición para ver el detalle del usuario.";
                return View();
            }
            Usuario usuario = _context.Usuarios.Find(id);
            if (usuario != null)
            {
                return View(usuario);
            }
            ViewBag.ErrorMessage = "Error, el usuario no ha sido encontrado.";
            return View();
        }

        public ActionResult Create()
        {
            ViewBag.IdRol = new SelectList(_context.Roles, "IdRol", "Nombre");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Usuarios.Add(usuario);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    if (ex.InnerException != null)
                    {
                        ViewBag.ErrorMessage = "Error creando el usuario, error: " + ex.InnerException.Message;
                        ViewBag.IdRol = new SelectList(_context.Roles, "IdRol", "Nombre", usuario.IdRol);
                        return View(usuario);
                    }
                }
            }
            ViewBag.IdHotel = new SelectList(_context.Hoteles, "IdHotel", "Nombre", usuario.IdRol);
            return View(usuario);
        }


        public ActionResult Edit(int? id)
        {
            Usuario usuario = _context.Usuarios.Find(id);
            if (usuario == null)
            {
                ViewBag.ErrorMessage = "Ocurrió un error consultando el usuario requerido.";
                ViewBag.IdRol = new SelectList(_context.Roles, "IdRol", "Nombre", usuario.IdRol);
                return View();
            }
            ViewBag.IdRol = new SelectList(_context.Roles, "IdRol", "Nombre", usuario.IdRol);
            return View(usuario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Entry(usuario).State = EntityState.Modified;
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    if (ex.InnerException != null)
                    {
                        ViewBag.ErrorMessage = "Falló en edición del usuario, error: (" + ex.InnerException.Message + ").";
                        ViewBag.IdRol = new SelectList(_context.Roles, "IdRol", "Nombre", usuario.IdRol);
                        return View(usuario);
                    }
                }
            }
            ViewBag.IdRol = new SelectList(_context.Roles, "IdRol", "Nombre", usuario.IdRol);
            return View(usuario);
        }

        public ActionResult Delete(int? id)
        {
            Usuario usuario = _context.Usuarios.Find(id);
            if (usuario == null || id == null)
            {
                ViewBag.ErrorMessage = "Error, el usuario no ha podido ser encontrado.";
                return View();
            }
            return View(usuario);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Usuario usuario = _context.Usuarios.Find(id);
            if (usuario != null)
            {
                try
                {
                    _context.Usuarios.Remove(usuario);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ViewBag.ErrorMessage = "Error, imposible eliminar al usuario, código de error: (" + ex.InnerException.Message + ").";
                }
            }
            return View();
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
