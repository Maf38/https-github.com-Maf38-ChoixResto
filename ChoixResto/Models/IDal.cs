using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChoixResto.Models
{
    public interface IDal : IDisposable
    {
        List<Resto> ObtientTousLesRestaurants();

        void Dispose();

        void CreerRestaurant(string nom, string telephone);

        void ModifierRestaurant(int id, string nom, string telephone);

        Boolean RestaurantExiste(string resto);

        Utilisateur ObtenirUtilisateur(string user);

        int AjouterUtilisateur(string nom, string motDePasse);

        Utilisateur ObtenirUtilisateur(int v);

        Utilisateur Authentifier(string prenom, string motDePasse);

        bool ADejaVote(int IdSondage, string IdUtilisateur);

        int CreerUnSondage();

        void AjouterVote(int idSondage, int idResto, int idUtilisateur);

        List <Resultats> ObtenirLesResultats(int idSondage);
    }
}
