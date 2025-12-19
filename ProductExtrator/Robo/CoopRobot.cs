using ProductExtrator.Mapeamento.Coop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductExtrator.Robo
{
    public class CoopRobot : SeleniumBaseConfig, IConfigRobot
    {
        private PesquisarCoop _pesquisarCoop;
        public void Execute()
        {
            _pesquisarCoop = new PesquisarCoop(Driver);
            if (_pesquisarCoop.ExistCampoPesquisa())
            {
                _pesquisarCoop.Pesquisar("leite");
            }
        }

        public void Initialize()
        {
            var coop = this.SuperMercados.FirstOrDefault(s => s.Nome == "Coop");
            if (coop != null)
            {
                this.Navigate(coop.Url);
                _pesquisarCoop = new PesquisarCoop(Driver);
            }
        }
    }
}
