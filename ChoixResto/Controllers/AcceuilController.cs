using ChoixResto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ChoixResto.ViewModels;

namespace ChoixResto.Controllers
{
    public class AcceuilController : Controller
    {
        // GET: Acceuil
        public ActionResult Index()
        {
                       
            AccueilViewModel vm = new AccueilViewModel
            {
                Message = "Bonjour depuis le contrôleur",
                Date = DateTime.Now,
                Resto = new Resto { Nom = "La bonne fourchette", Telephone = "1234" }
            };

            return View(vm);
        }

        public ActionResult Demande()
        {

            AccueilViewModel vm = new AccueilViewModel
            {
                Message = "Bonjour depuis le contrôleur",
                Date = DateTime.Now,
                Resto = new Resto { Nom = "La bonne fourchette", Telephone = "1234" }
            };

            return View(vm);
        }


    }
}