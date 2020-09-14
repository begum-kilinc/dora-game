using Game.Data;
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
    public class SampleService : ISampleService
    {


        public SampleService()
        {
            Task<HitDetails[]> task = GethitDetail();


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
        public async Task<HitDetails[]> GethitDetail()
        {
            ServiceReference1.ServiceSoapClient ServiceClient;

            BasicHttpBinding binding = new BasicHttpBinding();

            //Specify the address to be used for the client.
            EndpointAddress address =
               new EndpointAddress("http://46.20.150.182:8084/service.asmx");
            ServiceClient = new ServiceSoapClient(binding, address);
            var x = ServiceClient.InnerChannel;

            var data = await ServiceClient.CheckHitListAsync();
            CheckHitListResponseBody boyd = data.Body;
            HitDetails[] details = boyd.CheckHitListResult;

           /* int lngth = details.Length;
            var res = await ServiceClient.CheckUserAsync(1);
            CheckUserResponseBody result = res.Body;
            GamerDeatils gamerdetails = result.CheckUserResult;
            for (int i = 0; i < details.Length; i++)
            {
                hits.DeadID = details[i].Dead;
                hits.ShooterID = details[i].Shooter;
                hits.HitID = details[i].HitID;
                hits.HitZone = details[i].HitZone;

            }*/
          /*  Hits hits = new Hits();
            hits. = Convert.ToInt32(details.GamerID);*/

            return details;
            /*  ServiceReference1.ServiceSoapClient authorServiceClient = new ServiceReference1.ServiceSoapClient(new System.ServiceModel.BasicHttpsBinding(BasicHttpsSecurityMode.Transport), new EndpointAddress("https://46.20.150.182:8084/service.asmx"));
              var data = await authorServiceClient.CheckHitListAsync();
              return data;*/
        }
    }
}
