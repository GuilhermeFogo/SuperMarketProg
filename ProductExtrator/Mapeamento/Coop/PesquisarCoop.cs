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

        private IWebElement Campo_pesquisa => _driver.FindElement(By.XPath("/html/body/div[2]/div/div[1]/div/div[2]/div/div[1]/section/div/div[3]/div/div/div/div/div[1]/div/label/div/input"));
        private IWebElement Btn_pesquisar => _driver.FindElement(By.XPath("/html/body/div[2]/div/div[1]/div/div[2]/div/div[1]/section/div/div[3]/div/div/div/div/div[2]/div/div/div/div/div/section/article/ol/li[1]/a"));
        public PesquisarCoop(IWebDriver driver)
        {
            _driver = driver;
            _js = (IJavaScriptExecutor)_driver;
        }
        public void Pesquisar(string produto)
        {
            Campo_pesquisa.Click();
            Campo_pesquisa.SendKeys(produto);
            try
            {
                Btn_pesquisar.Click();
                Campo_pesquisa.Clear();
            }
            catch (Exception)
            {
                Campo_pesquisa.SendKeys(Keys.Enter);
            }
            Campo_pesquisa.Clear();
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
