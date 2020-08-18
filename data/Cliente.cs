using System;

namespace data
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Cpf { get; set; }
        public DateTime Data { get; set; }
      
        public string NomeCliente { get; set; }

        public string Telefone { get; set; }
        public string Email { get; set; }

        public int Apolice { get; set; }

        public double Prime { get; set; }

        public bool Cancelado {get; set;}

        public int CorretorId {get; set;}

        public Corretor Corretor {get; set;}
    }
}
