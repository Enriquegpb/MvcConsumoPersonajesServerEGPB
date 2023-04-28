using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MvcConsumoPersonajesServerEGPB.Models
{
    public class Personaje
    {
        public int IdPersonaje { get; set; }
        public string NombrePersonaje { get; set; }
        public string Imagen { get; set; }
        public int IdSerie { get; set; }
    }
}
