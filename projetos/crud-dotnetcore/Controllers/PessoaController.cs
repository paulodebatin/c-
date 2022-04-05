using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Net;

using backend_dotnetcore.models;
using backend_dotnetcore.services;
using backend_dotnetcore.Exceptions;

namespace backend_dotnetcore.Controllers
{
    [ApiController]
    [Route("pessoas")]
    public class PessoaController : ControllerBase
    {

        private ICrudService<Pessoa> service;

        public PessoaController(ICrudService<Pessoa> service)
        {
            this.service = service;
        }

        [HttpGet]
        public IEnumerable<Pessoa> Get()
        {
            return service.getAll();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try {
               Pessoa entidade = service.getById(id); 
               return StatusCode((int) HttpStatusCode.OK,entidade);    
            } catch (RegistroNaoEncontradoException) {
                return StatusCode((int) HttpStatusCode.NotFound, "Registro com id " + id + " não encontrado!"); 
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody]Pessoa value) {
            if  (value.id != null) {
                return StatusCode((int) HttpStatusCode.BadRequest,"Campo 'id' não deve ser informado!");
            }
            service.save(value);
            return StatusCode((int) HttpStatusCode.Created,value);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Pessoa value) {
            try {
                Pessoa entidade =  service.update(id, value);

                return StatusCode((int) HttpStatusCode.OK,entidade);    
            } catch (RegistroNaoEncontradoException) {
                return StatusCode((int) HttpStatusCode.NotFound, "Registro com id " + id + " não encontrado!"); 
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
             try {
                service.delete(id);

                return StatusCode((int) HttpStatusCode.NoContent);
            } catch (RegistroNaoEncontradoException) {
                return StatusCode((int) HttpStatusCode.NotFound, "Registro com id " + id + " não encontrado!"); 
            }
        }


    }



}
