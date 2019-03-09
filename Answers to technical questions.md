# Technical Questions


#### 1. How long did you spend on the coding test? What would you add to your solution if you had more time? If you didn't spend much time on the coding test then use this as an opportunity to explain what you would add.

I spent around 3 hours. First I analyse the problem to see better approach in terms of Models so it can be abstract enough, spent some minutes testing the api with Postman. 
After that I used json to classes functionality of VS to create the classes for the service.
I did a decorator pattern to have an interface around httpclient so I could mock it on tests
 I added then the classes for the service and the Tests (unit tests and integration tests). 
 Finally I spent time building the MVC application and giving it a decent enough Look & feel.

I added the following nuget packages to help me:

* **Ninject** - My favourite dependency injector.
* **Nunit** - My preferred unit test framework
* **Moq** - My preferred mocking framework
* **FluentAssertions** - It is a framework that provides useful extensions for assertions. for this project I only used it for a simple list comparison.
* **Bootstrap**: My preferred front end framework to manage layout and responsive design

#### How I structured/created the project

##### MVC web project

I used the default home controller to handle the search form and display the restaurant results. I used Ninject to inject the service into the controller via constructor.

I added couple of viewmodels to display data in the views. 

I used bootstrap for layout.

I added few javascript funtions.  I added some localstorage functionality to cache the outcode input in the home page for user not to type it again when going back or when visiting other day.

##### Test project

I set up a set of Unit tests for the restaurant service using Nunit and Moq. 
I also used FluentAssertions for one particular list assert comparison.
 Once the service had been tested, I added an integration test to test the real connection with the api. 
 finally I added one test to check that the mapping between the restaurant api model and my restaurant view model was handled correctly.


##### Service project

First I used the VS functionality to paste Json objects as classes to get my API classes. 
I did a decorator pattern to have an interface around httpclient so I could mock it on tests


#### What I would add if I had more time?

I would have done lot of things if I had more time (I actually enjoy a lot building api services and web projects using data from APIs):

1. I would do much better exception handling, almost non existing now. Including a good logger, better custom exceptions, and better manage of possible Api issues including maybe retries.
2. I would make better use of javascript. Maybe adding Angular/React.
3. I would check that outcode provided is actually a valid outcode, right now it doesnt check if valid, just check it has something.
5. I would also make the API call with some sort of short term cache
6. I would add more unit testing for the controller, as well as some UI testing maybe like Selenium.
7. I would have improved the Layout look and feel, including good pagination for restaurants list


#### 2. What was the most useful feature that was added to the latest version of your chosen language? Please include a snippet of code that shows how you've used it.

There are many nice features in C#6 and c#7, but if I have to choose one I would say it will be for C#6:

**Null Conditional Operator (?.)**. Using C# 6.0, we can use ?. to check if an instance is null or not

double? Rating = MyNullableObject?.Rating ?? 0.0;

Other important features for me may be **string interpolation** ("{name} {lastname}"), **nameOf Expression** (nameOf(MyProperty)), **Expression Bodied Function & Property** (string ToString() => string.Format("{0}, {1}", First, Second); ) and **exception filters** (catch (Exception ex) when (ex.Message.Equals("400")))

For c#7 should be the throw expressions:

 public static double Divide(int x, int y) {  
        return y != 0 ? x % y : throw new DivideByZeroException();  
    }  


#### 3. How would you track down a performance issue in production? Have you ever had to do this?

Well first I will check the logs if there is any measure of this, application logs or event logs.
I will also check if the production server(s) is/are working fine or if it is something taking CPU or memory or something.
 Then I will maybe use some sort of profiler (like New relic or similar) to find bottle necks in the code. 
 Most of the time what happen is it works fine in local and test environment because there is not enough data, but once data become large it start to become slow. 
I would also check database for any performance issues check execution plans involved, check indexes, etc. 
I will also measure timings against api/network calls to discard any network issue.
If a microservices environment would be useful to have logs like papertrail and maybe some timings on this to see which one is taking the longer, maybe any problem in a particular service, or in the queue processing, etc

#### 4. How would you improve the JUST EAT APIs that you just used?

I would add more fields to the restaurant call to display more relevant info on the lists.

Maybe I would return some feedback when outcode is wrong and maybe even an api call to check outcode validation, or get outcode based on some address/location/lat-long

I think the unathorized token is returning 400 instead of 401 unathorized so that would help too


#### 5. Please describe yourself using JSON.

```javascript
{  
    "name":"Daniel Carles",
    "gender":"Male",
    "dateOfBirth":"30/04/1983",
	"languages": [
	{"Name": "English", "Proficiency": "Professional Working Proficiency"},
	{"Name": "Spanish", "Proficiency": "Native"}
	]
	"nationalities": [ "Spanish", "Venezuelan"]
    "education":[  
        {  
            "University":"Simon Bolivar University, Caracas, Venezuela",
            "degree":"BSc (Hons) Computer Engineering"
        }
    ],
    "interests":[  
        "Football",
        "Gaming",
        "Movies/Cinema",
		"TV Shows",
		"Coding for fun",
		"Social drinking",
		"Travel",
		"Gadgets/Technology"
    ],
    "technicalSkills":[  
        "C#",       
        "JavaScript",       
        ".NET",
        "HTML5",
        "Rest Webservices",
        "LINQ",
        "SQL",
        "GIT",
        "Entity Framework",
        "SOLID principles",
        "Design Patterns",
        "Agile Development"
    ],
     "softSkills":[  
       "Quick Learner",
       "Work well under pressure",
       "Team player",
       "Gives 110%",
       "Friendly and outgoing",
       "Passionate about coding"
        "Good finding issues",
        "Responsible",
		"Geek"
    ]
}
```

