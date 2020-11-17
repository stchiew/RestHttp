using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RestHttp
{
  class Program
  {
    static void Main(string[] args)
    {
      string url = "https://your rest api";
      HttpWebRequest request = WebRequest.CreateHttp(url);
      request.Method = HttpMethod.Get.ToString().ToUpper();
      HttpWebResponse resp = (HttpWebResponse)request.GetResponse();
      using (resp)
      {
        Stream responseStream = resp.GetResponseStream();
        using (responseStream)
        {
          StreamReader myStreamReader = new StreamReader(responseStream, Encoding.UTF8);
          using (myStreamReader)
          {
            string responseJSON = myStreamReader.ReadToEnd();

            var data = JsonConvert.DeserializeObject(responseJSON);
          }
        }
      }
    }
  }
}
