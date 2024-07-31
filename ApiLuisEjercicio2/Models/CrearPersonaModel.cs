namespace ApiLuisEjercicio2.Models
{
    public class CrearPersonaModel
    {
        public required string Nombre { get; set; }
        public required string Apellido { get; set; }
        public string? Email { get; set; }
        public string? Telefono { get; set; }
        public string? Direccion { get; set; }
        public int Edad { get; set; }
    }
}
