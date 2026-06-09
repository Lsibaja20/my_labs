using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace UIAutomationTests
{
    public class Selenium
    {
        IWebDriver _driver;

        [SetUp]
        public void Setup()
        {
            _driver = new FirefoxDriver();
        }

        [Test]
        public void Enter_To_List_Country_Test()
        {
            // Arrange
            string url = "http://localhost:8080/";

            // Act
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl(url);
 
            IWebElement title =_driver.FindElement(By.TagName("h1"));
            Assert.That(title.Text,Is.EqualTo("Lista de países"));

            // add country buttom
            IWebElement addButton =_driver.FindElement(By.CssSelector(".btn-outline-secondary"));
            addButton.Click();

         
            IWebElement formTitle =_driver.FindElement(By.TagName("h1"));
            Assert.That(formTitle.Text,Is.EqualTo("Formulario para agregar país"));

            // name
            IWebElement name =_driver.FindElement(By.Id("name"));
            name.SendKeys("PaisSelenium");

            // continent
            SelectElement continent =new SelectElement(_driver.FindElement(By.Id("continente")));
            continent.SelectByText("Asia");

            // language
            IWebElement language =_driver.FindElement(By.Id("idioma"));
            language.SendKeys("Coreano");

            IWebElement saveButton =_driver.FindElement(By.CssSelector(".btn-success"));
            saveButton.Click();
            // wait to come back to the list
            WebDriverWait wait = new WebDriverWait(_driver,TimeSpan.FromSeconds(5));
            wait.Until(d =>d.PageSource.Contains("PaisSelenium"));
            Assert.That(_driver.PageSource.Contains("PaisSelenium"),Is.True);
        }
    }
}