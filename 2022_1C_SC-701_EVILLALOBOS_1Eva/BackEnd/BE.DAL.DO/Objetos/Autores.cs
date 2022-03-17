using System;
using System.Collections.Generic;
using System.Text;

namespace BE.DAL.DO.Objetos
{
    public partial class Autores
    {
        public Autores()
        {
            //Libros = new HashSet<Libros>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime Creacion { get; set; }
        public bool Activo { get; set; }
        public DateTime? Desactivacion { get; set; }
        public string DesactivadoPor { get; set; }
        public string CreadoPor { get; set; }
        public int? PaisId { get; set; }

        //public virtual Pais Pais { get; set; }
        //public virtual ICollection<Libros> Libros { get; set; }
    }
}
