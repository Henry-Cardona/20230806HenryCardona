
using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

namespace AdministracionCRUD.Controllers
{
    public class ExportController : Controller
    {
        private readonly string cadenaSQL;
        public ExportController(IConfiguration config) 
        {
            cadenaSQL = config.GetConnectionString("conexion");
        }

        public IActionResult ExportExcelMarca() 
        {
            DataTable tablaMarca = new DataTable();
            using (var connect = new SqlConnection(cadenaSQL)) 
            {
                connect.Open();
                using (var adapter = new SqlDataAdapter()) 
                {
                    adapter.SelectCommand = new SqlCommand("SELECT * FROM marcas", connect);
                    adapter.Fill(tablaMarca);
                }
            }
            using (var sheetBook = new XLWorkbook())
            {
                tablaMarca.TableName = "Marcas";
                var hoja = sheetBook.Worksheets.Add(tablaMarca);
                hoja.ColumnsUsed().AdjustToContents();
                using (var memoria = new MemoryStream())
                {
                    sheetBook.SaveAs(memoria);
                    var excelName = string.Concat("Reporte marcas ", DateTime.Now.ToString(), ".xlsx");
                    return File(memoria.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelName);
                }
            }
        }

        public IActionResult ExportExcelEquipo()
        {
            DataTable tablaEquipo = new DataTable();
            using (var connect = new SqlConnection(cadenaSQL))
            {
                connect.Open();
                using (var adapter = new SqlDataAdapter())
                {
                    adapter.SelectCommand = new SqlCommand("SELECT * FROM equipos", connect);
                    adapter.Fill(tablaEquipo);
                }
            }
            using (var sheetBook = new XLWorkbook())
            {
                tablaEquipo.TableName = "Equipos";
                var hoja = sheetBook.Worksheets.Add(tablaEquipo);
                hoja.ColumnsUsed().AdjustToContents();
                using (var memoria = new MemoryStream())
                {
                    sheetBook.SaveAs(memoria);
                    var excelName = string.Concat("Reporte equipos ", DateTime.Now.ToString(), ".xlsx");
                    return File(memoria.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelName);
                }
            }
        }
        public IActionResult ExportExcelPedidos() 
        {
            DataTable tablaPedido = new DataTable();
            using (var connect = new SqlConnection(cadenaSQL))
            {
                connect.Open();
                using (var adapter = new SqlDataAdapter())
                {
                    adapter.SelectCommand = new SqlCommand("SELECT * FROM pedidos", connect);
                    adapter.Fill(tablaPedido);
                }
            }
            using (var sheetBook = new XLWorkbook())
            {
                tablaPedido.TableName = "Equipos";
                var hoja = sheetBook.Worksheets.Add(tablaPedido);
                hoja.ColumnsUsed().AdjustToContents();
                using (var memoria = new MemoryStream())
                {
                    sheetBook.SaveAs(memoria);
                    var excelName = string.Concat("Reporte pedidos ", DateTime.Now.ToString(), ".xlsx");
                    return File(memoria.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelName);
                }
            }
        }
    }
}
