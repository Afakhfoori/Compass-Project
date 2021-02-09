# Compass-project

## A Fullstack Code Test

In this Repository I have 2 Directories, 
1) Compass.Survey.Backend
2) Compass.Survey.UI


### Compass.Survey.Backend
Consist of backend solution with minimum coding to return the required data for Survey project and feed the UI. The structure is explained below:

In this .Net Solution there are 4 layers

1.	Domain layer which consists of the domain entities which are going to be used.

2.	Repository layer which is accessing the Domain layer and will create/update the data base using .Net Entity Framework and the Backend database I have used is SQL server.

3.	Services layer which will access the Repository to Access and Update the data in DB and also do any other services based on system requirements complex activities.

4.	The Backend to access server would be an API which will access the Service project to access database.

5.	The API test project to test the Api end points.

6.	I would add a Unit Test project as well for testing code as we implement in the domain and Services

For testing purposes I propose Dependency injection, So I have provided one example in my project, which I will test the API end points using a Mock Service.


### Compass.Survey.UI

I choose React to implement UI. In my solution I have 3 components:

1.	Question --- Which have the Question details included options.

2.	Survey --- Which have the list of questions based on selected survey

3.	Surveys --- Which is the main page and shows the surveys which has been already fetched from Api in the higher component (App component)



## More details documentation has been added in to the solutions directories





