using System;
using System.Collections.Generic;

namespace AdministracionCRUD.Models;

public partial class Pedido
{
    public int Id { get; set; }

    public int? IdMarca { get; set; }

    public int? IdModelo { get; set; }

    public DateTime? FechaInicio { get; set; }

    public DateTime? FechaFinal { get; set; }

    public int? Estado { get; set; }

    public virtual Marca? IdMarcaNavigation { get; set; }
}
