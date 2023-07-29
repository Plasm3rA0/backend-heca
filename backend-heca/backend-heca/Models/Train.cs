namespace backend_heca.Models
{
    public class Train
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string type { get; set; }
        public Ruta ruta { get; set; }

    }
}
