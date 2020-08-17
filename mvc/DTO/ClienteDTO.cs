using System;

public class ClienteDTO
{
    public int Cpf { get; set; }
    public string NomeCliente { get; set; }
    public DateTime Data { get; set; }
    public long Telefone { get; set; }
    public string email { get; set; }

    public int Apolice { get; set; }

    public double Prime { get; set; }
    public int? RMCreci { get; set; }
    public string NomeCorretor { get; set; }
}