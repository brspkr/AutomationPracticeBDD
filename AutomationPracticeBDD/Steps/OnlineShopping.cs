using AutomationPracticeBDD.Helpers;
using AutomationPracticeBDD.Pages;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace AutomationPracticeBDD.Steps
{
    [Binding]
    public sealed class OnlineShopping
    {

        private DriverHelper _helper;
        private LoginPage _loginPage;
        private HomePage _homepage;
        private BasePage _basePage;
        private WaitHelper _fwait;
        private MyAccountPage _myAccountPage;
        private CartPage _cartPage;
        private AddressPage _addressPage;
        private ShippingPage _shippingPage;
        private PaymentPage _paymentPage;
        private OrderSummaryPage _orderSummaryPage;
        private ItemDetails _itemDetailsPage;
        private OrderConfirmationPage _orderConfirmationPage;

        private double _beforeRemoveQuantity;
        private double _totalprice;

        private string _SignInButtonXpath = "/html/body/div/div[2]/div/div[3]/div/div/div[2]/form/div/p[2]/button";
        private string _ShoppingCartSummaryTextXpath = "/html/body/div/div[2]/div/div[3]/div/ul/li[5]/span";
        private string _OrderHisAndDetailsXpath = "/html/body/div/div[2]/div/div[3]/div/div/div[1]/ul/li[1]/a/span";
        public OnlineShopping(DriverHelper helper)
        {
            this._helper = helper;
            _totalprice = 0;
            _loginPage = new LoginPage(_helper.Driver);
            _homepage = new HomePage(_helper.Driver);
            _fwait = new WaitHelper(_helper.Driver);
            _myAccountPage = new MyAccountPage(_helper.Driver);
            _basePage = new BasePage(_helper.Driver);
            _cartPage = new CartPage(_helper.Driver);
            _addressPage = new AddressPage(_helper.Driver);
            _shippingPage = new ShippingPage(_helper.Driver);
            _paymentPage = new PaymentPage(_helper.Driver);
            _orderSummaryPage = new OrderSummaryPage(_helper.Driver);
            _itemDetailsPage = new ItemDetails(_helper.Driver);
            _orderConfirmationPage = new OrderConfirmationPage(_helper.Driver);
        }


        [Given(@"User goes to login page")]
        public void GivenUserGoesToLoginPage()
        {
            _helper.Driver.Navigate().GoToUrl("http://automationpractice.com/index.php?controller=authentication&back=my-account");


            //wait until "SignIn" button appear. Wait is used as intermediate assertion to check the state!
            _fwait.fluentWait(_SignInButtonXpath);

        }

        [Given(@"and enters username and password as following")]
        public void GivenAndEntersUsernameAndPasswordAsFollowing(Table table)
        {
            var loginData = table.CreateInstance<UserLoginDetails>();

            _loginPage.enterUsername(loginData.username).enterPassword(loginData.password);


        }

        [Given(@"user clicks lo gin button")]
        public void GivenUserClicksLoGinButton()
        {
            _myAccountPage = _loginPage.clickSignIn();



        }

        [Then(@"user should be logged in")]
        public void ThenUserShouldBeLoggedIn()
        {
            //wait until "order history and details" to be appear. Wait is used as assertion!

            _fwait.fluentWait(_OrderHisAndDetailsXpath);


        }


        [When(@"user searches following items and adds to cart")]
        public void WhenUserSearchesFollowingItemsAndAddsToCart(Table table)
        {
            foreach (TableRow row in table.Rows)
            {
                foreach (string value in row.Values)
                {

                    _itemDetailsPage = _basePage.searchProduct(value).clicktoItem();

                    _totalprice += _itemDetailsPage.getItemPrice();

                    _itemDetailsPage.clickAddtoCartButton().clickContinueShopping();
                }
            }
        }

        [When(@"goes to cart and removes first item")]
        public void WhenGoesToCartAndRemovesFirstItem()
        {
            _cartPage = _basePage.clicktoCart();

            _fwait.fluentWait(_ShoppingCartSummaryTextXpath);

            _beforeRemoveQuantity = _cartPage.getCurrentProductQuantity();

            _cartPage.clickDeleteItem();

        }

        [Then(@"user must have (.*) items in the cart")]
        public void ThenUserMustHaveItemsInTheCart(int p0)
        {

            Assert.AreEqual(p0 + 1, _beforeRemoveQuantity);



        }


        [When(@"goes to cart and proceeds to Payment Page")]
        public void WhenGoesToCartAndProceedsToPaymentPage()
        {
            _cartPage = _basePage.clicktoCart();

            _fwait.fluentWait(_ShoppingCartSummaryTextXpath);

            _addressPage = _cartPage.clickProceedtoCheckout();

            _shippingPage = _addressPage.clickProceedtoCheckout();

            _paymentPage = _shippingPage.clickAgreetoTerms().clickProceedtoCheckout();
        }

        [When(@"pays with bank wire")]
        public void WhenPaysWithBankWire()
        {
            _orderSummaryPage = _paymentPage.clicktoPayWithBankWire();

            _orderConfirmationPage = _orderSummaryPage.clickIConfirmmyOrder();
        }

        [Then(@"user sees order confirmation with correct amount of charge")]
        public void ThenUserSeesOrderConfirmationWithCorrectAmountOfCharge()
        {
            Assert.AreEqual(_orderConfirmationPage.getChargedPrice(), _totalprice + 2, 2);
        }
    }
}