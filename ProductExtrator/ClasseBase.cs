using Newtonsoft.Json;
using ProductExtrator.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductExtrator
{
    public abstract class ClasseBase
    {
        public readonly Supermrcados[] SuperMercados;
        public ClasseBase()
        {
            var dados = File.ReadAllText("C:\\Users\\Guilherme\\Desktop\\MeuTreinamento\\ProgSupermercado\\ProductExtrator\\Config.json");
            Supermrcados[]? supermrcados = JsonConvert.DeserializeObject<Supermrcados[]>(dados);
            this.SuperMercados = supermrcados;

        }
    }
}
