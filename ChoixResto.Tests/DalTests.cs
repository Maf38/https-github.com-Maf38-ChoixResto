using ChoixResto.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChoixResto.Tests
{
    [TestClass]
    class DalTests
    {
        [TestMethod]

        public void CreerRestaurant_AvecUnNouveauRestaurant_ObtientTousLesRestaurantsRenvoitBienLeRestaurant()

        {

            using (IDal dal = new Dal())

            {

                dal.CreerRestaurant("La bonne fourchette", "01 02 03 04 05");
                dal.CreerRestaurant("le resto bulle d o", "00 00 00 00");


                List <Resto> restos = dal.ObtientTousLesRestaurants();



                Assert.IsNotNull(restos);

                Assert.AreEqual(1, restos.Count);

                Assert.AreEqual("La bonne fourchette", restos[0].Nom);

                Assert.AreEqual("01 02 03 04 05", restos[0].Telephone);

                Assert.AreEqual("00 00 00 00", restos[1].Telephone);

            }

        }
    }

}
