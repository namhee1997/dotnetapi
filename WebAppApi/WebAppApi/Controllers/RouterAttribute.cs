using System;

namespace WebAppApi.Controllers
{
    internal class RouterAttribute : Attribute
    {
        private string v;

        public RouterAttribute(string v)
        {
            this.v = v;
        }
    }
}