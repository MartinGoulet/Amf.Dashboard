using System;
using System.Collections.Generic;
using Amf.Ultima.Api.Models;

namespace Amf.Ultima.Api.DataStorage
{
    public class DataManager
    {
        public static List<PanierUltima> GetData()
        {
            var r = new Random();
            var nb = r.Next(1, 5);
            var retour = new List<PanierUltima>();

            for (var i = 1; i <= nb; i++)
            {
                var panier = new PanierUltima()
                {
                    Id = i,
                    Nom = $"Panier {i}",
                    Erreurs = new List<string>()
                };

                var nbErr = r.Next(1, 6);

                for (var j = 1; j <= nbErr; j++)
                {
                    panier.Erreurs.Add($"Erreur : {r.Next(30)}");
                }

                retour.Add(panier);

            }

            return retour;

        }
    }
}