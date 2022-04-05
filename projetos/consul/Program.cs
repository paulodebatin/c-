// Para maiores informações: 
// https://www.nuget.org/packages/Consul
// https://github.com/G-Research/consuldotnet/blob/master/Consul.Test/KVTest.cs
// 

using System;
using System.Text;
using Consul;
using System.Text.Json;

namespace consul_c_
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new ConsulClient();

            var produto = new Produto
            {
                id = 1,
                descricao = "Caneta",
                preco = 12.12,
                quantidade = 123
            };

            string jsonString = JsonSerializer.Serialize(produto);
            string chave = "produto_1";
            var pair = new KVPair(chave) {
                Value = Encoding.UTF8.GetBytes(jsonString)
            };
            client.KV.Put(pair);


            var produtoCarregado = JsonSerializer.Deserialize<Produto>(client.KV.Get(chave).Result.Response.Value); 
            Console.WriteLine(produtoCarregado.id);
            Console.WriteLine(produtoCarregado.descricao);
            Console.WriteLine(produtoCarregado.preco);
            Console.WriteLine(produtoCarregado.quantidade);
        }
    }
}
