using System;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

using backend_dotnetcore.models;
using backend_dotnetcore.Exceptions;


namespace backend_dotnetcore.services 
{
        public class PessoaService : ICrudService<Pessoa> {
                
            private readonly ILogger<PessoaService> logger;
            private PessoaContext contextDB;
            
            public PessoaService(ILogger<PessoaService> logger, PessoaContext contextDB) {
                this.logger = logger;
                this.contextDB = contextDB;
            }


            public IEnumerable<Pessoa> getAll() {
                return contextDB.Pessoas.ToList();
            }

            public Pessoa getById(int id) {
                Pessoa entidade =  contextDB.Pessoas.FirstOrDefault(a => a.id == id);
                if  (entidade == null)  {
                    throw new RegistroNaoEncontradoException();
                }
                return entidade;
            }

            public Pessoa save(Pessoa entidade) {
                contextDB.Pessoas.Add(entidade);
                contextDB.SaveChanges();
                return entidade;
            }

            public Pessoa update(int id, Pessoa value) {
                var entidade = contextDB.Pessoas.FirstOrDefault(a => a.id == id);
                if  (entidade == null) {
                    throw new RegistroNaoEncontradoException();
                }

                entidade.nome = String.IsNullOrEmpty(value.nome) ? entidade.nome : value.nome;   
                entidade.endereco = value.endereco == null ? entidade.endereco : value.endereco;   
                entidade.numero = value.numero == null ? entidade.numero : value.numero;
                entidade.bairro = value.bairro == null ? entidade.bairro : value.bairro;
                entidade.cidade = value.cidade == null ? entidade.cidade : value.cidade;
                entidade.uf = value.uf == null ? entidade.uf : value.uf;
                entidade.cep = value.cep == null ? entidade.cep : value.cep;
                entidade.receberNoticias = value.receberNoticias == null ? entidade.receberNoticias : value.receberNoticias;
                entidade.fumante = value.fumante == null ? entidade.fumante : value.fumante;
                entidade.dataNascimento = value.dataNascimento == null ? entidade.dataNascimento : value.dataNascimento;
            
                
                contextDB.SaveChanges();

                return entidade;

            }
            public void delete(int id) {
                var entidade = contextDB.Pessoas.FirstOrDefault(a => a.id == id);
                if  (entidade == null) {
                    throw new RegistroNaoEncontradoException();
                }

                contextDB.Remove(entidade);
                contextDB.SaveChanges();

            } 

    }
}    