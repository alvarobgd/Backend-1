namespace Backend.modelos
{
    public class EmpleadoOficina
    {
        public int EmpleadoID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int OficinaID { get; set; }
        public string OficinaDireccion { get; set; }
        public string Cargo { get; set; }
        public decimal Salario { get; set; }
    }

    public class EmpleadoNuevo
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Fecha_nacimiento { get; set; }
        public int Oficina { get; set; }
        public string Cargo { get; set; }
        public decimal Salario { get; set; }
    }
}
