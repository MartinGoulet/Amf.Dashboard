using System.Collections.Generic;

namespace Amf.Ultima.Api.Models
{
    public class PanierUltima
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public List<string> Erreurs { get; set; }
    }
}