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

        //http://localhost:5000/home
        public ClienteController(DB dbViaParametro)
        {
            _dbInterno = dbViaParametro;
        }

        //http://localhost:5000/home/index
        public IActionResult Index()
        {
            var listaClientes = _dbInterno.Clientes.ToList();

            return View(listaClientes);
        }

        //http://localhost:5000/home/novo
        public IActionResult Novo()
        {
            var clienteDTO = new ClienteDTO();

            return View("Cadastro", clienteDTO);
        }

        //http://localhost:5000/home/editar
        public IActionResult Editar(int cpf)
        {
            var cliente = _dbInterno.Clientes.SingleOrDefault(e => e.Cpf == cpf);

            var clienteDTO = new ClienteDTO
            {
                Cpf = cliente.Cpf,
                NomeCliente = cliente.NomeCliente,
                Data = cliente.Data
            };

            return View("Cadastro", clienteDTO);
        }

        [HttpPost]
        public IActionResult Salvar(ClienteDTO clienteFormulario)
        {
           if (clienteFormulario.Cpf == 0)
            {
                //Registro novo
                var clienteBD = new Cliente();
                clienteBD.NomeCliente = clienteFormulario.NomeCliente;
                clienteBD.Data = clienteFormulario.Data;

                _dbInterno.Add(clienteBD);
            }
           else
            {
                //Registro atualizado                        
               var clienteBD = _dbInterno.Cliente.SingleOrDefault(e => e.Cpf == clienteFormulario.Cpf);

                clienteBD.NomeCliente = clienteFormulario.NomeCliente;
                clienteBD.Data = clienteFormulario.Data;

               _dbInterno.Update(clienteBD);
            }

            _dbInterno.SaveChanges();

            return RedirectToAction("Index");
        }

        //http://localhost:5000/evento/apagar/{id}
        public IActionResult Apagar(int cpf)
        {
            var cliente = _dbInterno.Clientes.SingleOrDefault(e => e.Cpf == cpf);

            _dbInterno.Remove(cliente);

            _dbInterno.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
