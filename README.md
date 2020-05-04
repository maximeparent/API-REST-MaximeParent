
# REST API 
API that get the informations on the new Intervention table and can be modify.

To try the API you will need to install [postman] (https://www.postman.com/)
___
**GET**: Returns all fields of all Service Request records that do not have a start date
and are in "Pending" status.  
   (https://marc-antoinerestapi.azurewebsites.net/api/interventions/pending)

   Create a new request and select GET.   
   Copy/paste the url above and click send.
___
**PUT**: Change the status of the intervention request to "InProgress" and add a start
date and time (Timestamp).  
    (https://marc-antoinerestapi.azurewebsites.net/api/interventions/inProgress)

   Create a new request and select PUT.   
   Copy/paste the url above and after "/inProgress/" add the id you want to change.  
   for example: https://marc-antoinerestapi.azurewebsites.net/api/interventions/inProgress/1  
    
   Then inside the body, choose raw, json and copy/paste this template.  
```
{
    "start_date_time_intervention": "2020-04-08T15:58:55",
    "status": "inProgress"
}
```
___
**PUT**: Change the status of the request for action to "Completed" and add an end
date and time (Timestamp).  
    (https://marc-antoinerestapi.azurewebsites.net/api/interventions/completed)

   Create a new request and select PUT.  
   Copy/paste the url above and after "/Completed/" add the id you want to change.  
   for example: https://marc-antoinerestapi.azurewebsites.net/api/interventions/Completed/2  

   Then inside the body, choose raw, json and copy/paste this template.  
 ```
{
    end_date_time_intervention": "2020-04-08T15:58:55",
    "status": "completed"
}
```

Here are the steps to run the Rocket Elevator Rest Api:

Start you debugger in Visual Studio Code.
Open Postman
Postman Collection:  https://www.getpostman.com/collections/1ea82e58fb5ba7b51de1

Retrieving the current status of a specific Intervention(GET): Get access to the Postman Collection by clicking on the link above.  Open the collection and select RestAPI.
Select the first option(GET) and click Send(Blue button on the right corner).  You will get all the information about the first intervention.  To switch to another intervention, just enter è different number at the end of the URL.

Ex: 
https://restapi-rocketelevator.azurewebsites.net/api/intervention/1 ←
master
