Feature: Login

A short summary of the feature

Background: 
	Given User is on Sauce Labs website
	

@Valid_Login 
Scenario: Login - User is able to Login with correct password
	When  User enters username "standard_user" and password "secret_sauce"
	Then  Application should display product menu page 

@Invalid_login
Scenario: Login - User is unable to Login with incorrect username
	When  User enters username "ali-sharjeel" and password "secret_sauce"
	Then  Application should display error message unmatched

