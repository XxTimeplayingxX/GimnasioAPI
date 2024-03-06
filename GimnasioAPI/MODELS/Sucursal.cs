namespace GimnasioAPI.MODELS
{
    public class Sucursal
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Dirección { get; set; }
        public DateTime HoraDeApertura { get; set; }
        public DateTime HoraDeCierre { get; set; }
    }
}
