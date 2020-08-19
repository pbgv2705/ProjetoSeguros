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
    public class CorretorController : Controller
    {
        private readonly DB _dbInterno;
        
        public CorretorController(DB dbViaParametro)
        {
            _dbInterno = dbViaParametro;
        }
        
        public IActionResult Index()
        {
            var listaCorretores = _dbInterno.Corretores.ToList();

            return View(listaCorretores);
        }
        
        public IActionResult Novo()
        {
            var corretorDTO = new CorretorDTO();

            return View("Cadastro", corretorDTO);
        }
        
        public IActionResult Editar(int id)
        {
            var corretor = _dbInterno.Corretores.SingleOrDefault(e => e.Id == id);

            var corretorDTO = new CorretorDTO
            {
                RMCreci = corretor.RMCreci,
                NomeCorretor = corretor.NomeCorretor,
                
            };

            return View("Cadastro", corretorDTO);
        }

        [HttpPost]
        public IActionResult Salvar(CorretorDTO corretorFormulario)
        {
            if (corretorFormulario.Id == 0)
            {
                var corretorBD = new Corretor();


                corretorBD.NomeCorretor = corretorFormulario.NomeCorretor;
                corretorBD.RMCreci = corretorFormulario.RMCreci;

                _dbInterno.Add(corretorBD);
            }
            else
            {
                var corretorBD = _dbInterno.Corretores.SingleOrDefault(e => e.Id == corretorFormulario.Id);

                corretorBD.RMCreci = corretorFormulario.RMCreci;
                corretorBD.NomeCorretor = corretorFormulario.NomeCorretor;
                
                _dbInterno.Update(corretorBD);
            }

            _dbInterno.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Apagar(int id)
        {
            var corretor = _dbInterno.Corretores.SingleOrDefault(e => e.Id == id);

            _dbInterno.Remove(corretor);

            _dbInterno.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
