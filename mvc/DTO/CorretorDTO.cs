using System;
using System.ComponentModel.DataAnnotations;

public class CorretorDTO
{
    public int Id { get; set; }
    
    
    [Required(ErrorMessage="O RMCreci do Corretor é obrigatório",AllowEmptyStrings=false)]
    [Display(Name = "RMCreci do Corretor")]
    public string RMCreci { get; set; }

    [Required(ErrorMessage="O nome do corretor é obrigatório",AllowEmptyStrings=false)]
    [Display(Name = "Digite o Nome do Corretor")]
    public string NomeCorretor { get; set; }

    
    
}