using Game.Models;
using ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Game
{
    public class GamerSample : IGamerService
    {
        public GamerSample()
        {
            //Task<GamerDeatils> task = GetGamerDetail(int userID);


        }


        public string Test(string s)
        {


            throw new NotImplementedException();
        }

        public Gamer TestCustomModel(Gamer inputModel)
        {
            throw new NotImplementedException();
        }

        public void XmlMethod(XElement xml)
        {
            throw new NotImplementedException();
        }
        public async Task<GamerDeatils> GetGamerDetail(int userID)
        {
            ServiceReference1.ServiceSoapClient ServiceClient;

            BasicHttpBinding binding = new BasicHttpBinding();

            //Specify the address to be used for the client.
            EndpointAddress address =
               new EndpointAddress("http://46.20.150.182:8084/service.asmx");
            ServiceClient = new ServiceSoapClient(binding, address);
            var x = ServiceClient.InnerChannel;

           /* var data = await ServiceClient.CheckHitListAsync();
            CheckHitListResponseBody boyd = data.Body;
            HitDetails[] details = boyd.CheckHitListResult;
            Hits hits = new Hits();*/
 
            var res = await ServiceClient.CheckUserAsync(userID);
            CheckUserResponseBody result = res.Body;
            GamerDeatils gamerdetails = result.CheckUserResult;


            /*  Hits hits = new Hits();
              hits. = Convert.ToInt32(details.GamerID);*/

            return gamerdetails;
            /*  ServiceReference1.ServiceSoapClient authorServiceClient = new ServiceReference1.ServiceSoapClient(new System.ServiceModel.BasicHttpsBinding(BasicHttpsSecurityMode.Transport), new EndpointAddress("https://46.20.150.182:8084/service.asmx"));
              var data = await authorServiceClient.CheckHitListAsync();
              return data;*/
        }
    }
}