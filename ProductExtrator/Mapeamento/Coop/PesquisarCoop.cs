using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductExtrator.Mapeamento.Coop
{
    public class PesquisarCoop
    {
        private readonly IWebDriver _driver;
        private readonly IJavaScriptExecutor _js;

        private IWebElement Campo_pesquisa => _driver.FindElement(By.ClassName("document.querySelector('.buttonCustomScroll')"));
        private IWebElement Btn_pesquisar => _driver.FindElement(By.ClassName("document.querySelector('.vtex-store-components-3-x-searchBarIcon')"));
        public PesquisarCoop(IWebDriver driver)
        {
            _driver = driver;
            _js = (IJavaScriptExecutor)_driver;
        }
        public void Pesquisar(string produto)
        {
            Campo_pesquisa.Click();
            Campo_pesquisa.SendKeys(produto);
            Btn_pesquisar.Click();
        }

        public bool ExistCampoPesquisa()
        {
            try
            {
                return this.Campo_pesquisa.Displayed;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
