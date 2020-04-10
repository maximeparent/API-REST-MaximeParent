Here are the steps to run the Rocket Elevator Rest Api:

Start you debugger in Visual Studio Code.
Open Postman
Postman Collection:  https://www.getpostman.com/collections/1ea82e58fb5ba7b51de1

1.Retrieving the current status of a specific Battery(GET): Get access to the Postman Collection by clicking on the link above.  Open the collection and select RestAPI.
Select the first option(GET) and click Send(Blue button on the right corner).  You will get all the information about the first battery.  To switch to another battery, just enter è different number at the end of the URL.

Ex: 
https://thewonderfulrestapi.azurewebsites.net/api/batteries/1 ←

2.Changing the status of a specific Battery(PUT): Once you get the Information about the 1st battery, you'll need to copy the all of the information included in the “Body” on the right side of your screen and paste it in the “JSON” Body.  You can now change the information at the right side of “status”.  Switch the request from GET to PUT and click the SEND button.  Once you sent the request, switch the request once again for GET and send the request.  You should be able to see that the status has now been changed.


Follow the same steps as in point 1 and two by clicking on the matching toggle button of the collection and you should be able to make these requests. 

3.Retrieving the current status of a specific Column(GET)
4.Changing the status of a specific Column(PUT)
5.Retrieving the current status of a specific Elevator(GET)
6.Changing the status of a specific Elevator(PUT) 


7.Retrieving a list of Elevators that are not in operation at the time of the request(GET)
Select number 8 in collection.  Click on the SEND button to see the list of elevators that are unavailable at the moment.

8.Retrieving a list of Buildings that contain at least one battery, column or elevator requiring intervention:  Select number 9 in the collection.  Click on the SEND button and you should see a list of building that contain at least one battery, column or elevator requiring intervention.

9.Retrieving a list of Leads created in the last 30 days who have not yet become customers: Follow the exact same steps as in point 7 and 8.
