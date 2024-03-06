namespace GimnasioAPI.MODELS
{
    public class UsuarioPlanes
    {
        public int ID { get; set; }
        public int UsuarioID { get; set; }
        public int PlanesID { get; set; }
        //Propiedad de navegación
        public Usuario Usuario { get; set; }
        public Planes Planes { get; set; }
    }
}
