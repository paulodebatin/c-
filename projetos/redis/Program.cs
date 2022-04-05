// Maiores informações em: 
// http://desenvolvedor.ninja/stackexchange-redis-acessando-redis-com-c/
// https://docs.redislabs.com/latest/rs/references/client_references/client_csharp/

using System;
using StackExchange.Redis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace redis_c_
{
    class Program
    {
        static void Main(string[] args)
        {
            ConnectionMultiplexer connectionRedis = ConnectionMultiplexer.Connect("localhost:6379");
            IDatabase clientRedis = connectionRedis.GetDatabase();

            var produto = new Produto
            {
                id = 1,
                descricao = "Caneta",
                preco = 12.12,
                quantidade = 123
            };
            
            string jsonString = JsonSerializer.Serialize(produto);
            string chave = "produto#1";

            clientRedis.StringSet(chave, jsonString);

            var produtoCarregado  = JsonSerializer.Deserialize<Produto>(clientRedis.StringGet(chave)); ;
            Console.WriteLine(produtoCarregado.id);
            Console.WriteLine(produtoCarregado.descricao);
            Console.WriteLine(produtoCarregado.preco);
            Console.WriteLine(produtoCarregado.quantidade);

            
            connectionRedis.Close();


        }
    }
}
