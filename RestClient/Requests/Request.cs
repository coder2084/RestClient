using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1.Requests
{
    class Request
    {
        private string body;
        private string url;

        public string Body
        {
            get { return body; }
            protected set { body = value; }
        }

        public string URL
        {
            get { return url; }
            set { url = value; }
        }
    }
}
