I used Visual Studio 2017 Community Edition while completing the task. 

The VS solution is available on github, also the files are in the Viagogo folder,
they consist of:
	-Event.cs
	-Location.cs
	-Ticket.cs
	-Program.cs

There is also an executable in the Viagogo/bin/Debug/ folder which you can run, 
providing you have the .NET framework installed.

The input is validated by a Regex pattern, so I am assuming the user is inputting the 
x and y coordinates correctly.

How might you change your program if you needed to support multiple events at the same location?

In the Location.cs file I would change the data field of currentEvent to a List, that way a location
can store multiple events.

How would you change your program if you were working with a much larger world size?

I would alter the Location class to allow for GPS coordinates, and use the latitude and
longitude using Decimal Degrees, changing the data type of x and y from int to double.



