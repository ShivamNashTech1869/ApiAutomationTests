@Feature2
Feature: Validate Update and Delete API Endpoints

  Scenario: Update a user (Update)
    Given I have a valid API client
    When I send a PUT request to "/users/1" with body:
      """
      {
        "id": 1,
        "name": "Shivam Updated",
        "username": "shivamupdated",
        "email": "shivam.updated@example.com"
      }
      """
    Then the response status code should be 200
    And the response should contain the user name "Shivam Updated"

  Scenario: Delete a user (Delete)
    Given I have a valid API client
    When I send a DELETE request to "/users/1"
    Then the response status code should be 200
