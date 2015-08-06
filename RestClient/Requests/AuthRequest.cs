using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace WpfApplication1.Requests
{
    class AuthRequest : Request
    {
        private string user;
        private string password;
        private string sku;

        public AuthRequest(string _user, string _password, string _sku)
        {
            user = _user;
            password = _password;
            sku = _sku;

            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            JsonWriter jsonWriter = new JsonTextWriter(sw);

            jsonWriter.Formatting = Formatting.None;
            jsonWriter.WriteStartObject();
            jsonWriter.WritePropertyName("priorityLevel");
            jsonWriter.WriteValue(6);

            jsonWriter.WritePropertyName("sku");
            jsonWriter.WriteValue(sku);
            jsonWriter.WritePropertyName("clientVersion");
            jsonWriter.WriteValue(3);
            jsonWriter.WritePropertyName("method");
            jsonWriter.WriteValue("nucemail");
            jsonWriter.WritePropertyName("macAddress");
            jsonWriter.WriteValue("38:2c:4a:6e:14:05");
            jsonWriter.WritePropertyName("locale");
            jsonWriter.WriteValue("en-US");

            
                jsonWriter.WritePropertyName("identification");
                jsonWriter.WriteStartObject();
                    jsonWriter.WritePropertyName("user");
                    jsonWriter.WriteValue(user);
                    jsonWriter.WritePropertyName("password");
                    jsonWriter.WriteValue(password);
                    jsonWriter.WriteEndObject();
            jsonWriter.WriteEnd();
           

            Body = sb.ToString();
        }
    }
}
