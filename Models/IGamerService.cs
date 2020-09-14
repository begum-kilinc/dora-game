using ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;

namespace Game.Models
{
    [ServiceContract]
    interface IGamerService
    {
        [OperationContract]
        string Test(string s);
        [OperationContract]
        void XmlMethod(System.Xml.Linq.XElement xml);
        [OperationContract]
        Gamer TestCustomModel(Gamer inputModel);


        [OperationContract]
        Task<GamerDeatils> GetGamerDetail( int userID);
    }
}
