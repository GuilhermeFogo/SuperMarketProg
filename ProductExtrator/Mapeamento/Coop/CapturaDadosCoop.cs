using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductExtrator.Mapeamento.Coop
{
    public class CapturaDadosCoop
    {
        private readonly IWebDriver _driver;
        private readonly IJavaScriptExecutor _js;
        public CapturaDadosCoop(IWebDriver webDriver)
        {
            _driver = webDriver;
            _js = (IJavaScriptExecutor)_driver;
        }
        private IWebElement VericarGaleria => _driver.FindElement(By.Id("gallery-layout-container"));

        private IReadOnlyCollection<IWebElement> ListaProdutos => _driver
        .FindElement(By.Id("gallery-layout-container"))
        .FindElements(By.TagName("section"));

        public bool ExistGaleria()
        {
            try
            {
                return this.VericarGaleria.Displayed;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<string> CapturarDadosProdutos(int index=0)
        {
            var ListaDado = new List<string>();
            try
            {

                foreach (var item in ListaProdutos)
                {
                   var dados1 = item.Text;
                   ListaDado.Add(dados1);
                }
                return ListaDado;
            }
            catch (Exception e)
            {
                string js = $"document.querySelector('#gallery-layout-container').querySelectorAll('section')[{index}].innerText";

                var dado = _js.ExecuteScript(js).ToString();
                ListaDado.Add(dado);
                return ListaDado;
            }

        }
    }
}
