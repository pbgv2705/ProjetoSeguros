using System;
using System.ComponentModel.DataAnnotations;

public class ClienteDTO
{
    public int Id { get; set; }
   
    [Required(ErrorMessage="O cpf do cliente é obrigatório",AllowEmptyStrings=false)]
    public string Cpf { get; set; }

    
    [Required(ErrorMessage="O nome do cliente é obrigatório",AllowEmptyStrings=false)]
    [Display(Name = "Nome do Usuário")]
    public string NomeCliente { get; set; }
   
    public DateTime Data { get; set; }
    public string Telefone { get; set; }
    public string Email { get; set; }

    public int Apolice { get; set; }

    public double Prime { get; set; }
    public string RMCreci { get; set; }
    public string NomeCorretor { get; set; }

   
    [Required(ErrorMessage="O Id do Corretor é obrigatório",AllowEmptyStrings=false)]
    [Display(Name = "Digite o seu Id")]

    public int CorretorId { get; set; }
}