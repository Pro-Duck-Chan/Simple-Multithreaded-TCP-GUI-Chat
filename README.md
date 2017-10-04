# Simple-Multithreaded-TCP-GUI-Chat

Simple-Multithreaded-Network-Chat is a small simple chat appliction written in C# .net that is easy to understand and anyone can build on or learn from as it is not intended to be used for non development purposes.

I used vissual studio 2015 comunity to code and compile this project.

The server and client is multithreaded and uses sockets and TCP protocol to comunicate. It sends string arrays as packets. The first entry in the array is the name of the client and the second is the message.

Simple-Multithreaded-TCP-Chat is licensed under MIT License

Features of 1.0
---------------
#### Server
	*You can send messages to all clients.
	*You can send messages to a specific client by selecting the clients name in the client list.
	*You can clear the chat box by right click in the chat box.
	*You can see all connected client in the client list on the side.
	*You can add to managed clients, kick and ban clients for the client list by right click in the client list.
	*Clients that are added to to managed clients and band are saved in an XML and are used in client manager.
	*You can add, edit and delete clients data in client manager which is name, ip address, band, reason.

#### Client
	*You can send messages to all clients.
	*You can send messages to a specific client by selecting the clients name in the client list.
	*You can clear the chat box by right click in the chat box.
	*You can see all connected client in the client list on the side.

![alt text](https://raw.githubusercontent.com/Pontus-Skoglund/Simple-Multithreaded-TCP-GUI-Chat/master/Screenshot.PNG)
