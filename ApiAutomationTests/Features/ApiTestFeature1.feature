@Feature1
Feature: Validate Basic API Endpoints

  Scenario: Get user by ID
    Given I have a valid API client
    When I send a GET request to "/users/1"
    Then the response status code should be 200
    And the response should contain the user name "Leanne Graham"

  Scenario: Create a new user
    Given I have a valid API client
    When I send a POST request to "/users" with body:
      """
      {
        "name": "Shivam Singh",
        "username": "shivam123",
        "email": "shivam@example.com"
      }
      """
    Then the response status code should be 201
    And the response should contain the user name "Shivam Singh"
