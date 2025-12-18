It is the revision of the .NET MVC one.

1.Day One
a) First day, I start with setting up the application. 
b) I install .NET MVC application and for the clean architecture, I install 3 other class Libary namely Domain, Application and Infrastructure.

2.Day Two
c) Second day, I start slow, just setting up the packages.
d) Add Entity folder, on the Domain. 
e) In the Presentation layer i.e on the Web Applictaion I have setup the Connection String in appsetting.json and setup the Entity Relation Framework service in the Program.cs
f) In the Infrastructure, I setup the applicationDbContext and seed the data.

3.Day Three.
a. Third day, I just work on the CRUD functionality of the Villa.
b. I work on server side and client-side validation.
c. I add the toastr fratures inorder to display the success and error messages.
d. Tempdata was used but later toastr library was used.

4. Day Four
   a.Fourth day, I do work on the Villa Number(i.e. each villa has many villa number)
   b. Disable the autosetup of primary of VillaNumber.
   c. Implement the CRUD functionalities of VillaNumber in the VillaNumberController.
   d. Use the Any methods in the Controller while creating the VillaNumber.
   
