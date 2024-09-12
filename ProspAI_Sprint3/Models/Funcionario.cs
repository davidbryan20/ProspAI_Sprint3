using ProspAI_Sprint3.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

[Table("TB_Funcionario_Sprint3")]
public class Funcionario
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id_fun { get; set; }

    [Required(ErrorMessage = "O nome do funcionário é obrigatório.")]
    [Column("nm_fun", TypeName = "varchar2(30)")]
    [MaxLength(30)]
    public string Nome_fun { get; set; }

    [Required(ErrorMessage = "O email do funcionário é obrigatório.")]
    [Column("ds_email", TypeName = "varchar2(50)")]
    [MaxLength(50)]
    [EmailAddress]
    public string Email_fun { get; set; }

    [Required(ErrorMessage = "A senha do funcionário é obrigatória.")]
    [Column("ds_senha", TypeName = "varchar2(100)")]
    [MaxLength(100)]
    public string Senha_fun { get; set; }

    [Column("dt_adm", TypeName = "date")]
    [DataType(DataType.Date)]
    [Required]
    public DateTime Data_admissao { get; set; }

    // Relacionamento com Desempenho
    public ICollection<Desempenho>? Desempenhos { get; set; }

    // Relacionamento com Reclamacao
    public ICollection<Reclamacao>? Reclamacoes { get; set; }
}
