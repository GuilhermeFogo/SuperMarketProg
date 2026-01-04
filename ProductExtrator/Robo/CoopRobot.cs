using ProductExtrator.Mapeamento.Coop;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductExtrator.Robo
{
    public class CoopRobot : SeleniumBaseConfig, IConfigRobot
    {
        private PesquisarCoop _pesquisarCoop;
        private CapturaDadosCoop _capturaDadosCoop;
        public void Execute()
        {
            if (_pesquisarCoop.ExistCampoPesquisa())
            {
                _pesquisarCoop.Pesquisar("leite");
                Thread.Sleep(15000);
                var dadoLeite = _capturaDadosCoop.CapturarDadosProdutos();
                Thread.Sleep(8000);
                _pesquisarCoop.Pesquisar("arroz");
                Thread.Sleep(8000);
                var dadoArroz = _capturaDadosCoop.CapturarDadosProdutos();
                Thread.Sleep(8000);
                _pesquisarCoop.Pesquisar("feijão");
                Thread.Sleep(8000);
                var dadoFeijao = _capturaDadosCoop.CapturarDadosProdutos();
                Thread.Sleep(8000);
                _pesquisarCoop.Pesquisar("café");
                Thread.Sleep(8000);
                var dadoCafe = _capturaDadosCoop.CapturarDadosProdutos();

                Console.WriteLine(TratarDados(dadoLeite));
            }
        }

        public void Initialize()
        {
            var coop = this.SuperMercados.FirstOrDefault(s => s.Nome == "Coop");
            if (coop != null)
            {
                this.Navigate(coop.Url);
                _pesquisarCoop = new PesquisarCoop(Driver);
                _capturaDadosCoop = new CapturaDadosCoop(Driver);

            }
        }

        private string TratarDados(List<string> dadosCoop)
        {
            foreach (var item in dadosCoop)
            {
                var linhas = item
               .Split('\n', StringSplitOptions.RemoveEmptyEntries)
               .Select(l => l.Trim())
               .ToArray();

                var nome = linhas.FirstOrDefault();

                var precoTexto = linhas
                    .FirstOrDefault(l => l.StartsWith("R$"));
                if (precoTexto == null)
                    throw new Exception("Preço não encontrado.");

                var preco = ExtrairPreco(precoTexto);

                return $"Nome: {nome} - Preço: {preco}";

            }
            return string.Empty;
        }

        private decimal ExtrairPreco(string texto)
        {
            var valor = texto
                .Replace("R$", "")
                .Trim();

            return decimal.Parse(
                valor,
                new CultureInfo("pt-BR")
            );
        }
    }
}
