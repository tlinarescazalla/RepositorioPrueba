using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticasCursoSelenium
{
    class Questions
    {
        IWebDriver vChrome;
        private string Url;
        private string username;
        private string password;
        private string key;

        [SetUp]
        public void SetUpBrowserVariables()
        {
            try
            {
                //Setting Navegador
                vChrome = new ChromeDriver();
                vChrome.Manage().Window.Maximize();
                vChrome.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

                //Setting variables
                Url = "https://examdevtst1.pearsonvue.com/ExamDeveloper/login/Login.aspx";
                username = "Auto1";
                password = "ed1tHPi0f";
                key = "velvet";
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        [Test]
        public void CreateQuestion()
        {
            try
            {
                //Navegamos a ST1
                vChrome.Navigate().GoToUrl(Url);
                Console.WriteLine("Abro navegador");
                //Login
                vChrome.FindElement(By.Id("ctl00_RHSContentPlaceHolder_tbUsername")).Click();
                vChrome.FindElement(By.Id("ctl00_RHSContentPlaceHolder_tbUsername")).Clear();
                vChrome.FindElement(By.Id("ctl00_RHSContentPlaceHolder_tbUsername")).SendKeys(username);

                //Password
                vChrome.FindElement(By.Id("ctl00_RHSContentPlaceHolder_tbPassword")).Click();
                vChrome.FindElement(By.Id("ctl00_RHSContentPlaceHolder_tbPassword")).Clear();
                vChrome.FindElement(By.Id("ctl00_RHSContentPlaceHolder_tbPassword")).SendKeys(password);

                //Click Next
                vChrome.FindElement(By.Id("ctl00_RHSContentPlaceHolder_btnLogin")).Click();

                //Velvet
                vChrome.FindElement(By.Id("ctl00_ctl00_RHSContentPlaceHolder_RHSContentPlaceHolder_tbAnswer")).Click();
                vChrome.FindElement(By.Id("ctl00_ctl00_RHSContentPlaceHolder_RHSContentPlaceHolder_tbAnswer")).Clear();
                vChrome.FindElement(By.Id("ctl00_ctl00_RHSContentPlaceHolder_RHSContentPlaceHolder_tbAnswer")).SendKeys(key);


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        [TearDown]
        public void CloseBrowser()
        {
            Console.WriteLine("Cierra navegador");
            vChrome.Quit();
        }
    }
}
