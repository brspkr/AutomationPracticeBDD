Feature: Online Shopping
	This feature file has basic scenarios for AutomationPractice.com; such as login, add items to cart, remove items from cart, checkout and logout. 


Background: 
	Given User goes to login page
	And  and enters username and password as following
			| Username				 | Password   |
			| baris-peker@yandex.com |testuser123 |
	And user clicks lo gin button

@SmokeLogin
Scenario: Login to AutomationPractice.com
	Then user should be logged in 


@SmokeCart
Scenario: Add and remove items from cart
	When user searches following items and adds to cart
	| Item  |
	| Blouse|
	| Shirt |
	| Dress |
	And goes to cart and removes first item
	Then user must have 2 items in the cart

@SmokeCheckout
Scenario: Checkout process and payment for items
	When user searches following items and adds to cart
	| Item  |
	| Blouse|
	| Shirt |
	| Dress |
	And goes to cart and proceeds to Payment Page
	And pays with bank wire
	Then user sees order confirmation with correct amount of charge
