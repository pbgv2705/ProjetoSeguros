using System;

namespace data
{
    public class Cliente
    {
        public int Cpf { get; set; }
        public DateTime Data { get; set; }
        public string NomeCliente { get; set; }

        public int Telefone { get; set; }
        public string email { get; set; }

        public int Apolice { get; set; }

        public double Prime { get; set; }

        public bool Cancelado {get; set;}

        public int? RMCreci {get; set;}

        public Corretor Corretor {get; set;}
    }
}
