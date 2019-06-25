# Entity Framework Core

EF Core as a lightweight and extensible version of Entity Framework. In other words, this was not simply an update from the latest Entity Framework, EF6, it's a different kind of Entity Framework. EF Core was first released in late June of 2016 after over 2 years of effort

### Getting EF Core to Output SQL Logs

As we write and run the code for interacting with the data model, we want you to be able to see the SQL commands that are created and executed by EF Core. To do that, we'll use the logging that's built right into. NET Core and leveraged by EF Core. 

### Querying Objects
As soon as EF Core sees that you actually want some data as it hits the enumeration, got to go to the database and get that data for you so that triggers it to execute. Then you don't have to define the query variable in advance, you can just enumerate over the query itself, but there is a really important performance consideration to be aware of if you are depending on enumerations to go ahead and hit the database for you on the fly. 

At the beginning of that execution, the database connection gets opened and it will stay open until the enumeration is complete and all of the results have been streamed back. In some cases, that's perfectly fine, but in others, for example, if you start performing a lot of operations on each one of the results while you're looping through them, not only can it cause performance problems, it could also cause other side effects if other people are interacting with the same database. 
