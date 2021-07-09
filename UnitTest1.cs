using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;
using System.Threading;

namespace Amazon
{
    public class Tests
    {
        readonly IWebDriver driver = new ChromeDriver();

        [SetUp]
        public void Setup()
        {
            driver.Navigate().GoToUrl("https://www.amazon.in/");
            driver.Manage().Window.Maximize();
        }

        [Test]
        [System.Obsolete]
        public void Change_Location()
        {
            WebDriverWait wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(5));
            IWebElement Address_block = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='glow-ingress-block']")));
            Address_block.Click();
            IWebElement pincode_box = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@id='GLUXZipUpdateInput']")));
            pincode_box.SendKeys("122001");
            IWebElement apply_button = driver.FindElement(By.XPath("//span[@id='GLUXZipUpdate']"));
            apply_button.Click();
            IWebElement Pin_Error = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='GLUXZipError']")));
            //Console.WriteLine(Pin_Error.Text);
            if (Pin_Error.Text.Contains("Please enter a valid pincode"))
            {
                Console.WriteLine("Enter a Valid Pin");
                //Assert.Pass("Pincode_Box validated");
            }
            else
            {
                Console.WriteLine("Valid Pin Entered");
              //  Assert.Fail("Pincode_Box not validated");
            }

        }
        [Test]
        [Obsolete]
        public void Product_Search_box()
        {
            WebDriverWait wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(5));
            IWebElement Search_Box = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@id='twotabsearchtextbox']")));
            Search_Box.SendKeys("Smart Phones");
            IWebElement Search_Button = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@id='nav-search-submit-button']")));
            Search_Button.Click();
            IWebElement Amount_range = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='₹1,000 - ₹5,000']")));
            Amount_range.Click();
            Thread.Sleep(2000);
            IWebElement Selected_Phone= wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='IDEA 3G SMARTPHONE ID-4000 (BLACK)']")));
            String phone = Selected_Phone.GetAttribute("value");
            Selected_Phone.Click();
            Thread.Sleep(3000);
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            IWebElement Add_To_Cart_Buttton = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@id='add-to-cart-button']")));
            Add_To_Cart_Buttton.Click();
            IWebElement Search_Box1 = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@id='twotabsearchtextbox']")));
            Search_Box1.SendKeys("Laptop");
            IWebElement Search_Button1 = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@id='nav-search-submit-button']")));
            Search_Button1.Click();
            IWebElement Amount_range_lap = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='₹20,000 – ₹30,000']")));
            Amount_range_lap.Click();
            Thread.Sleep(2000);
            IWebElement Selected_laptop = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='HP 15 Entry Level 15.6-inch (39.62 cms) HD Laptop (AMD 3020e/4GB/1TB HDD/Windows 10 Home/Jet Black/1.74 Kg), 15s-gy0003AU']")));
            String laptop = Selected_laptop.GetAttribute("value");
            Selected_laptop.Click();
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            IWebElement see_buy_option = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='buybox-see-all-buying-choices']")));
            see_buy_option.Click();
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            IWebElement add_to_cart = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@Name='submit.addToCart']")));
            add_to_cart.Click();
            IWebElement Final_cart = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//a[@id='hlb-view-cart-announce']")));
            Final_cart.Click();
            IWebElement Selected_Phone_final = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[contains(text(),'IDEA 3G SMARTPHONE ID-4000 (BLACK)')]")));
            String phone_final = Selected_Phone_final.GetAttribute("value");
            IWebElement Selected_laptop_final = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[contains(text(),'HP 15 Entry Level 15.6-inch (39.62 cms) HD Laptop (AMD 3020e/4GB/1TB HDD/Windows 10 Home/Jet Black/1.74 Kg), 15s-gy0003AU')]")));
            String laptop_final = Selected_laptop_final.GetAttribute("value");
            if(phone==phone_final && laptop==laptop_final)
            {
                Console.WriteLine("Items verified");
                Assert.Pass("Test Case Verified");
            }
            else
            {
                Console.WriteLine("Items not verified");
                Assert.Fail("Items not verified");
            }
        }

        [TearDown]
        public void ClearUp()
        {
           // driver.Close();
        }
    }
}