using System;

public class ClienteDTO
{
    public int Id { get; set; }
    public string Cpf { get; set; }
    public string NomeCliente { get; set; }
    public DateTime Data { get; set; }
    public string Telefone { get; set; }
    public string Email { get; set; }

    public int Apolice { get; set; }

    public double Prime { get; set; }
    public string RMCreci { get; set; }
    public string NomeCorretor { get; set; }

    public int CorretorId { get; set; }
}