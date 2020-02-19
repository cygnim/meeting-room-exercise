# Meeting Reservation Exercise

You have been tasked with creating a meeting scheduling API.

## User stories:

- As a user, I want to be able to retreive information about a conference room by providing the room Id.
- As a user, I want to get a list of rooms that are free between a specified start and and end datetime.
- As a user, I want to be able to provide a meeting Id and see the meeting details and associated room and attendee information.
- As a user, I want to be able to create a new meeting and specify a room and attendees.
- As a user, I want to be able to delete a meeting and the attendee list for that meeting.
- As a user, I want to retrieve a list of users in the application.

## Incorporate the following into your solution:

1. Entity Framework (with Code-First migrations)
1. Dependency injection (use the container of your choice, or pure DI if you prefer)
1. Database (Utilize any relational database of your choosing, Sqlite is configured already but you may choose another.)
1. Demonstrate SOLID principles and maintain a clean architecture (feel free to refactor as you see fit and comment to provide insight on your changes and architectural decisions)
1. Utilize best practices for handling validation and sanitization of user input.
1. Utilize interfaces and abstractions to facilitate unit testing and code flexibility.
1. Provide unit tests using MSTest, xUnit or NUnit for the Meeting controller and all code traversed via this controller. For the sake of brevity, it is not necessary to provide unit tests for the entire solution.
1. Configure curl, Postman or some other rest tool so that you can demonstrate your working endpoints during an in-person interview.

## Security:

In a real world situation, security is an important aspect to an application that requires much time and effort. For the purpose of this exercise, please use the following contrived implementation:
1. To "authenticate" the user, provide an item in the HttpHeader with the key `AuthToken`. All API endpoints should require this authentication.
1. The value for this should be compared against the `User.AuthToken` property to authenticate the user. (Again, this is a contrived implementation of security for brevity).
1. Return the correct Http Status Code to notify the user if they could not be authenticated.

## Completion

Please keep your solution private. Do not submit a pull request or fork the repo unless explicitly asked to do so. It is important this exercise is complete and working before your in-person interview as we will continue working with this project.

Please feel free to contact me if you have questions, concerns, or would like clarification.