using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Actividad_3_Navegación_entre_paginas_web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Actividad_3_Navegación_entre_paginas_web.Contollers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            villancicosContext context = new villancicosContext();
            var villancico = context.Villancico.OrderBy(x => x.Nombre);

            return View(villancico);
        }

        public IActionResult Informacion(int? id)
        {
            if(id==null)
            {
                return RedirectToAction("Index");
            }
            villancicosContext context = new villancicosContext();
            var vilancico = context.Villancico.FirstOrDefault(X => X.Id == id);

            if(vilancico== null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(vilancico);
            }
           
        }

    }
}
