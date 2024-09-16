using System.ComponentModel.DataAnnotations;

namespace MyWebAPI.Models
{
    public class Data
    {

        [Key]
        public string PesticideID { get; set; }
        public string PesticideName { get; set; }
        public string PesticideEnName { get; set; }
        public string PesticideCoaID { get; set; }
        public string PesticideProductName { get; set; }


    }

    public class PesticideType
    {
        public string RS { get; set; }
        public List<Data> Data { get; set; }
        public bool Next { get; set; }
    }
}
