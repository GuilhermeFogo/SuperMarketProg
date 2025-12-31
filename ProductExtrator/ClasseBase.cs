using Newtonsoft.Json;
using ProductExtrator.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductExtrator
{

    public class ConfigRoot
    {
        public Supermrcados[] SuperMercados { get; set; }
    }


    public abstract class ClasseBase
    {
        public readonly Supermrcados[] SuperMercados;
        public ClasseBase()
        {
            var dados = File.ReadAllText(
            @"C:\Users\Guilherme\Desktop\MeuTreinamento\ProgSupermercado\ProductExtrator\Config.json"
        );

            var config = JsonConvert.DeserializeObject<ConfigRoot>(dados);

            if (config?.SuperMercados == null || config.SuperMercados.Length == 0)
                throw new Exception("Nenhum supermercado configurado.");

            SuperMercados = config.SuperMercados;

        }
    }
}
