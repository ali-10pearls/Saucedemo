Feature: Sort

A short summary of the feature

@sort1
Scenario: Sort the products in order of price high to low 
	Given User is on Sauce Labs website
	When  User enters username "standard_user" and password "secret_sauce"
	When  User applies sorting of price high to low
	Then  Sorting should be applied
