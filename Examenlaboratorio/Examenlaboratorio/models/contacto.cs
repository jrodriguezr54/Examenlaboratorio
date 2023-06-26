using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Examenlaboratorio.models
{
    [Table ("contacto")]
    public class contacto
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }

        [MaxLength(100)]
        public string nombres { get; set; }

        [MaxLength(100)]
        public string apellidos { get; set;}

        [NotNull]
        public string edad { get; set; }

        [MaxLength(100)]
        public string pais { get; set;}

        [MaxLength(100)]
        public string nota { get; set;}

        [NotNull, Unique]
        public string telefono { get; set;}

        public byte[] foto { get; set;}
    }
}
