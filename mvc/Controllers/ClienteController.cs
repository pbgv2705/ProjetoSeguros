using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mvc.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace mvc.Controllers
{
    public class ClienteController : Controller
    {
        private readonly DB _dbInterno;

        public ClienteController(DB dbViaParametro)
        {
            _dbInterno = dbViaParametro;
        }

        public IActionResult Index()
        {
            var listaClientes = _dbInterno.Clientes.ToList();

            return View(listaClientes);
        }

        public IActionResult Novo()
        {
            var clienteDTO = new ClienteDTO();

            return View("Cadastro", clienteDTO);
        }

        public IActionResult Editar(int cpf)
        {
            var cliente = _dbInterno.Clientes.SingleOrDefault(e => e.Cpf == cpf);

            var clienteDTO = new ClienteDTO
            {
                Cpf = cliente.Cpf,
                NomeCliente = cliente.NomeCliente,
                Data = cliente.Data,
                Telefone = cliente.Telefone,
                email = cliente.email,
                Apolice = cliente.Apolice,
                Prime = cliente.Prime

            };

            return View("Cadastro", clienteDTO);
        }

        [HttpPost]
        public IActionResult Salvar(ClienteDTO clienteFormulario)
        {
            if (clienteFormulario.Cpf == 0)
            {
                var clienteBD = new Cliente();
                clienteBD.NomeCliente = clienteFormulario.NomeCliente;
                clienteBD.Data = clienteFormulario.Data;
                clienteBD.Telefone = (int)clienteFormulario.Telefone;
                clienteBD.email = clienteFormulario.email;
                clienteBD.Apolice = clienteFormulario.Apolice;
                clienteBD.Prime = clienteFormulario.Prime;

                _dbInterno.Add(clienteBD);
            }
            else
            {                                       
                var clienteBD = _dbInterno.Clientes.SingleOrDefault(e => e.Cpf == clienteFormulario.Cpf);

                clienteBD.NomeCliente = clienteFormulario.NomeCliente;
                clienteBD.Data = clienteFormulario.Data;
                clienteBD.Telefone = (int)clienteFormulario.Telefone;
                clienteBD.email = clienteFormulario.email;
                clienteBD.Apolice = clienteFormulario.Apolice;
                clienteBD.Prime = clienteFormulario.Prime;

                _dbInterno.Update(clienteBD);
            }

            _dbInterno.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Apagar(int cpf)
        {
            var cliente = _dbInterno.Clientes.SingleOrDefault(e => e.Cpf == cpf);

            _dbInterno.Remove(cliente);

            _dbInterno.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
