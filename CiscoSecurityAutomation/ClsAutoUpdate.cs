using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Net;
using System.Windows.Forms;

namespace CiscoSecurityAutomation
{
    class ClsAutoUpdate
    {
        public void checkforupdates()
        {
            MessageBox.Show("Please remember that this software is in the beta stage.");
            string updateurl = @"https://github.com/katy-yardborough-projects/CiscoSecurityAutomation/tree/master/CiscoSecurityAutomation/update.txt";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(updateurl);
            request.AutomaticDecompression = DecompressionMethods.GZip;
            string updateresponse = "";
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                updateresponse = reader.ReadToEnd();
            }
            
            byte[] bytes = Convert.FromBase64String(updateresponse);

            using (MemoryStream stream = new MemoryStream(bytes))
            {
                object updatebin = new BinaryFormatter().Deserialize(stream);
                int updatesize = updatebin.ToString().Length;
                if(updatesize > 73432432)
                {
                    MessageBox.Show("There is an update available, please revisit the respository");
                }
            }
            
        }
    }
}
