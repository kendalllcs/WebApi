Special Instructions: None/ All Tools used are referenced from in-class/in-class-recordings.

email/pass

admin@gmail.com/admin
kendalllawsoncs@gmail.com/password
notrealatall@gmail.com/password
kendalldoesnthaveffb@gmail.com/password

endpoints

TokenController Endpoints:

POST /api/Token/Authenticate
This endpoint is responsible for authenticating a user. It expects a JSON body with email and password fields.
If authentication is successful, it returns an OK (200) response with a JWT token.
If authentication fails (either the user is not found or the password does not match), it returns a Forbidden (403) response.

Notes on Authorization:
The TokenController does not specify any [Authorize] or [AllowAnonymous] attributes, which implies that the endpoint does not require authorization by default. However, the actual requirement for authorization will depend on the global configuration or any middleware that may apply authorization policies to endpoints.

The Program.cs file defines several authorization policies (AdminOnly, ManagerOnly, UserOnly) based on roles, but without seeing the rest of the controllers, it's not possible to determine which endpoints (if any) these policies are applied to.

Other Controllers:
[HttpGet], [HttpPost], [HttpPut], [HttpDelete], etc. attributes to determine the available endpoints and their HTTP methods.

Additionally, you would check for [Authorize] attributes on controller classes or individual action methods to understand the authorization requirements for each endpoint.