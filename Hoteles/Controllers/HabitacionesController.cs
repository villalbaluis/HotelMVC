using Hoteles.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Hoteles.Controllers
{
    public class HabitacionesController : Controller
    {
        //Objeto de tipo context para acceder al opciones del ORM
        private HotelesContext db = new HotelesContext(); 

        // GET: Habitaciones
        public ActionResult Index()
        {
            
            return View();
        }


    }

}