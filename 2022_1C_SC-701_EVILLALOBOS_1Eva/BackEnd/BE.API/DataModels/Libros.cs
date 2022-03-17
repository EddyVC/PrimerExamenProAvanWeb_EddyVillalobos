using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BE.API.DataModels
{
    public class Libros
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public int AutorId { get; set; }
        public DateTime Creacion { get; set; }
        public bool Activo { get; set; }
        public DateTime? Desactivacion { get; set; }
        public string DesactivadoPor { get; set; }
        public string CreadoPor { get; set; }

        public virtual Autores Autor { get; set; }
    }
}
