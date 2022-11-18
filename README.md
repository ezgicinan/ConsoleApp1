# ConsoleApp1
This repository includes a simple server client communicaton applications via TCP, coded in C#.

Settings before run the project	
-Go to project properties by right-clicking the project node in Solution Explorer and choosing Properties.

-Find 'Startup Object' part from Application/General section.

-Adjust startup object as Client.

-Save your code and rebuild.

-Click 'Publish' section by right-clicking the project node in Solution Explorer.

-Adjust build properties according to th below figure and also by choosing your desired target location.

-Then click publish.

Note: It is required to be different for Client and Server to obtain their seperate exe files.

So I published client under the folder C:\Users\YourUser\source\repos\ConsoleApp1\ConsoleApp1\bin\Release\net6-client
      

![figure1-build-properties](https://user-images.githubusercontent.com/32934405/202671005-1c901118-80ff-4bb8-b651-b3f48ef60e3c.jpg)


-Then, to obtain server's exe, change the startup object as "Server", save your code and rebuild.

-Go to publish section, adjust your folder name and other things if required.

Note: I published server under the folder C:\Users\YourUser\source\repos\ConsoleApp1\ConsoleApp1\bin\Release\net6.0-windows


RUN the project:

1 - First, run the ConsoleApp1.exe under the ...\ConsoleApp1\bin\Release\net6.0-windows folder.

You will see the below command prompt.

![image](https://user-images.githubusercontent.com/32934405/202673389-36d38af9-2fb9-4f56-8f5d-57f86f6dfcf6.png)

2- Then, run the ConsoleApp1.exe under the ...\ConsoleApp1\bin\Release\net6-client folder.

![image](https://user-images.githubusercontent.com/32934405/202674214-715e95e0-9fa2-4669-8798-09bb6ba25e44.png)

3- The below figure show whole communation between Server and Client:

![figure3-Communication](https://user-images.githubusercontent.com/32934405/202678470-972041d5-d1d7-4a72-ba1f-8db297fc9725.jpg)



