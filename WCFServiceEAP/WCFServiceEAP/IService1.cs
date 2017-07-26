using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;

namespace WCFServiceEAP
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        [WebGet(RequestFormat = WebMessageFormat.Json
            , ResponseFormat = WebMessageFormat.Json)]
        string GetMessage();
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json
            , ResponseFormat = WebMessageFormat.Json)]
        string PostMessage(string name);

    }
}
