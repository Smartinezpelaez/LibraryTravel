﻿using System;
using System.Collections.Generic;

namespace LibraryTravel.DAL.Models
{
    public partial class Editoriale
    {
        public Editoriale()
        {
            Libros = new HashSet<Libro>();
        }

        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Sede { get; set; }

        public virtual ICollection<Libro> Libros { get; set; }
    }
}
