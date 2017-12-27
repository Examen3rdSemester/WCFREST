using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFREST
{
    /// <summary>
    /// todo Alt med "change" skal skiftes accordingly til opgaven. 
    /// todo Dette gælder "Change", "tempChange", "AllChange", "ChangeList", "OneChange"
    /// </summary>

    //HUSK for at tilgå denne, skal din browser url se lidt ud som denne = http://localhost:27575/service1.svc, 
    //hvoraf porten kan være anderledes. dette vil selvfølgelig ændrer sig når der publiseres til skyen.

    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        //UriTemplate god navne skik er at de er stort set ens men bliver defineret via Method. 
        //Småt hele vejen.
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "Change")]
        List<ChangeClassName> AllChange();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "Change/{id}")]
        ChangeClassName OneObjekt(String id);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            UriTemplate = "Change")]
        HttpStatusCode AddChange(ChangeClassName tempChange);

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            UriTemplate = "Change/{id}")]
        ChangeClassName EditClass(String id, ChangeClassName tempChange);

        [OperationContract]
        [WebInvoke(Method = "DELETE", ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            UriTemplate = "Change/{Id}")]
        HttpStatusCode RemoveClass(String id);
    }
}
