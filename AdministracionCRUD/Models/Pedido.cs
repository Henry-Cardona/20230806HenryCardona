using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AdministracionCRUD.Models;

public partial class Pedido
{
    public int Id { get; set; }

    public int? IdMarca { get; set; }

    public int? IdModelo { get; set; }
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateTime? FechaInicio { get; set; }
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateTime? FechaFinal { get; set; }

    public string Estado { get; set; }
    
    public string persona { get; set; }

    public virtual Marca? IdMarcaNavigation { get; set; }
}
