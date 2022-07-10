using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System.Collections.Generic;
using OpenQA.Selenium.Support.UI;

namespace SeleniumSearch
{
    internal class Program
    {


        static void Main(string[] args)
            {

                var driver = new ChromeDriver();
                driver.Navigate().GoToUrl("https://www.trendyol.com/");

                var searchBox = driver.FindElement(By.ClassName("search-box"));
                var searchButton = driver.FindElement(By.ClassName("search-box"));
                searchBox.SendKeys("Televizyon");

                System.Threading.Thread.Sleep(2000);
                searchButton.SendKeys(Keys.Return);

                var option = driver.FindElement(By.TagName("select"));
                var selectElement = new SelectElement(option);
                System.Threading.Thread.Sleep(2000);
                selectElement.SelectByValue("PRICE_BY_ASC");

                System.Threading.Thread.Sleep(2000);
                var brandSearchBox = driver.FindElements(By.ClassName("fltr-srch-inpt"))[0];
                brandSearchBox.SendKeys("Samsung");
                try
                {
                    var noResultControl = driver.FindElement(By.ClassName("fltr-srch-no-rslt"));
                    Console.WriteLine("Aranılan Marka Bulunamadı");
                }
                catch
                {
                    var selectBrand = driver.FindElements(By.ClassName("chckbox"))[0];
                    selectBrand.Click();

                    System.Threading.Thread.Sleep(2000);
                    var cheaperProduct = driver.FindElements(By.ClassName("image-overlay-body"))[0];
                    cheaperProduct.Click();

                    System.Threading.Thread.Sleep(2000);
                    driver.SwitchTo().Window(driver.WindowHandles[1]);
                    var addToBasket = driver.FindElement(By.ClassName("add-to-basket-button-text"));
                    addToBasket.Click();

                }


                //IWebDriver driver = new ChromeDriver();
                //string link = "https://www.trendyol.com/";
                //driver.Navigate().GoToUrl(link);
                //driver.FindElement(By.ClassName("search-box")).SendKeys("Televizyon");
                //driver.FindElement(By.ClassName("search-box")).SendKeys(Keys.Return);
                //driver.FindElement(By.ClassName("fltr-item-text")).Click();

            }
        }
    }
