using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend_dotnetcore.models{

    [Table("produto")]
    public class Produto   
    {        
    
        [Key]
        public long? id { get; set; }        


        [Required]
        public string nome { get; set; }         

        public double? preco { get; set; }     
    
        public int? quantidade { get; set; }     

    }


}

