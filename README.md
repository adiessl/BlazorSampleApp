# BlazorSampleApp

This repository showcases an error regarding the redirection of an unauthorized user to the login page. It is not yet clear, if the error is caused by configuring the app wrongly or by a bug in the framework.

The repository was created to be used in https://github.com/dotnet/aspnetcore/issues/28199.

## Steps to reproduce
1. Open the solution

1. Profile `App (root)`
   + Start the project.
   + A browser window with the app's root will be opened.
   + As you are not logged in, you will be redirected to the login page.
   + You will also immediately be redirected to the login page if you change the url in the browser to `/counter`.
   + After login you will be redirected back to the root.
   + The app can be used "normally".
   + Logout again.
   + Stop the project.

1. Profile `App (counter)`
   + Start the project.
   + A browser window with the counter page will be opened.
   + If you are not yet logged in, you will **not** be redirected to the login page.
   + You will also **not** be redirected to the login page if you change the url in the browser to `/`.
   + The app's main layout will be displayed, but instead of the page content the message *Not authorized* will be shown.
   + The app **cannot** be used "normally".
   + Stop the project.

1. The same behavior can be observed with the profiles `IIS Express (root)` and `IIS Express (counter)`.

## What should happen?

Users that are not authorized should always be redirected to the login page, regardless of the page they are requesting first.
