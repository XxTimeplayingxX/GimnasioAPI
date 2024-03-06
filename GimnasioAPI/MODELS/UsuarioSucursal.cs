namespace GimnasioAPI.MODELS
{
    public class UsuarioSucursal
    {
        public int ID { get; set; }
        public int UsuarioID { get; set; }
        public int SucursalID { get; set; }
        //Propiedad de Navegación
        public Usuario Usuario { get; set; }
        public Sucursal Sucursal { get; set; }
    }
}
