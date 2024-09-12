using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProspAI_Sprint3.Models
{
    [Table("TB_Desempenho_Sprint3")]
    public class Desempenho
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_desem { get; set; }

        [Required(ErrorMessage = "O mês do desempenho é obrigatório.")]
        [Column("ds_mes", TypeName = "varchar2(15)")]
        [MaxLength(15)]
        public string Mes_desem { get; set; }

        [Required(ErrorMessage = "O número de reclamações respondidas é obrigatório.")]
        [Range(1, 100, ErrorMessage = "O número de reclamações respondidas deve estar entre 1 e 100.")]
        [Column("nr_reclama", TypeName = "number(3)")]
        public int Reclamacoes_resp { get; set; }

        [Required(ErrorMessage = "O número de reclamações solucionadas é obrigatório.")]
        [Range(1, 100, ErrorMessage = "O número de reclamações solucionadas deve estar entre 1 e 100.")]
        [Column("nr_reclama_solu", TypeName = "number(3)")]
        public int Reclamacoes_solu { get; set; }

        [ForeignKey("Funcionario")]
        public int Id_fun { get; set; }
        public Funcionario? Funcionario { get; set; }
    }
}
