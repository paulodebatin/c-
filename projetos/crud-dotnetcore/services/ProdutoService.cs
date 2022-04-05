using System;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

using backend_dotnetcore.models;
using backend_dotnetcore.Exceptions;


namespace backend_dotnetcore.services 
{
        public class ProdutoService : ICrudService<Produto> {
                
            private readonly ILogger<ProdutoService> logger;
            private ProdutoContext contextDB;
            
            public ProdutoService(ILogger<ProdutoService> logger, ProdutoContext contextDB) {
                this.logger = logger;
                this.contextDB = contextDB;
            }


            public IEnumerable<Produto> getAll() {
                return contextDB.Produtos.ToList();
            }

            public Produto getById(int id) {
                Produto entidade =  contextDB.Produtos.FirstOrDefault(a => a.id == id);
                if  (entidade == null)  {
                    throw new RegistroNaoEncontradoException();
                }
                return entidade;
            }

            public Produto save(Produto entidade) {
                contextDB.Produtos.Add(entidade);
                contextDB.SaveChanges();
                return entidade;
            }

            public Produto update(int id, Produto value) {
                var entidade = contextDB.Produtos.FirstOrDefault(a => a.id == id);
                if  (entidade == null) {
                    throw new RegistroNaoEncontradoException();
                }

                entidade.nome = String.IsNullOrEmpty(value.nome) ? entidade.nome : value.nome;   
                entidade.preco = value.preco == null ? entidade.preco : value.preco;   
                entidade.quantidade = value.quantidade == null ? entidade.quantidade : value.quantidade;
                
                contextDB.SaveChanges();

                return entidade;

            }
            public void delete(int id) {
                var entidade = contextDB.Produtos.FirstOrDefault(a => a.id == id);
                if  (entidade == null) {
                    throw new RegistroNaoEncontradoException();
                }

                contextDB.Remove(entidade);
                contextDB.SaveChanges();

            } 

    }
}    