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
           

            return View();
        }

        [ChildActionOnly]
        public ActionResult AfficheListeRestaurant()
        {
            List<Models.Resto> listeDesRestos = new List<Resto>
        {
            new Resto { Id = 1, Nom = "Resto pinambour", Telephone = "1234" },
            new Resto { Id = 2, Nom = "Resto tologie", Telephone = "1234" },
            new Resto { Id = 5, Nom = "Resto ride", Telephone = "5678" },
            new Resto { Id = 9, Nom = "Resto toro", Telephone = "555" },
        };
            return PartialView(listeDesRestos);
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