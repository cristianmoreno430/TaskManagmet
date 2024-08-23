using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestTaskManage.Selenuim
{
    public class SeleniunmFunctionalTest 
    {        

        [Fact]
        public void EnterId_And_GetTask_ReturnsExpectedResult()
        {
            //// Arrange
            //using (var driver = new ChromeDriver())
            //{
            //    driver.Navigate().GoToUrl("http://localhost:4200"); // Suponiendo que Angular está en ejecución

            //    // Act
            //    var taskInput = driver.FindElement(By.CssSelector("input"));
            //    taskInput.SendKeys("1");

            //    var gettaskButton = driver.FindElement(By.CssSelector("button"));
            //    gettaskButton.Click();

            //    // Esperar a que la respuesta se muestre
            //    var taskText = driver.FindElement(By.CssSelector("p")).Text;

            //    // Assert
            //    Assert.Equal("Estudiar", taskText);
            //}
        }
    }
}
