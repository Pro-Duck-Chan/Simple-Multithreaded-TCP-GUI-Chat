using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Networking.Data //creats a namespace so we can use any name for the call we want and so it is easy to access form other scripts
{
    [Serializable]
    public static class Packet //creats a class
    {
        public static byte[] Pack(Tuple<int, string[]> content) //Pack Packets
        {
            var bf = new BinaryFormatter(); //creats a BinaryFormatter
            var ms = new MemoryStream(); //creats a MemoryStream

            for (int i = 0; i < content.Item2.Length; i++)
                content.Item2[i] = Encode(content.Item2[i]);

            bf.Serialize(ms, content); //uses BinaryFormatter to serialize content and ms that will be sent
            byte[] packet = ms.ToArray(); //creats a byte array and uses MemoryStream to make it to an array
            ms.Close(); //closes the MemoryStream

            return packet; //returns packet
        }

        public static Tuple<int, string[]> UnPack(byte[] packet) //UnPack Packets
        {
            var bf = new BinaryFormatter(); //creats a BinaryFormatter and instantiate it with a new instance 
            var ms = new MemoryStream(packet); //creats a MemoryStream and set it with packet

            var content = (Tuple<int, string[]>)bf.Deserialize(ms); //creats string arrray and casts it so it can deserialize with bf and ms
            ms.Close(); //closes the MemoryStream

            for (int i = 0; i < content.Item2.Length; i++)
                content.Item2[i] = Decode(content.Item2[i]);

            return content; //returns content
        }

        //Encoded
        public static string Encode(string data)
        {
            if(data != null)
            {
                var encodeBase64 = System.Text.Encoding.UTF8.GetBytes(data);
                return System.Convert.ToBase64String(encodeBase64);
            }
            return null;
        }

        //Decode
        public static string Decode(string data)
        {
            if (data != null)
            {
                var decodeBase64 = System.Convert.FromBase64String(data);
                return System.Text.Encoding.UTF8.GetString(decodeBase64);
            }
            return null;
        }

    } //end of class Packet
} //end of namespace Components.Networking.Data