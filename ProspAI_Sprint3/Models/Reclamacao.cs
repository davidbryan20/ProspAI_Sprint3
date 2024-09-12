using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProspAI_Sprint3.Models
{
    [Table("TB_Reclamacao_Sprint3")]
    public class Reclamacao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_recla { get; set; }

        [MaxLength(30)]
        [Required(ErrorMessage = "O nome é obrigatório ! ")]
        [Column("nm_clie", TypeName = "varchar2(30)")]
        public string Nm_clie { get; set; }

        [Required(ErrorMessage = "A data é obrigatória ! ")]
        [Column("dt_recla", TypeName = "date")]
        [DataType(DataType.Date)]
        public DateTime Dt_recla { get; set; }

        [MaxLength(20)]
        [Required(ErrorMessage = "A origem da reclamação é obrigatória ! ")]
        [Column("og_recla", TypeName = "varchar2(20)")]
        public string Origem_recla { get; set; }

        [MaxLength(1)]
        [Required(ErrorMessage = "O status da soluçao da reclamação é obrigatória ! ")]
        [Column("st_solu", TypeName = "char(1)")]
        public String Solucionada_recla { get; set; }

        [MaxLength(100)]
        [Required(ErrorMessage = "O assunto da reclamação é obrigátorio ! ")]
        [Column("as_recla", TypeName = "varchar2(100)")]
        public string Assunto_recla { get; set; }

        [ForeignKey("Funcionario")]
        public int Id_fun { get; set; }
        public Funcionario? Funcionario { get; set; }
    }
}
