namespace backend_heca.Models
{
    public class Ruta
    {
        public int Id { get; set; }
        public string name { get; set; }
        public List<Parada> paradas { get; set; }
    }
}
