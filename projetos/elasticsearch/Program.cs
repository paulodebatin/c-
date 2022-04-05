// Para maiores informações; 
// https://docs.microsoft.com/pt-br/dotnet/core/tutorials/cli-templates-create-project-template
// https://www.elastic.co/guide/en/elasticsearch/client/net-api/7.x/index.html
// https://github.com/elastic/elasticsearch-net
// https://www.elastic.co/pt/blog/indexing-documents-with-the-nest-elasticsearch-net-client

using System;
using System.Text;
using Elasticsearch.Net;
using Nest;

namespace elasticsearch_c_
{
    class Program
    {
        static void Main(string[] args)
        {
            var node = new Uri("http://localhost:9200");
            var settings = new ConnectionSettings(node);
            var client = new ElasticClient(settings);
            var lowlevelClient = new ElasticLowLevelClient(settings);

            // criado/atualizando
            var produto = new Produto
            {
                
                descricao = "Caneta",
                preco = 12.12,
                quantidade = 123
            };
            var ndexResponse = lowlevelClient.IndexAsync<BytesResponse>("produtos", "1", PostData.Serializable(produto));
            Console.WriteLine(ndexResponse.Result);

            // consultando dados
            var sourceResponse = client.Source<Produto>(1, g => g.Index("produtos"));
            var produtoConsultado = sourceResponse.Body;
            Console.WriteLine(produtoConsultado.descricao);
            Console.WriteLine(produtoConsultado.preco);
            Console.WriteLine(produtoConsultado.quantidade);


        }
    }
}
