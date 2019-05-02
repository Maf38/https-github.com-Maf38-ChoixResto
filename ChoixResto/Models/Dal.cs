using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace ChoixResto.Models
{
    public class Dal : IDal
    {
        private BddContext bdd;
        public Dal()
        {
            bdd = new BddContext();
        }

        public List<Resto> ObtientTousLesRestaurants()
        {
            return bdd.Restos.ToList();
        }

        public void CreerRestaurant(string nom, string telephone)

        {
            bdd.Restos.Add(new Resto { Nom = nom, Telephone = telephone });
            bdd.SaveChanges();
        }

        public void ModifierRestaurant(int id, string nom, string telephone)

        {

            Resto restoTrouve = bdd.Restos.FirstOrDefault(resto => resto.Id == id);

            if (restoTrouve != null)

            {

                restoTrouve.Nom = nom;

                restoTrouve.Telephone = telephone;

                bdd.SaveChanges();

            }

        }

        public void Dispose()
        {
            bdd.Dispose();
        }

        public bool RestaurantExiste(string resto)
        {
            bool result = false;
            List<Resto> listeResto = ObtientTousLesRestaurants();

            foreach (Resto res in listeResto)
            {
                if (res.Nom.Equals(resto))
                {
                    result = true;
                }

            }
            return result;
        }

        public List<Utilisateur> ObtientTousLesUtilisateurs()
        {
            return bdd.Utilisateurs.ToList();
        }


        public Utilisateur ObtenirUtilisateur(string idUser)
        {
            Utilisateur utilisateur = null;

            List<Utilisateur> listeUtilisateur = ObtientTousLesUtilisateurs();
            foreach (Utilisateur util in listeUtilisateur)
            {
                if (util.Id.ToString().Equals(idUser))
                {
                    utilisateur = util;
                }
            }


            return utilisateur;
        }

        public Utilisateur ObtenirUtilisateur(int IdUser)
        {
            Utilisateur utilisateur = null;

            List<Utilisateur> listeUtilisateur = ObtientTousLesUtilisateurs();
            foreach (Utilisateur util in listeUtilisateur)
            {
                if (util.Id == IdUser)
                {
                    utilisateur = util;
                    break;
                }

            }

            return utilisateur;
        }

        public int AjouterUtilisateur(string nom, string motDePasse)
        {

            int idUtilisateur = -1;
            Utilisateur util = new Utilisateur { Prenom = nom, MotDePasse = motDePasse };
            bdd.Utilisateurs.Add(util);
            bdd.SaveChanges();

            idUtilisateur = util.Id;

            return idUtilisateur;
        }

        public Utilisateur Authentifier(string prenom, string motDePasse)
        {

            Utilisateur utilisateur = null;
            List<Utilisateur> listeUtilisateur = ObtientTousLesUtilisateurs();

            foreach (Utilisateur util in listeUtilisateur)
            {
                if (util.Prenom.Equals(prenom) && util.MotDePasse.Equals(motDePasse))
                {
                    utilisateur = util;
                    break;
                }
            }
            return utilisateur;
        }

        public bool ADejaVote(int idSondage, string idUtilisateur)
        {
            bool result = false;
            try
            {
                Sondage currentSondage = bdd.Sondages.First(Sondage => Sondage.Id == idSondage);
                Debug.WriteLine("========= trace test sondage ====== " + currentSondage.Id.ToString());

                if (currentSondage != null)
                {
                    foreach (Vote vote in currentSondage.Votes)
                    {
                        if (vote.Utilisateur.Id.ToString().Equals(idUtilisateur))
                        {
                            result = true;
                            break;
                        }
                    }
                }
            }
            catch
            {

            }

            return result;
        }

        public List<Sondage> ObtientTousLesSondages()
        {
            return bdd.Sondages.ToList();
        }

        public int CreerUnSondage()
        {
         
            Sondage sondage = new Sondage { Date = DateTime.Now };
            bdd.Sondages.Add(sondage);

            bdd.SaveChanges();       
            
            return sondage.Id;
        }

       

        public void AjouterVote(int idSondage, int idResto, int idUtilisateur)
        {
            Vote vote = new Vote
            {
                Resto = bdd.Restos.First(r => r.Id == idResto),
                Utilisateur = bdd.Utilisateurs.First(u => u.Id == idUtilisateur)
            };
            Sondage sondage = bdd.Sondages.First(s => s.Id == idSondage);
            if (sondage.Votes == null)
                sondage.Votes = new List<Vote>();
            sondage.Votes.Add(vote);
            bdd.SaveChanges();
        }

        public List <Resultats> ObtenirLesResultats(int idSondage)
        {
            List<Resto> restaurants = ObtientTousLesRestaurants();
            List<Resultats> resultats = new List<Resultats>();
            Sondage sondage = bdd.Sondages.First(s => s.Id == idSondage);
            foreach (IGrouping<int, Vote> grouping in sondage.Votes.GroupBy(v => v.Resto.Id))
            {
                int idRestaurant = grouping.Key;
                Resto resto = restaurants.First(r => r.Id == idRestaurant);
                int nombreDeVotes = grouping.Count();
                resultats.Add(new Resultats { Nom = resto.Nom, Telephone = resto.Telephone, NombreDeVotes = nombreDeVotes });
            }
            return resultats;
        }
    }
}