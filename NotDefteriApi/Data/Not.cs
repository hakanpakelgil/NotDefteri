using System.ComponentModel.DataAnnotations;

namespace NotDefteriApi.Data
{
    public class Not
    {
        public int Id { get; set; }

        [MaxLength(400)]
        public string Baslik { get; set; } = null!;

        public string  Icerik { get; set; } = string.Empty;
    }
}
