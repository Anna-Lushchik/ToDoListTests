Feature: GetMethodForToDoList

@tag1
Scenario: Get ToDoList
	Given I Set GET ToDoList api endpoint
	When I Send GET HTTP request
	Then I recive valid HTTP response code 200
	And I receive valid Response Body

Scenario: Get ToDoList Item
	Given I Set GET ToDoList 1 api endpoint
	When I Send GET HTTP request
	Then I recive valid HTTP response code 200
	And I receive valid Response Body for 1

Scenario: Get Invalid ToDoList Item
	Given I Set GET ToDoList <item> api endpoint
	When I Send GET HTTP request
	Then I recive NotFound HTTP response code 404

	Examples:
	| item |
	| 0   |
	| 4   |