using System;
using System.Net;

namespace Networking.NetworkLib //creats a namespace so we can use any name for the call we want and so it is easy to access form other scripts
{
    public static class NetworkFunctions //creats a class
    {
        public static Boolean CheckIPv4Valid(String strIP) //checks so it is a valid ip address
        {
            //  Split string by ".", check that array length is 3
            char chrFullStop = '.'; //creats char and sets it with .
            string[] arrOctets = strIP.Split(chrFullStop); //creats string array and sets it with strIP split with  chrFullStop
            if (arrOctets.Length != 4) //if arrOctets dosen't equal 4 in length
            {
                return false; //returns false
            }
            //  Check each substring checking that the int value is less than 255 and that is char[] length is !> 2
            Int16 MAXVALUE = 255; //creats Int16 and sets it with 255
            Int32 temp; //creats Int35  Parse returns Int32
            foreach (String strOctet in arrOctets)
            {
                if (strOctet.Length > 3)//if strOctet is over 3 in length
                {
                    return false; //returns false
                }

                temp = int.Parse(strOctet); //sets temp with parse strOctet to int
                if (temp > MAXVALUE) //if temo is higher then MAXVALUE in value
                {
                    return false; //returns false
                }
            }
            return true; //returns true
        }

        public static Boolean CheckPortValid(String strPort) //checks so it is a valid port numeber
        {
            int port; //creats int so we can store port nummber in it

            if (int.TryParse(strPort, out port)) //if strPort can parse and sets port
            {
                if (port >= 1 && port <= 65535) //if port is higher or equal to 1024 and lower or equal to 65535
                    return true; //returns true
            }

            return false; //returns false
        }

        public static string GetIP4Address() //gets the ip to the servers
        {
            IPAddress[] ips = Dns.GetHostAddresses(Dns.GetHostName()); //creats IPAddress[] array and sets it with host ip address

            foreach (IPAddress i in ips) //foreach IPAddress in ips
            {
                if (i.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork) //if i.AddressFamily is equal to InterNetwork
                    return i.ToString(); //return i and make it to a string
            }
            return "127.0.0.1"; //returns 127.0.0.1 which is local host
        }

    } //end of class NetworkFunctions
} //end of namespace Components.Networking.NetworkLib
