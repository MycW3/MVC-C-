namespace mvc;

//modelo para recibir los productos de la base de datos
public class Producto
{
    public int ProductoId { get; set; }
    public string? Nombre { get; set; }
    public decimal Precio { get; set; }
    public string? Fabricante { get; set; }
}