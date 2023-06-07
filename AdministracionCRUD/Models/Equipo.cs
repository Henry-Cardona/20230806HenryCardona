using System;
using System.Collections.Generic;

namespace AdministracionCRUD.Models;

public partial class Equipo
{
    public int Id { get; set; }

    public int? IdMarca { get; set; }

    public string? Nombre { get; set; }

    public string? Serie { get; set; }

    public string? Tipo { get; set; }

    public string? Descripcion { get; set; }

    public virtual Marca? IdMarcaNavigation { get; set; }
}
