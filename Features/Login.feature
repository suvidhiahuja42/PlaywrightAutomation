Feature: SauceDemo Login

  Scenario: Successful login with valid credentials
    Given I navigate to the SauceDemo login page
    When I login with username "standard_user" and password "secret_sauce"
    Then I should see the products page
