using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace backend_dotnetcore.models{

    [Table("pessoa")]
    public class Pessoa   
    {        
    
        [Key]
        public long? id { get; set; }        

         [Required]
        public string nome { get; set; }         

        public string? endereco { get; set; }     
    
        public string? numero { get; set; }     
        public string? bairro { get; set; }     
        public string? cidade { get; set; }     
        public string? uf { get; set; }     
        public string? cep { get; set; }     

        public bool? fumante { get; set; }     

        [Column("receber_noticias")]
        public bool? receberNoticias { get; set; }     

        [Column("data_nascimento")]
        [DataType(DataType.Date)]
        public DateTime? dataNascimento { get; set; }     
    }


}

