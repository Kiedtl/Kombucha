using System;
using Kombucha.Print;

namespace Kombucha
{
    class Net
    {
        public string SendGetRequest(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream resStream = response.GetResponseStream();
            return resStream
                .ToString();
        }

        public string DownloadData(string url)
        {
            WebClient wc = new WebClient();
            byte[] res = wc.DownloadData(url);
            return System.Text.Encoding.UTF8.GetString(res);
        }
    }
}
