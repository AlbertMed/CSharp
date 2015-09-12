using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DISSample
{
    public class producto
    {
        string id;
        string cantidad;
        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        
        public string Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }
    }
}