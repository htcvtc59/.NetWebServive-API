using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.ServiceModel;
using System.Text;

namespace WCFServiceEAP
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        List<Book> list = new List<Book>()
        {
            new Book() {BookID="B01",BookTitle="Java",Author="Author1" },
            new Book() {BookID="B02",BookTitle="C#",Author="Author2" },
            new Book() {BookID="B03",BookTitle="PHP",Author="Author3" },
            new Book() {BookID="B04",BookTitle="Python",Author="Author4" }
        };


        public string GetMessage()
        {
            DataContractJsonSerializer seri = new DataContractJsonSerializer(list.GetType());
            MemoryStream stream = new MemoryStream();
            seri.WriteObject(stream, list);
            string json = Encoding.Default.GetString(stream.ToArray());
            return json;
        }

        public string PostMessage(string name)
        {
            return "Welcome to" + name + "PostMessage()";
        }
    }
}
