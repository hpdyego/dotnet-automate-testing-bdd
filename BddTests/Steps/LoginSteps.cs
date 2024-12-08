using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace TestSuite.Steps
{
    [Binding]
    public class LoginSteps
    {
        private IWebDriver _driver;

        [BeforeScenario]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
        }

        [Given(@"que eu estou na página inicial do sistema")]
        public void GivenQueEuEstouNaPaginaInicialDoSistema()
        {
            _driver.Navigate().GoToUrl("https://site.login.com");
        }

        [When(@"eu insiro o ""(.*)"" e ""(.*)""")]
        public void WhenEuInsiroOUsuarioESenha(string usuario, string senha)
        {
            _driver.FindElement(By.Id("username")).SendKeys(usuario);
            _driver.FindElement(By.Id("password")).SendKeys(senha);
        }

        [When(@"clico no botão de login")]
        public void WhenClicoNoBotaoDeLogin()
        {
            _driver.FindElement(By.Id("btnLogin")).Click();
        }

        [Then(@"devo ver a mensagem de boas-vindas ""(.*)""")]
        public void ThenDevoVerAMensagemDeBoasVindas(string mensagem)
        {
            Thread.Sleep(5000);
            var welcomeMessage = _driver.FindElement(By.ClassName("copyright")).Text;

            Console.WriteLine("--------------------");
            Console.WriteLine(_driver.FindElement(By.ClassName("copyright")));

            Console.WriteLine("--------------------");
            Console.WriteLine("Mensagem Buscada   --------> "+mensagem);
            Console.WriteLine("Mensagem encontrada--------> "+welcomeMessage);
            Console.WriteLine("--------------------");
            if (!welcomeMessage.Contains(mensagem))
                throw new Exception($"Mensagem esperada '{mensagem}' não encontrada!");
        }

        [AfterScenario]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}
